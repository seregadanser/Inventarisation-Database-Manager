#define Laptop


using DB_course.Presenter;
using DB_course.View;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.Extensions.Configuration;
using DB_course.tecknologicalUI;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Microsoft.Extensions.Logging;
using DB_course.Models.DBModels;
using DB_course.Models;
using Microsoft.EntityFrameworkCore;

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
            string p = "";
#if Laptop
           p ="D:\\Study\\Test\\DB_course";
#else
           p ="D:\\Labs\\DB_course";
#endif

            var configuration = new ConfigurationBuilder().SetBasePath(p).AddJsonFile("logconfig.json").Build();
            ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
            //builder.AddConsole().AddConfiguration(configuration.GetSection("Logging")));
              builder.AddFile(Path.Combine(Directory.GetCurrentDirectory(), "logger.txt")).AddConfiguration(configuration.GetSection("Logging")));
            var builder = new ConfigurationBuilder();
#if Laptop
            builder.SetBasePath("D:\\Study\\Test\\DB_course");
#else
            builder.SetBasePath("D:\\Labs\\DB_course");
#endif
            builder.AddJsonFile("connstring.json");
            var config = builder.Build();
            string connectionString = "";
#if Laptop
            connectionString = config.GetConnectionString("unlogin:LaptopConnection") ?? throw new Exception();
#else
            connectionString = config.GetConnectionString("unlogin:DesktopConnection")?? throw new Exception();
#endif
            var optionsBuilder = new DbContextOptionsBuilder<WarehouseContext>();
            var options = optionsBuilder.UseSqlServer(connectionString).Options;
            IConnection connection = new WarehouseContext(options);


            IView view = null;
            ApplicationConfiguration.Initialize();
            if (args[0] == "Test")
            {
                view = new MainForm();
                new MainPresenter(view, connectionString);
            }

            if (args[0] == "TUI")
                new AutoriseConsole(connection, loggerFactory);

            if (args[0] == "work")
            {
                view = new UnLoginForm();
                new UnLoginPresenter(view, connectionString);
            }


            if (args[0] != "TUI")
                Application.Run((Form)view);


        }
    }
}