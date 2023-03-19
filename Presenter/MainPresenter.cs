﻿using DB_course.Models;
using DB_course.Models.DBModels;
using DB_course.Models.CompositModels;
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
        IConnection connection;
        public MainPresenter(IMainView mainView, string sqlConnectionString)
        {
            this.mainView = mainView;
            this.sqlConnectionString = sqlConnectionString;
            this.mainView.ShowWorker += ShowWorkerView;
            this.mainView.ShowHrAdmin += ShowHrView;
            this.mainView.ShowAdmin += ShowAdmin;

            var optionsBuilder = new DbContextOptionsBuilder<WarehouseContext>();
            var options = optionsBuilder.UseSqlServer(sqlConnectionString).Options;
            connection = new WarehouseContext(options);
        }

        private void ShowHrView(object? sender, EventArgs e)
        {
            IHRAdminView view =HRAdminForm.GetInstace((MainForm)mainView);
            AHRAdminModel model = new HRAdminModel(new UnitOfWork(new SQLRepositoryAbstractFabric(connection)));
            model = new HRAdminModelLogDecorator(model);
            new HRAdminPresenter(view, model);
        }

        private void ShowWorkerView(object sender, EventArgs e)
        { 
            IWorkerView view = WorkerForm.GetInstace((MainForm)mainView);
            IModel model = new WorkerModel(new UnitOfWork(new SQLRepositoryAbstractFabric(connection)), "f");
            new WorkerPresenter(view, model);
        }
        private void ShowAdmin(object sender, EventArgs e)
        {
           
            AWarehousemanModel model = new WarehousemanModel(new UnitOfWork(new SQLRepositoryAbstractFabric(connection)));
            IEnumerable<WarehousemanLookCompose> personList = model.LookWarehousemanLook();
        }
    }
}
