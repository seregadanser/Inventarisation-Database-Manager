using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DB_course.View
{
    public partial class WorkerForm : Form , IWorkerView
    {
        public WorkerForm()
        {
            InitializeComponent();
        }

        public void SetWorkerListBindingSource(BindingSource petList)
        {
            dataGridView1.DataSource = petList;
        }

        private static WorkerForm instance;

        public string SearchValue { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IsEdit { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IsSuccessful { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Message { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public static WorkerForm GetInstace(Form parentContainer)
        {
            if(instance == null || instance.IsDisposed)
            {
                instance = new WorkerForm();
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
    }
}
