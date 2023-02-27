using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB_course.View
{
    public partial class HRAdminForm : Form, IHRAdminView
    {
        private string message;
        private bool isSuccessful;
        private bool isEdit;

        public HRAdminForm()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();
            tabControl1.TabPages.Remove(tabPage2);
        }

        
        public void SetWorkerListBindingSource(BindingSource WorkerList)
        {
            dataGridView1.DataSource = WorkerList;
        }

        private void AssociateAndRaiseViewEvents()
        {
            //Search
            Search.Click += delegate { SearchEvent?.Invoke(this, EventArgs.Empty); };
            SearchText.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                    SearchEvent?.Invoke(this, EventArgs.Empty);
            };
            //Add new
            Add.Click += delegate
            {
                AddNewEvent?.Invoke(this, EventArgs.Empty);
                tabControl1.TabPages.Remove(tabPage1);
                tabControl1.TabPages.Add(tabPage2);
                tabPage2.Text = "Add new pet";
            };
            //Edit
            Edit.Click += delegate
            {
                EditEvent?.Invoke(this, EventArgs.Empty);
                tabControl1.TabPages.Remove(tabPage1);
                tabControl1.TabPages.Add(tabPage2);
                tabPage2.Text = "Edit pet";
            };
            //Save changes
             Save.Click += delegate
            {
                SaveEvent?.Invoke(this, EventArgs.Empty);
                if (isSuccessful)
                {
                    tabControl1.TabPages.Remove(tabPage2);
                    tabControl1.TabPages.Add(tabPage1);
                }
                MessageBox.Show(Message);
            };
            //Cancel
            Cancel.Click += delegate
            {
                CancelEvent?.Invoke(this, EventArgs.Empty);
                tabControl1.TabPages.Remove(tabPage2);
                tabControl1.TabPages.Add(tabPage1);
            };
            //Delete
            Delit.Click += delegate
            {
                var result = MessageBox.Show("Are you sure you want to delete the selected pet?", "Warning",
                      MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    DeleteEvent?.Invoke(this, EventArgs.Empty);
                    MessageBox.Show(Message);
                }
            };
        }

        public event EventHandler SearchEvent;
        public event EventHandler AddNewEvent;
        public event EventHandler EditEvent;
        public event EventHandler DeleteEvent;
        public event EventHandler SaveEvent;
        public event EventHandler CancelEvent;

        public int WorkerId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string WorkerName { get { return NameText.Text; } set { NameText.Text = value; } }
        public string WorkerSecondName { get { return SecondNameText.Text; } set { SecondNameText.Text = value; } }
        public string WorkerPosition { get { return PositionText.Text; } set { PositionText.Text = value; } }
        public string WorkerBirthday { get { return BirthdayText.Text; } set { BirthdayText.Text = value; } }
        public string SearchValue { get { return SearchText.Text; } set { SearchText.Text = value; } }
        public bool IsEdit { get { return isEdit; } set { isEdit = value; } }
        public bool IsSuccessful { get { return isSuccessful; } set { isSuccessful = value; } } 
        public string Message { get { return message; } set { message = value; } }

        private static HRAdminForm instance;
        public static  HRAdminForm GetInstace(Form parentContainer)
        {
            if(instance == null || instance.IsDisposed)
            {
                instance = new HRAdminForm();
                instance.MdiParent = parentContainer;
                //instance.FormBorderStyle = FormBorderStyle.None;
                //instance.Dock = DockStyle.Fill;
            }
            else
            {
                if(instance.WindowState == FormWindowState.Minimized)
                    instance.WindowState = FormWindowState.Normal;
                instance.BringToFront();
            }
            return instance;
        }

        private void HRAdminForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
