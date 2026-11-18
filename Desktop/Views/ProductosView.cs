using Desktop.Services;
using FontAwesome.Sharp;
using Services.Models;
using System.Net;

namespace Desktop.Views
{
    public partial class ProductosView : Form
    {
        private ProductosService productosService = new ProductosService();
        private TiposProductoService tiposService = new TiposProductoService();
        private Producto? productoModificado;

        private Label label1 = new Label();
        private TabControl tabControl = new TabControl();
        private TabPage tabPageLista = new TabPage();
        private TabPage tabPageAgregarEditar = new TabPage();
        private DataGridView dataGridProductos = new DataGridView();
        private TextBox txtBusqueda = new TextBox();
        private Label label2 = new Label();
        private IconButton btnBuscar = new IconButton();
        private IconButton btnNuevo = new IconButton();
        private IconButton btnModificar = new IconButton();
        private IconButton btnEliminar = new IconButton();
        private IconButton btnGuardar = new IconButton();
        private IconButton btnCancelar = new IconButton();
        private TextBox txtNombre = new TextBox();
        private TextBox txtDescripcion = new TextBox();
        private TextBox txtPrecio = new TextBox();
        private TextBox txtStock = new TextBox();
        private TextBox txtImagenUrl = new TextBox();
        private ComboBox cmbTipo = new ComboBox();
        private List<TipoProducto> tipos = new List<TipoProducto>();
        private TextBox txtFormato = new TextBox();
        private TextBox txtPlataforma = new TextBox();
        private Label label3 = new Label();
        private Label label4 = new Label();
        private Label label5 = new Label();
        private Label label6 = new Label();
        private Label label7 = new Label();
        private Label label8 = new Label();
        private Label label9 = new Label();
        private Label label10 = new Label();
        private PictureBox picProducto = new PictureBox();
        private Button btnTiposProducto = new Button();

        public ProductosView()
        {
            InitializeComponent();
            LoadProductos();
            LoadTipos();
        }

        private void InitializeComponent()
        {
            this.Text = "Productos";
            this.ClientSize = new Size(800, 450);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Name = "ProductosView";

            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 9);
            label1.Text = "CRUD - Productos";

            tabControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl.Controls.Add(tabPageLista);
            tabControl.Controls.Add(tabPageAgregarEditar);
            tabControl.Location = new Point(12, 59);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(776, 379);

            tabPageLista.Text = "Lista";
            tabPageLista.UseVisualStyleBackColor = true;

            label2.AutoSize = true;
            label2.Location = new Point(6, 21);
            label2.Text = "Buscar";

            txtBusqueda.Location = new Point(54, 21);
            txtBusqueda.Name = "txtBusqueda";
            txtBusqueda.Size = new Size(578, 23);
            txtBusqueda.KeyPress += txtBusqueda_KeyPress;

            btnBuscar.IconChar = IconChar.Search;
            btnBuscar.IconColor = Color.Black;
            btnBuscar.IconFont = IconFont.Auto;
            btnBuscar.IconSize = 15;
            btnBuscar.ImageAlign = ContentAlignment.MiddleLeft;
            btnBuscar.Location = new Point(665, 21);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(75, 23);
            btnBuscar.Text = "   Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += async (s, e) => await btnBuscar_Click(s, e);

            dataGridProductos.AllowUserToAddRows = false;
            dataGridProductos.AllowUserToDeleteRows = false;
            dataGridProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridProductos.Location = new Point(6, 59);
            dataGridProductos.Name = "dataGridProductos";
            dataGridProductos.ReadOnly = true;
            dataGridProductos.Size = new Size(626, 286);
            dataGridProductos.SelectionChanged += (s, e) => ShowImage();

            picProducto.Location = new Point(642, 59);
            picProducto.Name = "picProducto";
            picProducto.Size = new Size(120, 120);
            picProducto.SizeMode = PictureBoxSizeMode.Zoom;
            picProducto.BorderStyle = BorderStyle.FixedSingle;

            btnNuevo.IconChar = IconChar.Plus;
            btnNuevo.IconColor = Color.Black;
            btnNuevo.IconFont = IconFont.Auto;
            btnNuevo.IconSize = 15;
            btnNuevo.ImageAlign = ContentAlignment.MiddleLeft;
            btnNuevo.Location = new Point(642, 190);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(98, 23);
            btnNuevo.Text = " Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += (s, e) => btnNuevo_Click(s, e);

            btnModificar.IconChar = IconChar.Pen;
            btnModificar.IconColor = Color.Black;
            btnModificar.IconFont = IconFont.Auto;
            btnModificar.IconSize = 15;
            btnModificar.ImageAlign = ContentAlignment.MiddleLeft;
            btnModificar.Location = new Point(642, 228);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(98, 23);
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += (s, e) => btnModificar_Click(s, e);

