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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace DB_course.Presenter
{
    public class UnLoginPresenter 
    {
        IUnLoginView view;
        AUnLoginModel model;

        private readonly string sqlConnectionString;
        IConnection connection;
        public UnLoginPresenter(IUnLoginView view, string sqlConnectionString)
        {
            this.view = view;

            this.sqlConnectionString = sqlConnectionString;
            this.view.SaveEvent += CheckPerson;

            var optionsBuilder = new DbContextOptionsBuilder<WarehouseContext>();
            var options = optionsBuilder.UseSqlServer(sqlConnectionString).Options;
            connection = new WarehouseContext(options);

            this.model = new UnLoginModel(new UnitOfWork(new SQLRepositoryAbstractFabric(connection))); ;

            this.view.Show();
        }

        private void CheckPerson(object? sender, EventArgs e)
        {
            string login = this.view.WorkerLogin;
            string password = this.view.WorkerPassword;
            State a = model.Check(login, password);
             if(a == State.OK || a == State.FIRST)
                switch(model.Proffesion)
                {
                    case "worker":
                        ShowWorkerView(login);
                        break;
                    case "warehouseman":
                        break;
                    case "admin":
                        ShowAdmin();
                        break;
                    case "hradmin":
                        ShowHrView();
                        break;
                }

          //  this.view.Close();

        }

        private void ShowHrView()
        {
            IHRAdminView view = HRAdminForm.GetInstace();
            AHRAdminModel model = new HRAdminModel(new UnitOfWork(new SQLRepositoryAbstractFabric(connection)));
            model = new HRAdminModelLogDecorator(model);
            new HRAdminPresenter(view, model);
        }

        private void ShowWorkerView(string login)
        {
            IWorkerView view = WorkerForm.GetInstace();
            IModel model = new WorkerModel(new UnitOfWork(new SQLRepositoryAbstractFabric(connection)), login);
            new WorkerPresenter(view, model);
        }
        private void ShowAdmin()
        {

            IWarehouseAdminView view = WarehouseAdminForm.GetInstace();
            IModel model = new WarehouseAdminModel(new UnitOfWork(new SQLRepositoryAbstractFabric(connection)));
            new WarehouseAdminPresenter(view, model);
        }
    }
}
