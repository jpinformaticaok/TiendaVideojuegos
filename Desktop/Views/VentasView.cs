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
        private TabControl tabControl = new TabControl();
        private TabPage tabPageLista = new TabPage();
        private TabPage tabPageNueva = new TabPage();

        // Pestaña Lista
        private DataGridView gridVentas = new DataGridView();
        private DataGridView gridDetalle = new DataGridView();
        private IconButton btnActualizar = new IconButton();
        private Label labelDetalle = new Label();

        // Pestaña Nueva venta
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
        private List<Venta> ventas = new List<Venta>();

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
            label1.Name = "label1";
            label1.Text = "Facturación - Ventas";

            tabControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl.Controls.Add(tabPageLista);
            tabControl.Controls.Add(tabPageNueva);
            tabControl.Location = new Point(12, 59);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(776, 379);

            // ---------- Pestaña Lista ----------
            tabPageLista.Text = "Lista";
            tabPageLista.UseVisualStyleBackColor = true;

            gridVentas.AllowUserToAddRows = false;
            gridVentas.AllowUserToDeleteRows = false;
            gridVentas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridVentas.Location = new Point(6, 6);
            gridVentas.Name = "gridVentas";
            gridVentas.ReadOnly = true;
            gridVentas.Size = new Size(734, 190);
            gridVentas.SelectionChanged += (s, e) => MostrarDetalle();

            labelDetalle.AutoSize = true;
            labelDetalle.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelDetalle.Location = new Point(6, 205);
            labelDetalle.Name = "labelDetalle";
            labelDetalle.Text = "Detalle de la factura seleccionada";

            gridDetalle.AllowUserToAddRows = false;
            gridDetalle.AllowUserToDeleteRows = false;
            gridDetalle.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridDetalle.Location = new Point(6, 230);
            gridDetalle.Name = "gridDetalle";
            gridDetalle.ReadOnly = true;
            gridDetalle.Size = new Size(734, 110);

            btnActualizar.IconChar = IconChar.Rotate;
            btnActualizar.IconColor = Color.Black;
            btnActualizar.IconFont = IconFont.Auto;
            btnActualizar.IconSize = 15;
            btnActualizar.ImageAlign = ContentAlignment.MiddleLeft;
            btnActualizar.Location = new Point(650, 343);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(90, 23);
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += async (s, e) => await LoadVentas();

            tabPageLista.Controls.Add(gridDetalle);
            tabPageLista.Controls.Add(labelDetalle);
            tabPageLista.Controls.Add(btnActualizar);
            tabPageLista.Controls.Add(gridVentas);

            // ---------- Pestaña Nueva venta ----------
            tabPageNueva.Text = "Nueva Venta";
            tabPageNueva.UseVisualStyleBackColor = true;

            label2.AutoSize = true;
            label2.Location = new Point(12, 21);
            label2.Text = "Cliente";
            cmbCliente.Location = new Point(90, 17);
            cmbCliente.Name = "cmbCliente";
            cmbCliente.Size = new Size(300, 23);
            cmbCliente.DropDownStyle = ComboBoxStyle.DropDownList;

            label3.AutoSize = true;
            label3.Location = new Point(12, 61);
            label3.Text = "Producto";
            cmbProducto.Location = new Point(90, 57);
            cmbProducto.Name = "cmbProducto";
            cmbProducto.Size = new Size(300, 23);
            cmbProducto.DropDownStyle = ComboBoxStyle.DropDownList;

            label4.AutoSize = true;
            label4.Location = new Point(410, 61);
            label4.Text = "Cantidad";
            txtCantidad.Location = new Point(480, 57);
            txtCantidad.Name = "txtCantidad";
            txtCantidad.Size = new Size(60, 23);
            txtCantidad.Text = "1";

            btnAgregar.IconChar = IconChar.Plus;
            btnAgregar.IconColor = Color.Black;
            btnAgregar.IconFont = IconFont.Auto;
            btnAgregar.IconSize = 15;
            btnAgregar.ImageAlign = ContentAlignment.MiddleLeft;
            btnAgregar.Location = new Point(560, 56);
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
            btnQuitar.Location = new Point(656, 56);
            btnQuitar.Name = "btnQuitar";
            btnQuitar.Size = new Size(90, 23);
            btnQuitar.Text = " Quitar";
            btnQuitar.UseVisualStyleBackColor = true;
            btnQuitar.Click += (s, e) => QuitarItem();

            gridItems.AllowUserToAddRows = false;
            gridItems.AllowUserToDeleteRows = false;
            gridItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridItems.Location = new Point(12, 100);
            gridItems.Name = "gridItems";
            gridItems.ReadOnly = true;
            gridItems.Size = new Size(734, 200);

            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotal.Location = new Point(12, 320);
            lblTotal.Text = "Total: 0";

            btnGuardar.IconChar = IconChar.Save;
            btnGuardar.IconColor = Color.Black;
            btnGuardar.IconFont = IconFont.Auto;
            btnGuardar.IconSize = 15;
            btnGuardar.ImageAlign = ContentAlignment.MiddleLeft;
            btnGuardar.Location = new Point(620, 315);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(132, 30);
            btnGuardar.Text = "Guardar Venta";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += async (s, e) => await GuardarVenta();

            tabPageNueva.Controls.Add(label2);
            tabPageNueva.Controls.Add(cmbCliente);
            tabPageNueva.Controls.Add(label3);
            tabPageNueva.Controls.Add(cmbProducto);
            tabPageNueva.Controls.Add(label4);
            tabPageNueva.Controls.Add(txtCantidad);
            tabPageNueva.Controls.Add(btnAgregar);
            tabPageNueva.Controls.Add(btnQuitar);
            tabPageNueva.Controls.Add(gridItems);
            tabPageNueva.Controls.Add(lblTotal);
            tabPageNueva.Controls.Add(btnGuardar);

            this.Controls.Add(tabControl);
            this.Controls.Add(label1);
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
    }
}