            btnEliminar.IconChar = IconChar.Trash;
            btnEliminar.IconColor = Color.Black;
            btnEliminar.IconFont = IconFont.Auto;
            btnEliminar.IconSize = 15;
            btnEliminar.ImageAlign = ContentAlignment.MiddleLeft;
            btnEliminar.Location = new Point(642, 266);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(98, 23);
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += async (s, e) => await btnEliminar_Click(s, e);

            btnTiposProducto.Location = new Point(642, 304);
            btnTiposProducto.Name = "btnTiposProducto";
            btnTiposProducto.Size = new Size(98, 23);
            btnTiposProducto.Text = "Tipos";
            btnTiposProducto.UseVisualStyleBackColor = true;
            btnTiposProducto.Click += (s, e) => new TiposProductoView().ShowDialog();

            tabPageLista.Controls.Add(btnTiposProducto);
            tabPageLista.Controls.Add(btnEliminar);
            tabPageLista.Controls.Add(btnModificar);
            tabPageLista.Controls.Add(btnNuevo);
            tabPageLista.Controls.Add(picProducto);
            tabPageLista.Controls.Add(btnBuscar);
            tabPageLista.Controls.Add(txtBusqueda);
            tabPageLista.Controls.Add(label2);
            tabPageLista.Controls.Add(dataGridProductos);

            tabPageAgregarEditar.Text = "Agregar / Editar";
            tabPageAgregarEditar.UseVisualStyleBackColor = true;

            int y = 30;
            label3.AutoSize = true; label3.Location = new Point(40, y); label3.Text = "Nombre";
            txtNombre.Location = new Point(120, y - 7); txtNombre.Name = "txtNombre"; txtNombre.Size = new Size(513, 23);
            y += 40;
            label4.AutoSize = true; label4.Location = new Point(40, y); label4.Text = "Descripción";
            txtDescripcion.Location = new Point(120, y - 7); txtDescripcion.Name = "txtDescripcion"; txtDescripcion.Size = new Size(513, 23);
            y += 40;
            label5.AutoSize = true; label5.Location = new Point(40, y); label5.Text = "Precio";
            txtPrecio.Location = new Point(120, y - 7); txtPrecio.Name = "txtPrecio"; txtPrecio.Size = new Size(513, 23);
            y += 40;
            label6.AutoSize = true; label6.Location = new Point(40, y); label6.Text = "Stock";
            txtStock.Location = new Point(120, y - 7); txtStock.Name = "txtStock"; txtStock.Size = new Size(513, 23);
            y += 40;
            label7.AutoSize = true; label7.Location = new Point(40, y); label7.Text = "Imagen URL";
            txtImagenUrl.Location = new Point(120, y - 7); txtImagenUrl.Name = "txtImagenUrl"; txtImagenUrl.Size = new Size(513, 23);
            y += 40;
            label8.AutoSize = true; label8.Location = new Point(40, y); label8.Text = "Tipo";
            cmbTipo.Location = new Point(120, y - 7); cmbTipo.Name = "cmbTipo"; cmbTipo.Size = new Size(513, 23); cmbTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            y += 40;
            label9.AutoSize = true; label9.Location = new Point(40, y); label9.Text = "Formato";
            txtFormato.Location = new Point(120, y - 7); txtFormato.Name = "txtFormato"; txtFormato.Size = new Size(513, 23);
            y += 40;
            label10.AutoSize = true; label10.Location = new Point(40, y); label10.Text = "Plataforma";
            txtPlataforma.Location = new Point(120, y - 7); txtPlataforma.Name = "txtPlataforma"; txtPlataforma.Size = new Size(513, 23);

            btnGuardar.IconChar = IconChar.Save;
            btnGuardar.IconColor = Color.Black;
            btnGuardar.IconFont = IconFont.Auto;
            btnGuardar.IconSize = 15;
            btnGuardar.ImageAlign = ContentAlignment.MiddleLeft;
            btnGuardar.Location = new Point(674, 87);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 23);
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += async (s, e) => await btnGuardar_Click(s, e);

            btnCancelar.IconChar = IconChar.Cancel;
            btnCancelar.IconColor = Color.Black;
            btnCancelar.IconFont = IconFont.Auto;
            btnCancelar.IconSize = 15;
            btnCancelar.ImageAlign = ContentAlignment.MiddleLeft;
            btnCancelar.Location = new Point(674, 182);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += (s, e) => btnCancelar_Click(s, e);

            tabPageAgregarEditar.Controls.AddRange(new Control[]
            {
                label3, txtNombre, label4, txtDescripcion, label5, txtPrecio, label6, txtStock,
                label7, txtImagenUrl, label8, cmbTipo, label9, txtFormato, label10, txtPlataforma,
                btnGuardar, btnCancelar
            });

