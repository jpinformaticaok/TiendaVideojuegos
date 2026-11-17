using Desktop.Services;
using Microsoft.Reporting.WinForms;
using System.Data;

namespace Desktop.ViewReports
{
    public partial class ClientesViewReport : Form
    {
        ReportViewer _report;
        ClientesApiService clientesApiService = new();

        public ClientesViewReport()
        {
            InitializeComponent();
            _report = new ReportViewer();
            _report.Dock = DockStyle.Fill;
            this.Controls.Add(_report);
        }

        private void InitializeComponent()
        {
            this.Text = "Listado de Clientes";
            this.ClientSize = new Size(900, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Name = "ClientesViewReport";
            this.Load += ClientesViewReport_Load;
        }

        private async void ClientesViewReport_Load(object sender, EventArgs e)
        {
            var clientes = await clientesApiService.GetAllAsync();

            var dt = new DataTable("Clientes");
            dt.Columns.Add("id", typeof(string));
            dt.Columns.Add("Firstname", typeof(string));
            dt.Columns.Add("Lastname", typeof(string));
            dt.Columns.Add("Dni", typeof(string));
            dt.Columns.Add("Address", typeof(string));
            dt.Columns.Add("Localidad", typeof(string));

            if (clientes != null)
            {
                foreach (var c in clientes)
                {
                    dt.Rows.Add(
                        c.Id?.ToString() ?? string.Empty,
                        c.Firstname,
                        c.Lastname,
                        c.Dni,
                        c.Address,
                        c.Localidad?.Name ?? "Sin localidad"
                    );
                }
            }

            _report.LocalReport.ReportEmbeddedResource = "Desktop.Reports.Clientes.rdlc";
            _report.LocalReport.DataSources.Add(new ReportDataSource("DSClientes", dt));
            _report.SetDisplayMode(DisplayMode.PrintLayout);
            _report.ZoomMode = ZoomMode.Percent;
            _report.ZoomPercent = 100;
            _report.RefreshReport();
        }
    }
}