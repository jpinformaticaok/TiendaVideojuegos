using Desktop.Services;
using Microsoft.Reporting.WinForms;
using Services.Models;

namespace Desktop.Views
{
    public partial class SplashView : Form
    {
        bool dataReady = false;
        bool printReady = false;

        private Label label1 = new Label();
        private PictureBox pictureBox1 = new PictureBox();
        private ProgressBar pbSplash = new ProgressBar();
        private System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();

        public SplashView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "SplashView";
            this.ClientSize = new Size(800, 450);
            this.BackColor = SystemColors.ActiveCaption;
            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Name = "SplashView";

            label1.AutoSize = true;
            label1.Font = new Font("Rockwell", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 109);
            label1.Name = "label1";
            label1.Size = new Size(414, 59);
            label1.Text = "Tienda Videojuegos";

            pictureBox1.Image = CrearImagenSplash();
            pictureBox1.Location = new Point(321, 90);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(478, 331);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabStop = false;

            pbSplash.Location = new Point(12, 369);
            pbSplash.Name = "pbSplash";
            pbSplash.Size = new Size(488, 52);
            pbSplash.Step = 20;

            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;

            this.Controls.Add(pbSplash);
            this.Controls.Add(label1);
            this.Controls.Add(pictureBox1);
            this.Activated += SplashView_Activated;
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