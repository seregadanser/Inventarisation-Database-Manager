#define Laptop

using DB_course.Presenter;
using DB_course.View;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.Extensions.Configuration;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace DB_course
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
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
                connectionString = config.GetConnectionString("DefaultConnection") ?? throw new Exception();
#endif

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            IMainView view = new MainForm();
            new MainPresenter(view, connectionString);
            Application.Run((Form)view);

        }
    }
}