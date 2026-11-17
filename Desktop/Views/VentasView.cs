using Desktop.Services;
using Services.Models;

namespace Desktop.Views
{
    public partial class VentasView : Form
    {
        ClientesService clientesService = new ClientesService();
        ProductosService productosService = new ProductosService();
        VentasService ventasService = new VentasService();
        ComboBox cmbCliente = new ComboBox();
        ComboBox cmbProducto = new ComboBox();
        TextBox txtCantidad = new TextBox();
        Button btnAgregar = new Button();
        DataGridView gridItems = new DataGridView();
        Label lblTotal = new Label();
        Button btnGuardar = new Button();
        List<DetalleVenta> items = new List<DetalleVenta>();
        List<Producto> productos = new List<Producto>();

        public VentasView()
        {
            InitializeComponent();
            LoadData();
        }

        private void InitializeComponent()
        {
            this.Text = "Ventas";
            this.Size = new Size(700, 500);
            this.Controls.Add(new Label { Text = "Cliente", Left = 10, Top = 10, Width = 60 });
            cmbCliente.Left = 80; cmbCliente.Top = 8; cmbCliente.Width = 250; cmbCliente.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Controls.Add(cmbCliente);
            this.Controls.Add(new Label { Text = "Producto", Left = 10, Top = 40, Width = 60 });
            cmbProducto.Left = 80; cmbProducto.Top = 38; cmbProducto.Width = 250; cmbProducto.DropDownStyle = ComboBoxStyle.DropDownList;
            this.Controls.Add(cmbProducto);
            this.Controls.Add(new Label { Text = "Cantidad", Left = 340, Top = 40, Width = 60 });
            txtCantidad.Left = 410; txtCantidad.Top = 38; txtCantidad.Width = 60; txtCantidad.Text = "1";
            this.Controls.Add(txtCantidad);
            btnAgregar.Text = "Agregar"; btnAgregar.Left = 480; btnAgregar.Top = 36;
            btnAgregar.Click += (s, e) => AgregarItem();
            this.Controls.Add(btnAgregar);
            gridItems.Left = 10; gridItems.Top = 70; gridItems.Width = 660; gridItems.Height = 300;
            this.Controls.Add(gridItems);
            lblTotal.Left = 10; lblTotal.Top = 380; lblTotal.Width = 200; lblTotal.Text = "Total: 0";
            this.Controls.Add(lblTotal);
            btnGuardar.Text = "Guardar Venta"; btnGuardar.Left = 10; btnGuardar.Top = 410;
            btnGuardar.Click += async (s, e) => await GuardarVenta();
            this.Controls.Add(btnGuardar);
        }

        private async void LoadData()
        {
            var clientes = await clientesService.GetAllAsync();
            if (clientes != null)
            {
                cmbCliente.DisplayMember = "Firstname";
                cmbCliente.ValueMember = "Id";
                cmbCliente.DataSource = clientes;
            }
            productos = await productosService.GetAllAsync() ?? new List<Producto>();
            cmbProducto.DisplayMember = "Name";
            cmbProducto.ValueMember = "Id";
            cmbProducto.DataSource = productos;
            RefreshGrid();
        }

        private void AgregarItem()
        {
            if (cmbProducto.SelectedValue == null) return;
            var prod = productos.FirstOrDefault(p => p.Id == (int)cmbProducto.SelectedValue);
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

        private void RefreshGrid()
        {
            gridItems.DataSource = null;
            gridItems.DataSource = items.Select(i => new { Producto = i.Producto?.Name, i.Quantity, i.UnitPrice, i.Subtotal }).ToList();
            lblTotal.Text = "Total: " + items.Sum(i => i.Subtotal).ToString("C");
        }

        private async Task GuardarVenta()
        {
            if (cmbCliente.SelectedValue == null || items.Count == 0)
            {
                MessageBox.Show("Seleccione cliente y agregue productos.");
                return;
            }
            Venta venta = new Venta
            {
                ClienteId = (int)cmbCliente.SelectedValue,
                Detalles = items
            };
            bool ok = await ventasService.AddVentaAsync(venta);
            if (ok)
            {
                MessageBox.Show("Venta guardada: " + venta.Number);
                items.Clear();
                RefreshGrid();
            }
            else MessageBox.Show("Error al guardar la venta");
        }
    }
}