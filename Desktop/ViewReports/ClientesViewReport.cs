using Desktop.Services;
using Microsoft.Reporting.WinForms;
using System.Data;

namespace Desktop.ViewReports
{
    public partial class ClientesViewReport : Form
    {
        ClientesApiService clientesApiService = new();

        public ClientesViewReport()
        {
            InitializeComponent();
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
            reportViewer1.LocalReport.ReportEmbeddedResource = "Desktop.Reports.Clientes.rdlc";
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DSClientes", dt));
            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = ZoomMode.Percent;
            reportViewer1.ZoomPercent = 100;
            reportViewer1.RefreshReport();
        }
    }
}
