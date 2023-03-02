using DB_course.Models;
using DB_course.Models.DBModels;
using DB_course.Repositories;
using DB_course.View;
using Microsoft.EntityFrameworkCore;
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
            this.mainView.ShowHrAdmin += ShowHrView;
        }

        private void ShowHrView(object? sender, EventArgs e)
        {
            var optionsBuilder = new DbContextOptionsBuilder<WarehouseContext>();
            var options = optionsBuilder.UseSqlServer(sqlConnectionString).Options;

            IHRAdminView view =HRAdminForm.GetInstace((MainForm)mainView);
            IModel model = new HRAdminModel(new UnitOfWork(new WarehouseContext(options)));
            new HRAdminPresenter(view, model);
        }

        private void ShowWorkerView(object sender, EventArgs e)
        {
            IWorkerView view = WorkerForm.GetInstace((MainForm)mainView);
            //IPetRepository repository = new PetRepository(sqlConnectionString);
            new WorkerPresenter(view/*, repository*/);
        }
    }
}
