using Desktop.Services;
using Microsoft.Reporting.WinForms;
using Services.Models;
using System.Data;

namespace Desktop.ViewReports
{
    public partial class ProductosAgrupadosViewReport : Form
    {
        private readonly ProductosService productosService = new();
        private readonly PlataformasService plataformasService = new();
        private readonly FormatosService formatosService = new();
        private readonly TiposProductoService tiposService = new();

        private const string Todos = "Todos";

        public ProductosAgrupadosViewReport()
        {
            InitializeComponent();
        }

        private async void ProductosAgrupadosViewReport_Load(object sender, EventArgs e)
        {
            await CargarCombos();
            await GenerarReporte();
        }

        private async Task CargarCombos()
        {
            var plataformas = await plataformasService.GetAllAsync() ?? new List<Plataforma>();
            var formatos = await formatosService.GetAllAsync() ?? new List<Formato>();
            var tipos = await tiposService.GetAllAsync() ?? new List<TipoProducto>();

            cmbAgruparPor.Items.Clear();
            cmbAgruparPor.Items.Add("Plataforma");
            cmbAgruparPor.Items.Add("Formato");
            cmbAgruparPor.Items.Add("Tipo");
            cmbAgruparPor.SelectedIndex = 0;

            cmbPlataforma.Items.Clear();
            cmbPlataforma.Items.Add(Todos);
            foreach (var plataforma in plataformas.OrderBy(p => p.Name)) cmbPlataforma.Items.Add(plataforma.Name);
            cmbPlataforma.SelectedIndex = 0;

            cmbFormato.Items.Clear();
            cmbFormato.Items.Add(Todos);
            foreach (var formato in formatos.OrderBy(f => f.Name)) cmbFormato.Items.Add(formato.Name);
            cmbFormato.SelectedIndex = 0;

            cmbTipo.Items.Clear();
            cmbTipo.Items.Add(Todos);
            foreach (var tipo in tipos.OrderBy(t => t.Name)) cmbTipo.Items.Add(tipo.Name);
            cmbTipo.SelectedIndex = 0;
        }

        private async Task GenerarReporte()
        {
            try
            {
                var productos = await productosService.GetAllAsync() ?? new List<Producto>();
                var texto = txtBusqueda.Text.Trim();
                var plataforma = cmbPlataforma.SelectedItem as string ?? Todos;
                var formato = cmbFormato.SelectedItem as string ?? Todos;
                var tipo = cmbTipo.SelectedItem as string ?? Todos;
                var agruparPor = cmbAgruparPor.SelectedItem as string ?? "Plataforma";

                var filtrados = productos
                    .Where(p => string.IsNullOrWhiteSpace(texto)
                        || p.Name.Contains(texto, StringComparison.OrdinalIgnoreCase)
                        || p.Description.Contains(texto, StringComparison.OrdinalIgnoreCase))
                    .Where(p => plataforma == Todos || string.Equals(p.Plataforma?.Name, plataforma, StringComparison.OrdinalIgnoreCase))
                    .Where(p => formato == Todos || string.Equals(p.Formato?.Name, formato, StringComparison.OrdinalIgnoreCase))
                    .Where(p => tipo == Todos || string.Equals(p.TipoProducto?.Name, tipo, StringComparison.OrdinalIgnoreCase))
                    .Select(p => new
                    {
                        Producto = p,
                        Grupo = agruparPor switch
                        {
                            "Formato" => p.Formato?.Name ?? "Sin formato",
                            "Tipo" => p.TipoProducto?.Name ?? "Sin tipo",
                            _ => p.Plataforma?.Name ?? "Sin plataforma"
                        }
                    })
                    .OrderBy(x => x.Grupo)
                    .ThenBy(x => x.Producto.Name)
                    .ToList();

                var filtro = $"Agrupado por: {agruparPor} | Filtros: plataforma={plataforma}, formato={formato}, tipo={tipo}";
                if (!string.IsNullOrWhiteSpace(texto)) filtro += $", texto='{texto}'";
                filtro += $" | Resultados: {filtrados.Count}";

                var tabla = new DataTable("ProductosAgrupados");
                tabla.Columns.Add("Id", typeof(string));
                tabla.Columns.Add("Grupo", typeof(string));
                tabla.Columns.Add("GrupoTitulo", typeof(string));
                tabla.Columns.Add("Name", typeof(string));
                tabla.Columns.Add("Platform", typeof(string));
                tabla.Columns.Add("Tipo", typeof(string));
                tabla.Columns.Add("Format", typeof(string));
                tabla.Columns.Add("Price", typeof(decimal));
                tabla.Columns.Add("Stock", typeof(int));
                tabla.Columns.Add("Valor", typeof(decimal));
                tabla.Columns.Add("Filtro", typeof(string));

                foreach (var item in filtrados)
                {
                    var producto = item.Producto;
                    tabla.Rows.Add(
                        producto.Id?.ToString() ?? producto.Name,
                        item.Grupo,
                        $"{agruparPor.ToUpperInvariant()}: {item.Grupo}",
                        producto.Name,
                        producto.Plataforma?.Name ?? string.Empty,
                        producto.TipoProducto?.Name ?? string.Empty,
                        producto.Formato?.Name ?? string.Empty,
                        producto.Price,
                        producto.Stock,
                        producto.Price * producto.Stock,
                        filtro);
                }

                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.ReportEmbeddedResource = "Desktop.Reports.ProductosAgrupados.rdlc";
                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DSProductosAgrupados", tabla));
                reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
                reportViewer1.ZoomMode = ZoomMode.Percent;
                reportViewer1.ZoomPercent = 100;
                reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo generar el reporte: " + ex.Message, "Productos agrupados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnGenerar_Click(object? sender, EventArgs e)
        {
            await GenerarReporte();
        }

        private async void btnLimpiar_Click(object? sender, EventArgs e)
        {
            txtBusqueda.Text = string.Empty;
            if (cmbAgruparPor.Items.Count > 0) cmbAgruparPor.SelectedIndex = 0;
            if (cmbPlataforma.Items.Count > 0) cmbPlataforma.SelectedIndex = 0;
            if (cmbFormato.Items.Count > 0) cmbFormato.SelectedIndex = 0;
            if (cmbTipo.Items.Count > 0) cmbTipo.SelectedIndex = 0;
            await GenerarReporte();
        }
    }
}
