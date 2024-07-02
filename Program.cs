using System.Threading;

namespace DailyProgress;

static class Program
{
    static readonly DailyProgressForm form = new();

    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(form);
    }    
}
