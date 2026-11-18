using DotNetEnv;

namespace Desktop
{
    /// <summary>
    /// Carga el archivo .env buscándolo desde la carpeta de la aplicación hacia arriba.
    /// Así funciona igual si se ejecuta desde Visual Studio, desde bin\Debug o con dotnet run.
    /// </summary>
    internal static class EnvConfig
    {
        private static bool cargado;

        public static void Cargar()
        {
            if (cargado) return;
            cargado = true;

            if (BuscarYCargar(AppContext.BaseDirectory)) return;
            BuscarYCargar(Directory.GetCurrentDirectory());
        }

        private static bool BuscarYCargar(string? rutaInicial)
        {
            if (string.IsNullOrWhiteSpace(rutaInicial)) return false;

            var directorio = new DirectoryInfo(rutaInicial);
            for (int i = 0; i < 6 && directorio != null; i++, directorio = directorio.Parent)
            {
                var archivo = Path.Combine(directorio.FullName, ".env");
                if (File.Exists(archivo))
                {
                    Env.Load(archivo);
                    return true;
                }
            }

            return false;
        }
    }
}
