using DB_course.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DB_course.Presenter
{
      public class MainPresenter
    {
        private IMainView mainView;
        private readonly string sqlConnectionString;
        public MainPresenter(IMainView mainView, string sqlConnectionString)
        {
            this.mainView = mainView;
            this.sqlConnectionString = sqlConnectionString;
            this.mainView.ShowWorker += ShowWorkerView;
        }
        private void ShowWorkerView(object sender, EventArgs e)
        {
            IWorkerView view = WorkerForm.GetInstace((MainForm)mainView);
            //IPetRepository repository = new PetRepository(sqlConnectionString);
            new WorkerPresenter(view/*, repository*/);
        }
    }
}
