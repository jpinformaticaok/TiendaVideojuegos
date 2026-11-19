using Desktop.Services;
using FontAwesome.Sharp;
using Services.Models;

namespace Desktop.Views
{
    public partial class VentasView : Form
    {
        private ClientesService clientesService = new ClientesService();
        private ProductosService productosService = new ProductosService();
        private VentasService ventasService = new VentasService();


        // Pestaña Lista

        // Pestaña Nueva venta
        private List<DetalleVenta> items = new List<DetalleVenta>();
        private List<Producto> productos = new List<Producto>();
        private List<Venta> ventas = new List<Venta>();

        public VentasView()
        {
            InitializeComponent();
            LoadData();
        }

        

        private async void LoadData()
        {
            var clientes = await clientesService.GetAllAsync();
            if (clientes != null)
            {
                cmbCliente.DataSource = clientes;
            }
            productos = await productosService.GetAllAsync() ?? new List<Producto>();
            cmbProducto.DisplayMember = "Name";
            cmbProducto.DataSource = productos;
            RefreshGrid();
            await LoadVentas();
        }

        private async Task LoadVentas()
        {
            ventas = await ventasService.GetAllAsync() ?? new List<Venta>();
            gridVentas.DataSource = null;
            gridVentas.DataSource = ventas
                .Select(v => new
                {
                    Numero = v.Number,
                    Fecha = v.Date.LocalDateTime.ToString("dd/MM/yyyy HH:mm"),
                    Cliente = v.Cliente != null ? $"{v.Cliente.Firstname} {v.Cliente.Lastname}" : $"Cliente {v.ClienteId}",
                    v.Total
                })
                .ToList();

            if (gridVentas.Columns.Contains("Numero")) gridVentas.Columns["Numero"].HeaderText = "Número";
            if (gridVentas.Columns.Contains("Total"))
            {
                gridVentas.Columns["Total"].DefaultCellStyle.Format = "C0";
                gridVentas.Columns["Total"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            MostrarDetalle();
        }

        private void MostrarDetalle()
        {
            gridDetalle.DataSource = null;
            if (gridVentas.CurrentRow == null || gridVentas.CurrentRow.Index < 0 || gridVentas.CurrentRow.Index >= ventas.Count)
                return;

            var venta = ventas[gridVentas.CurrentRow.Index];
            gridDetalle.DataSource = venta.Detalles
                .Select(d => new
                {
                    Producto = d.Producto?.Name ?? $"Producto {d.ProductoId}",
                    Cantidad = d.Quantity,
                    Precio = d.UnitPrice,
                    d.Subtotal
                })
                .ToList();

            if (gridDetalle.Columns.Contains("Precio"))
            {
                gridDetalle.Columns["Precio"].DefaultCellStyle.Format = "C0";
                gridDetalle.Columns["Precio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            if (gridDetalle.Columns.Contains("Subtotal"))
            {
                gridDetalle.Columns["Subtotal"].DefaultCellStyle.Format = "C0";
                gridDetalle.Columns["Subtotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }

        private void AgregarItem()
        {
            var prod = cmbProducto.SelectedItem as Producto;
            if (prod == null) return;
            int qty = int.TryParse(txtCantidad.Text, out var q) ? q : 1;
            items.Add(new DetalleVenta
            {
                ProductoId = prod.Id ?? 0,
                Producto = prod,
                Quantity = qty,
                UnitPrice = prod.Price,
                Subtotal = qty * prod.Price
            });
            RefreshGrid();
        }

        private void QuitarItem()
        {
            if (gridItems.CurrentRow != null && gridItems.CurrentRow.Index < items.Count)
            {
                items.RemoveAt(gridItems.CurrentRow.Index);
                RefreshGrid();
            }
        }

        private void RefreshGrid()
        {
            gridItems.DataSource = null;
            gridItems.DataSource = items
                .Select(i => new
                {
                    Producto = i.Producto?.Name,
                    Cantidad = i.Quantity,
                    Precio = i.UnitPrice,
                    i.Subtotal
                })
                .ToList();

            if (gridItems.Columns.Contains("Precio"))
            {
                gridItems.Columns["Precio"].DefaultCellStyle.Format = "C0";
                gridItems.Columns["Precio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
            if (gridItems.Columns.Contains("Subtotal"))
            {
                gridItems.Columns["Subtotal"].DefaultCellStyle.Format = "C0";
                gridItems.Columns["Subtotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            lblTotal.Text = "Total: " + items.Sum(i => i.Subtotal).ToString("C");
        }

        private async Task GuardarVenta()
        {
            if (cmbCliente.SelectedItem is not Cliente cliente || items.Count == 0)
            {
                MessageBox.Show("Seleccione cliente y agregue productos.", "Ventas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Venta venta = new Venta
            {
                ClienteId = cliente.Id ?? 0,
                Detalles = items.ToList()
            };
            bool ok = await ventasService.AddVentaAsync(venta);
            if (ok)
            {
                MessageBox.Show("Venta guardada: " + venta.Number, "Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                items.Clear();
                RefreshGrid();
                await LoadVentas();
                tabControl.SelectedTab = tabPageLista;
            }
            else MessageBox.Show("Error al guardar la venta", "Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void gridVentas_SelectionChanged(object? sender, EventArgs e)
        {
            MostrarDetalle();
        }

        private async void btnActualizar_Click(object? sender, EventArgs e)
        {
            await LoadVentas();
        }

        private void btnAgregar_Click(object? sender, EventArgs e)
        {
            AgregarItem();
        }

        private void btnQuitar_Click(object? sender, EventArgs e)
        {
            QuitarItem();
        }

        private async void btnGuardar_Click(object? sender, EventArgs e)
        {
            await GuardarVenta();
        }

    }
}
