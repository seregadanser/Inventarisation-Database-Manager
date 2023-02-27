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
    public partial class MainForm : Form, IMainView
    {
        public MainForm()
        {
            InitializeComponent();
            button1.Click += delegate { ShowWorker?.Invoke(this, EventArgs.Empty); };
        }



        public event EventHandler ShowWorker;
        public event EventHandler ShowAdmin;
        public event EventHandler ShowWarer;
    }
}
