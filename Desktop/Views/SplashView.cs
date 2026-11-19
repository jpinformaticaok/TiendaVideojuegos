using Desktop.Services;
using Microsoft.Reporting.WinForms;
using Services.Models;

namespace Desktop.Views
{
    public partial class SplashView : Form
    {
        bool dataReady = false;
        bool printReady = false;


        public SplashView()
        {
            InitializeComponent();
            pictureBox1.Image = CrearImagenSplash();
        }

        

        private Image CrearImagenSplash()
        {
            var bmp = new Bitmap(478, 331);
            using (var g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.FromArgb(30, 30, 50));
                using var brush = new SolidBrush(Color.FromArgb(120, 180, 255));
                using var font = new Font("Segoe UI", 34F, FontStyle.Bold);
                using var font2 = new Font("Segoe UI", 18F, FontStyle.Regular);
                var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                g.DrawString("VIDEOJUEGOS", font, brush, new RectangleF(0, 80, 478, 80), sf);
                g.DrawString("Consolas · Juegos · Suscripciones", font2, Brushes.White, new RectangleF(0, 170, 478, 60), sf);
                using var pen = new Pen(Color.FromArgb(120, 180, 255), 4);
                g.DrawRectangle(pen, 120, 250, 238, 40);
            }
            return bmp;
        }

        private void timer1_Tick(object? sender, EventArgs e)
        {
            if (pbSplash.Value < 98)
                pbSplash.Increment(5);
            if (dataReady && printReady)
            {
                timer1.Enabled = false;
                pbSplash.Value = 100;
                this.Visible = false;

                // Después del splash se muestra la pantalla de inicio de sesión.
                var login = new IniciarSesionView();
                if (login.ShowDialog() == DialogResult.OK)
                {
                    var menuPrincipal = new MenuPrincipalView();
                    menuPrincipal.ShowDialog();
                }

                this.Close();
            }
        }

        private async void SplashView_Activated(object? sender, EventArgs e)
        {
            timer1.Enabled = true;
            var dataTask = LoadData();
            var printTask = PrintReport();
            await Task.WhenAll(dataTask, printTask);
        }

        private async Task LoadData()
        {
            await Task.Run(() =>
            {
                ClientesApiService clientesApiService = new();
                var clientes = clientesApiService.GetAllAsync().Result;
                dataReady = true;
            });
        }

        private async Task PrintReport()
        {
            await Task.Run(() =>
            {
                ReportViewer _report = new ReportViewer();
                var clientes = new List<Cliente>
                {
                    new Cliente { Id = 1, Firstname = "Juan", Lastname = "Pérez", Address = "Calle Falsa 1233", Dni = "29720301" }
                };
                _report.LocalReport.ReportEmbeddedResource = "Desktop.Reports.Clientes.rdlc";
                _report.LocalReport.DataSources.Add(new ReportDataSource("DSClientes", clientes));
                _report.SetDisplayMode(DisplayMode.PrintLayout);
                _report.ZoomMode = ZoomMode.Percent;
                _report.ZoomPercent = 100;
                _report.RefreshReport();
                printReady = true;
            });
        }
    }
}