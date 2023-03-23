using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Newtonsoft.Json.Linq;
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
            buttonDelete.Click += delegate
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

        public int PlaceId { get { return int.TryParse(textPlaceId.Text, out _) ? Convert.ToInt32(textPlaceId.Text) : -1;  } set { textPlaceId.Text = Convert.ToString( value); } }
        public int ProductId { get { return int.TryParse(textProductId.Text, out _) ? Convert.ToInt32(textProductId.Text) : -1; } set { textProductId.Text = Convert.ToString(value); } }
        string IWarehouseAdminView.ProductName { get { return textProductName.Text; } set { textProductName.Text = value; } }
        public string DateCome { get { return textDateCome.Text; } set { textDateCome.Text = value; } }
        public string DateProduction { get { return textDateProduction.Text; } set { textDateProduction.Text = value; } }
        public int InventoryNumber { get { return int.TryParse(textInventoryNumber.Text, out _) ? Convert.ToInt32(textInventoryNumber.Text) : -1; } set { textInventoryNumber.Text = Convert.ToString(value); } }

        public string SearchValue { get {return textSearch.Text; } set { textSearch.Text = value; } }
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
                instance = new WarehouseAdminForm
                {
                    MdiParent = parentContainer
                };
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

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
    }
}
