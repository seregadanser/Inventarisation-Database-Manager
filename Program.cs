//#define Laptop


using DB_course.Presenter;
using DB_course.View;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.Extensions.Configuration;
using DB_course.tecknologicalUI;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace DB_course
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {

            var builder = new ConfigurationBuilder();
#if Laptop
            builder.SetBasePath("D:\\Study\\Test\\DB_course");
#else
                builder.SetBasePath("D:\\Labs\\DB_course");
#endif

            builder.AddJsonFile("jsconfig1.json");
            var config = builder.Build();
            string connectionString = "";
#if Laptop
            connectionString = config.GetConnectionString("LaptopConnection") ?? throw new Exception();
#else
                connectionString = config.GetConnectionString("DesktopConnection") ?? throw new Exception();
#endif


            IView view = null;
            ApplicationConfiguration.Initialize();
            if (args[0] == "Test")
            {
                view = new MainForm();
                new MainPresenter(view, connectionString);
            }
            else
            {
                if (args[0] == "TUI")
                    new AutoriseConsole(connectionString);
                else
                {
                    view = new UnLoginForm();
                    new UnLoginPresenter(view, connectionString);
                }
            }

            if (args[0] != "TUI")
                Application.Run((Form)view);


        }
    }
}