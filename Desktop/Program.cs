using Desktop.Views;
using DotNetEnv;
using Services;

namespace Desktop
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Env.Load("..//..//..//");
            Globales.ApiUrl = Environment.GetEnvironmentVariable("URLAPI");

            ApplicationConfiguration.Initialize();
            Application.Run(new SplashView());
        }
    }
}