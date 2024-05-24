<<<<<<< HEAD
namespace winforms_chat
=======
using ChessAI;

namespace winform_chat
>>>>>>> aeeec34513ef67722fa39c75a0bf65060db35545
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
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ApplicationConfiguration.Initialize();
<<<<<<< HEAD
            Application.Run(new SpawnClientAndServer());
=======
            Application.Run(new SpawnServerAndClient());
>>>>>>> aeeec34513ef67722fa39c75a0bf65060db35545
        }
    }
}