            this.Controls.Add(tabControl);
            this.Controls.Add(label1);
        }

        private async void LoadProductos()
        {
            var productos = await productosService.GetAllAsync();
            if (productos != null)
            {
                dataGridProductos.DataSource = productos;
                AjustarColumnas();
            }
        }

        private void AjustarColumnas()
        {
            // La imagen se muestra en el PictureBox, no hace falta la URL ni la navegación en la grilla
            foreach (var columna in new[] { "ImageUrl", "TipoProducto", "TipoProductoId", "isDeleted" })
                if (dataGridProductos.Columns.Contains(columna))
                    dataGridProductos.Columns[columna].Visible = false;
        }

        private async void LoadTipos()
        {
            var tiposDb = await tiposService.GetAllAsync();
            if (tiposDb != null)
            {
                tipos = tiposDb;
                cmbTipo.DataSource = null;
                cmbTipo.DataSource = tipos;
            }
        }

        private async Task btnBuscar_Click(object? s, EventArgs e)
        {
            var productos = await productosService.GetAllWithFilterAsync(txtBusqueda.Text);
            if (productos != null)
            {
                dataGridProductos.DataSource = productos;
                AjustarColumnas();
            }
        }

        private void btnNuevo_Click(object? s, EventArgs e)
        {
            tabControl.SelectedTab = tabPageAgregarEditar;
            productoModificado = null;
            ClearFields();
        }

        private void btnCancelar_Click(object? s, EventArgs e)
        {
            tabControl.SelectedTab = tabPageLista;
            ClearFields();
            productoModificado = null;
        }

        private async Task btnGuardar_Click(object? s, EventArgs e)
        {
            Producto producto = new Producto
            {
                Name = txtNombre.Text,
                Description = txtDescripcion.Text,
                Price = decimal.TryParse(txtPrecio.Text, out var p) ? p : 0,
                Stock = int.TryParse(txtStock.Text, out var st) ? st : 0,
                ImageUrl = txtImagenUrl.Text,
                TipoProductoId = cmbTipo.SelectedItem is TipoProducto tipo ? tipo.Id : 0,
                Format = txtFormato.Text,
                Platform = txtPlataforma.Text,
            };
            bool ok;
            if (productoModificado == null)
                ok = await productosService.AddProductoAsync(producto);
            else
            {
                producto.Id = productoModificado.Id;
                producto.Created_at = productoModificado.Created_at;
                ok = await productosService.UpdateProductoAsync(producto);
            }

            if (ok)
            {
                MessageBox.Show("Producto guardado correctamente");
                LoadProductos();
                ClearFields();
                tabControl.SelectedTab = tabPageLista;
            }
            else MessageBox.Show("Error al guardar el producto");
        }

        private void ClearFields()
        {
            txtNombre.Clear();
            txtDescripcion.Clear();
            txtPrecio.Clear();
            txtStock.Clear();
            txtImagenUrl.Clear();
            txtFormato.Clear();
            txtPlataforma.Clear();
        }

        private void btnModificar_Click(object? s, EventArgs e)
        {
            if (dataGridProductos.CurrentRow != null)
            {
                productoModificado = (Producto)dataGridProductos.CurrentRow.DataBoundItem;
                txtNombre.Text = productoModificado.Name;
                txtDescripcion.Text = productoModificado.Description;
                txtPrecio.Text = productoModificado.Price.ToString();
                txtStock.Text = productoModificado.Stock.ToString();
                txtImagenUrl.Text = productoModificado.ImageUrl;
                txtFormato.Text = productoModificado.Format;
                txtPlataforma.Text = productoModificado.Platform;
                var tipo = tipos.FirstOrDefault(t => t.Id == productoModificado.TipoProductoId);
                if (tipo != null) cmbTipo.SelectedItem = tipo;
                tabControl.SelectedTab = tabPageAgregarEditar;
            }
        }

        private async Task btnEliminar_Click(object? s, EventArgs e)
        {
            if (dataGridProductos.CurrentRow != null)
            {
                var p = (Producto)dataGridProductos.CurrentRow.DataBoundItem;
                var confirm = MessageBox.Show($"¿Está seguro de eliminar el producto {p.Name}?", "Confirmar eliminación", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    bool ok = await productosService.DeleteProductoAsync(p.Id);
                    if (ok)
                    {
                        MessageBox.Show("Producto eliminado");
                        LoadProductos();
                    }
                }
            }
        }

        private void ShowImage()
        {
            if (dataGridProductos.CurrentRow != null)
            {
                var p = (Producto)dataGridProductos.CurrentRow.DataBoundItem;
                if (!string.IsNullOrWhiteSpace(p.ImageUrl))
                {
                    try
                    {
                        using var wc = new WebClient();
                        var bytes = wc.DownloadData(p.ImageUrl);
                        using var ms = new MemoryStream(bytes);
                        picProducto.Image = Image.FromStream(ms);
                    }
                    catch { picProducto.Image = null; }
                }
                else picProducto.Image = null;
            }
        }

        private void txtBusqueda_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnBuscar.PerformClick();
                e.Handled = true;
            }
        }
    }
}