using Microsoft.Reporting.WinForms;
using Services.Models;
using System.Data;

namespace Desktop.ViewReports
{
    public partial class VentaComprobanteViewReport : Form
    {
        private readonly Venta? venta;

        public VentaComprobanteViewReport()
        {
            InitializeComponent();
        }

        public VentaComprobanteViewReport(Venta venta) : this()
        {
            this.venta = venta;
        }

        private void VentaComprobanteViewReport_Load(object sender, EventArgs e)
        {
            if (venta == null) return;

            try
            {
                var cliente = venta.Cliente;

                var cabecera = new DataTable("VentaCabecera");
                cabecera.Columns.Add("Numero", typeof(string));
                cabecera.Columns.Add("Fecha", typeof(DateTime));
                cabecera.Columns.Add("Cliente", typeof(string));
                cabecera.Columns.Add("Dni", typeof(string));
                cabecera.Columns.Add("Direccion", typeof(string));
                cabecera.Columns.Add("Localidad", typeof(string));
                cabecera.Columns.Add("Provincia", typeof(string));
                cabecera.Columns.Add("Pais", typeof(string));
                cabecera.Columns.Add("Total", typeof(decimal));

                cabecera.Rows.Add(
                    venta.Number,
                    venta.Date.LocalDateTime,
                    cliente == null ? $"Cliente {venta.ClienteId}" : $"{cliente.Firstname} {cliente.Lastname}".Trim(),
                    cliente?.Dni ?? string.Empty,
                    cliente?.Address ?? string.Empty,
                    cliente?.Localidad ?? string.Empty,
                    cliente?.Provincia ?? string.Empty,
                    cliente?.Pais ?? string.Empty,
                    venta.Total);

                var detalle = new DataTable("VentaDetalle");
                detalle.Columns.Add("Linea", typeof(int));
                detalle.Columns.Add("Producto", typeof(string));
                detalle.Columns.Add("Cantidad", typeof(int));
                detalle.Columns.Add("Precio", typeof(decimal));
                detalle.Columns.Add("Subtotal", typeof(decimal));

                for (var i = 0; i < venta.Detalles.Count; i++)
                {
                    var linea = venta.Detalles[i];
                    detalle.Rows.Add(
                        i + 1,
                        linea.Producto?.Name ?? $"Producto {linea.ProductoId}",
                        linea.Quantity,
                        linea.UnitPrice,
                        linea.Subtotal);
                }

                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.ReportEmbeddedResource = "Desktop.Reports.VentaComprobante.rdlc";
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DSVentaCabecera", cabecera));
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DSVentaDetalle", detalle));
                reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.Percent;
                reportViewer1.ZoomPercent = 100;
                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo generar el comprobante: " + ex.Message, "Comprobante de venta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnImprimir_Click(object? sender, EventArgs e)
        {
            try
            {
                reportViewer1.PrintDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo abrir el dialogo de impresion: " + ex.Message, "Comprobante de venta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
