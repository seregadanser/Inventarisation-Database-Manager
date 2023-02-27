using DB_course.Presenter;
using DB_course.View;

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
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            IMainView view = new MainForm();
            new MainPresenter(view, "");
            Application.Run((Form)view);

        }
    }
}