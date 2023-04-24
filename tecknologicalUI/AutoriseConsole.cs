using DB_course.Models;
using DB_course.Models.DBModels;
using DB_course.Presenter;
using DB_course.Repositories;
using DB_course.View;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace DB_course.tecknologicalUI
{
    public class AutoriseConsole
    {
        AUnLoginModel model;
        private readonly string sqlConnectionString;
        IConnection connection;
        ILoggerFactory loggerFactory =null;

        public AutoriseConsole(IConnection connection)
          {
            this.connection = connection;
            this.model = new UnLoginModel(new UnitOfWork(new SQLRepositoryAbstractFabric(connection)));

            CheckPerson();
        }
        public AutoriseConsole(IConnection connection, ILoggerFactory loggerFactory)
        {
            this.connection = connection;
            this.loggerFactory = loggerFactory;
            this.model = new UnLoginModel(new UnitOfWork(new SQLRepositoryAbstractFabric(connection)));
            model = new UnLoginModelLogDecorator(model, loggerFactory);

            CheckPerson();
        }

        private void CheckPerson()
        {
            Console.Write("Input Login: ");
            string login = Console.ReadLine();
            Console.Write("Input password: ");
            string password = Console.ReadLine();
            State a = State.INVALID;
            try
            {
                 a = model.Check(login, password);
            }
            catch { }
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

        }

        private void ShowHrView()
        {
            if(loggerFactory==null)
            new HRAdminConsole(connection);
            else
            new HRAdminConsole(connection, loggerFactory);
        }

        private void ShowWorkerView(string login)
        {
            if (loggerFactory == null)
                new WorkerConsole(connection, login);
            else
                new WorkerConsole(connection, login, loggerFactory);    
        }
        private void ShowAdmin()
        {
            if (loggerFactory == null)
                new WarehouseAdminConsole(connection);
            else
                new WarehouseAdminConsole(connection, loggerFactory);   
        }
    }
}
