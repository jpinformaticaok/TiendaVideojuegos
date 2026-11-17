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

        private Label label1 = new Label();
        private Label label2 = new Label();
        private Label label3 = new Label();
        private Label label4 = new Label();
        private Label lblTotal = new Label();
        private ComboBox cmbCliente = new ComboBox();
        private ComboBox cmbProducto = new ComboBox();
        private TextBox txtCantidad = new TextBox();
        private IconButton btnAgregar = new IconButton();
        private IconButton btnQuitar = new IconButton();
        private IconButton btnGuardar = new IconButton();
        private DataGridView gridItems = new DataGridView();
        private List<DetalleVenta> items = new List<DetalleVenta>();
        private List<Producto> productos = new List<Producto>();

        public VentasView()
        {
            InitializeComponent();
            LoadData();
        }

        private void InitializeComponent()
        {
            this.Text = "Ventas";
            this.ClientSize = new Size(800, 450);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Name = "VentasView";

            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 9);
            label1.Text = "Facturación - Ventas";

            label2.AutoSize = true;
            label2.Location = new Point(12, 60);
            label2.Text = "Cliente";
            cmbCliente.Location = new Point(90, 56);
            cmbCliente.Name = "cmbCliente";
            cmbCliente.Size = new Size(300, 23);
            cmbCliente.DropDownStyle = ComboBoxStyle.DropDownList;

            label3.AutoSize = true;
            label3.Location = new Point(12, 100);
            label3.Text = "Producto";
            cmbProducto.Location = new Point(90, 96);
            cmbProducto.Name = "cmbProducto";
            cmbProducto.Size = new Size(300, 23);
            cmbProducto.DropDownStyle = ComboBoxStyle.DropDownList;

            label4.AutoSize = true;
            label4.Location = new Point(410, 100);
            label4.Text = "Cantidad";
            txtCantidad.Location = new Point(480, 96);
            txtCantidad.Name = "txtCantidad";
            txtCantidad.Size = new Size(60, 23);
            txtCantidad.Text = "1";

            btnAgregar.IconChar = IconChar.Plus;
            btnAgregar.IconColor = Color.Black;
            btnAgregar.IconFont = IconFont.Auto;
            btnAgregar.IconSize = 15;
            btnAgregar.ImageAlign = ContentAlignment.MiddleLeft;
            btnAgregar.Location = new Point(560, 95);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(90, 23);
            btnAgregar.Text = " Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += (s, e) => AgregarItem();

            btnQuitar.IconChar = IconChar.Trash;
            btnQuitar.IconColor = Color.Black;
            btnQuitar.IconFont = IconFont.Auto;
            btnQuitar.IconSize = 15;
            btnQuitar.ImageAlign = ContentAlignment.MiddleLeft;
            btnQuitar.Location = new Point(660, 95);
            btnQuitar.Name = "btnQuitar";
            btnQuitar.Size = new Size(90, 23);
            btnQuitar.Text = " Quitar";
            btnQuitar.UseVisualStyleBackColor = true;
            btnQuitar.Click += (s, e) => QuitarItem();

            gridItems.AllowUserToAddRows = false;
            gridItems.AllowUserToDeleteRows = false;
            gridItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridItems.Location = new Point(12, 140);
            gridItems.Name = "gridItems";
            gridItems.ReadOnly = true;
            gridItems.Size = new Size(760, 230);

            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotal.Location = new Point(12, 385);
            lblTotal.Text = "Total: 0";

            btnGuardar.IconChar = IconChar.Save;
            btnGuardar.IconColor = Color.Black;
            btnGuardar.IconFont = IconFont.Auto;
            btnGuardar.IconSize = 15;
            btnGuardar.ImageAlign = ContentAlignment.MiddleLeft;
            btnGuardar.Location = new Point(640, 380);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(132, 30);
            btnGuardar.Text = "Guardar Venta";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += async (s, e) => await GuardarVenta();

            this.Controls.Add(label1);
            this.Controls.Add(label2);
            this.Controls.Add(cmbCliente);
            this.Controls.Add(label3);
            this.Controls.Add(cmbProducto);
            this.Controls.Add(label4);
            this.Controls.Add(txtCantidad);
            this.Controls.Add(btnAgregar);
            this.Controls.Add(btnQuitar);
            this.Controls.Add(gridItems);
            this.Controls.Add(lblTotal);
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