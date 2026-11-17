using Desktop.Services;
using Microsoft.Reporting.WinForms;
using Services.Models;

namespace Desktop.Views
{
    public partial class SplashView : Form
    {
        bool dataReady = false;
        bool printReady = false;
        System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
        ProgressBar pbSplash = new ProgressBar();

        public SplashView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Splash";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Size = new Size(400, 200);
            pbSplash.Dock = DockStyle.Bottom;
            pbSplash.Height = 20;
            this.Controls.Add(pbSplash);
            timer1.Interval = 100;
            timer1.Tick += timer1_Tick;
        }

        private void timer1_Tick(object? sender, EventArgs e)
        {
            if (pbSplash.Value < 98)
                pbSplash.Increment(5);
            if (dataReady && printReady)
            {
                timer1.Enabled = false;
                this.Visible = false;
                var menuPrincipal = new MenuPrincipalView();
                menuPrincipal.ShowDialog();
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
                ClientesApiService clientesApiService = new();
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

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            SplashView_Activated(this, e);
        }
    }
}