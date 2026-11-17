using Desktop.Services;
using Microsoft.Reporting.WinForms;
using System.Data;

namespace Desktop.ViewReports
{
    public partial class ProductosViewReport : Form
    {
        ReportViewer _report;
        ProductosService productosService = new();

        public ProductosViewReport()
        {
            InitializeComponent();
            _report = new ReportViewer();
            _report.Dock = DockStyle.Fill;
            this.Controls.Add(_report);
        }

        private void InitializeComponent()
        {
            this.Text = "Listado de Productos";
            this.ClientSize = new Size(900, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Name = "ProductosViewReport";
            this.Load += ProductosViewReport_Load;
        }

        private async void ProductosViewReport_Load(object sender, EventArgs e)
        {
            var productos = await productosService.GetAllAsync();

            var dt = new DataTable("Productos");
            dt.Columns.Add("id", typeof(string));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Description", typeof(string));
            dt.Columns.Add("Price", typeof(decimal));
            dt.Columns.Add("Stock", typeof(int));
            dt.Columns.Add("Platform", typeof(string));
            dt.Columns.Add("Format", typeof(string));

            if (productos != null)
            {
                foreach (var p in productos)
                {
                    dt.Rows.Add(
                        p.Id?.ToString() ?? string.Empty,
                        p.Name,
                        p.Description,
                        p.Price,
                        p.Stock,
                        p.Platform,
                        p.Format
                    );
                }
            }

            _report.LocalReport.ReportEmbeddedResource = "Desktop.Reports.Productos.rdlc";
            _report.LocalReport.DataSources.Add(new ReportDataSource("DSProductos", dt));
            _report.SetDisplayMode(DisplayMode.PrintLayout);
            _report.ZoomMode = ZoomMode.Percent;
            _report.ZoomPercent = 100;
            _report.RefreshReport();
        }
    }
}