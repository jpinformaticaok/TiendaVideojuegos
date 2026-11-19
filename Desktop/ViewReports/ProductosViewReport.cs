using Desktop.Services;
using Microsoft.Reporting.WinForms;
using System.Data;

namespace Desktop.ViewReports
{
    public partial class ProductosViewReport : Form
    {
        ProductosService productosService = new();

        public ProductosViewReport()
        {
            InitializeComponent();
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
            reportViewer1.LocalReport.ReportEmbeddedResource = "Desktop.Reports.Productos.rdlc";
            reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DSProductos", dt));
            reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            reportViewer1.ZoomMode = ZoomMode.Percent;
            reportViewer1.ZoomPercent = 100;
            reportViewer1.RefreshReport();
        }
    }
}
