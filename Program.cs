using System.Threading;

namespace DailyProgress;

static class Program
{

    static DailyProgressForm form = new DailyProgressForm();

    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        Application.Run(form);
    }    

    static void SpawnForm() {
    }
}