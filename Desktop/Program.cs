using Desktop.Views;
using Services;

namespace Desktop
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            EnvConfig.Cargar();
            Globales.ApiUrl = Environment.GetEnvironmentVariable("URLAPI");

            ApplicationConfiguration.Initialize();
            Application.Run(new SplashView());
        }
    }
}
