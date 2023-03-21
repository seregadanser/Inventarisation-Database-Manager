using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB_course.View
{
    public partial class WarehouseAdminForm : Form,IWarehouseAdminView
    {
        private string message;
        private bool isSuccessful;
        private bool isEdit;

        public WarehouseAdminForm()
        {
            InitializeComponent();
            button1.Click += delegate
            {
                var result = MessageBox.Show("Are you sure you want to delete the selected worker?", "Warning",
                      MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if(result == DialogResult.Yes)
                {
                    DeleteEvent?.Invoke(this, EventArgs.Empty);
                    MessageBox.Show(Message);
                }
            };
        }

        public int PlaceId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int ProductId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string SearchValue { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IsEdit { get { return isEdit; } set { isEdit = value; } }
        public bool IsSuccessful { get { return isSuccessful; } set { isSuccessful = value; } }
        public string Message { get { return message; } set { message = value; } }

        public event EventHandler SearchEvent;
        public event EventHandler AddNewEvent;
        public event EventHandler EditEvent;
        public event EventHandler DeleteEvent;
        public event EventHandler SaveEvent;
        public event EventHandler CancelEvent;

        public void SetPlaceListBindingSource(BindingSource WorkerList)
        {
            throw new NotImplementedException();
        }

        public void SetProductListBindingSource(BindingSource WorkerList)
        {
            dataGridView1.DataSource = WorkerList;
        }

        private void WarehouseAdminForm_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private static WarehouseAdminForm instance;
        public static WarehouseAdminForm GetInstace(Form parentContainer)
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new WarehouseAdminForm();
                instance.MdiParent = parentContainer;
                //instance.FormBorderStyle = FormBorderStyle.None;
                //instance.Dock = DockStyle.Fill;
            }
            else
            {
                if (instance.WindowState == FormWindowState.Minimized)
                    instance.WindowState = FormWindowState.Normal;
                instance.BringToFront();
            }
            return instance;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
