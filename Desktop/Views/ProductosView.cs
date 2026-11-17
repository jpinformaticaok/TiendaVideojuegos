using Desktop.Services;
using Services.Models;
using System.Net;

namespace Desktop.Views
{
    public partial class ProductosView : Form
    {
        ProductosService productosService = new ProductosService();
        TiposProductoService tiposService = new TiposProductoService();
        Producto? productoModificado;
        TabControl tabControl = new TabControl();
        TabPage tabPageLista = new TabPage("Lista");
        TabPage tabPageAgregarEditar = new TabPage("Agregar/Editar");
        DataGridView dataGridProductos = new DataGridView();
        TextBox txtBusqueda = new TextBox();
        Button btnBuscar = new Button();
        Button btnNuevo = new Button();
        Button btnModificar = new Button();
        Button btnEliminar = new Button();
        TextBox txtNombre = new TextBox();
        TextBox txtDescripcion = new TextBox();
        TextBox txtPrecio = new TextBox();
        TextBox txtStock = new TextBox();
        TextBox txtImagenUrl = new TextBox();
        ComboBox cmbTipo = new ComboBox();
        TextBox txtFormato = new TextBox();
        TextBox txtPlataforma = new TextBox();
        Button btnGuardar = new Button();
        Button btnCancelar = new Button();
        PictureBox picProducto = new PictureBox();

        public ProductosView()
        {
            InitializeComponent();
            LoadProductos();
            LoadTipos();
        }

        private void InitializeComponent()
        {
            this.Text = "Productos";
            this.Size = new Size(900, 600);
            tabControl.Dock = DockStyle.Fill;
            txtBusqueda.Left = 10; txtBusqueda.Top = 10; txtBusqueda.Width = 200;
            btnBuscar.Text = "Buscar"; btnBuscar.Left = 220; btnBuscar.Top = 8; btnBuscar.Click += async (s, e) => await btnBuscar_Click(s, e);
            dataGridProductos.Left = 10; dataGridProductos.Top = 40; dataGridProductos.Width = 600; dataGridProductos.Height = 400;
            dataGridProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridProductos.SelectionChanged += (s, e) => ShowImage();
            picProducto.Left = 620; picProducto.Top = 40; picProducto.Width = 120; picProducto.Height = 120;
            picProducto.SizeMode = PictureBoxSizeMode.Zoom;
            picProducto.BorderStyle = BorderStyle.FixedSingle;
            btnNuevo.Text = "Nuevo"; btnNuevo.Left = 10; btnNuevo.Top = 450; btnNuevo.Click += (s, e) => btnNuevo_Click(s, e);
            btnModificar.Text = "Modificar"; btnModificar.Left = 100; btnModificar.Top = 450; btnModificar.Click += (s, e) => btnModificar_Click(s, e);
            btnEliminar.Text = "Eliminar"; btnEliminar.Left = 200; btnEliminar.Top = 450; btnEliminar.Click += async (s, e) => await btnEliminar_Click(s, e);
            tabPageLista.Controls.AddRange(new Control[] { txtBusqueda, btnBuscar, dataGridProductos, picProducto, btnNuevo, btnModificar, btnEliminar });

            int y = 20;
            AddField(tabPageAgregarEditar, "Nombre", txtNombre, ref y);
            AddField(tabPageAgregarEditar, "Descripción", txtDescripcion, ref y);
            AddField(tabPageAgregarEditar, "Precio", txtPrecio, ref y);
            AddField(tabPageAgregarEditar, "Stock", txtStock, ref y);
            AddField(tabPageAgregarEditar, "Imagen URL", txtImagenUrl, ref y);
            tabPageAgregarEditar.Controls.Add(new Label { Text = "Tipo", Left = 10, Top = y, Width = 80 });
            cmbTipo.Left = 100; cmbTipo.Top = y; cmbTipo.Width = 200; cmbTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            tabPageAgregarEditar.Controls.Add(cmbTipo); y += 30;
            AddField(tabPageAgregarEditar, "Formato", txtFormato, ref y);
            AddField(tabPageAgregarEditar, "Plataforma", txtPlataforma, ref y);
            btnGuardar.Text = "Guardar"; btnGuardar.Left = 100; btnGuardar.Top = y; btnGuardar.Click += async (s, e) => await btnGuardar_Click(s, e);
            btnCancelar.Text = "Cancelar"; btnCancelar.Left = 200; btnCancelar.Top = y; btnCancelar.Click += (s, e) => btnCancelar_Click(s, e);
            tabPageAgregarEditar.Controls.AddRange(new Control[] { btnGuardar, btnCancelar });

            tabControl.TabPages.Add(tabPageLista);
            tabControl.TabPages.Add(tabPageAgregarEditar);
            this.Controls.Add(tabControl);
        }

        private void AddField(TabPage page, string label, TextBox txt, ref int y)
        {
            page.Controls.Add(new Label { Text = label, Left = 10, Top = y, Width = 80 });
            txt.Left = 100; txt.Top = y; txt.Width = 200;
            page.Controls.Add(txt);
            y += 30;
        }

        private async void LoadProductos()
        {
            var productos = await productosService.GetAllAsync();
            if (productos != null) dataGridProductos.DataSource = productos;
        }

        private async void LoadTipos()
        {
            var tipos = await tiposService.GetAllAsync();
            if (tipos != null)
            {
                cmbTipo.DisplayMember = "Name";
                cmbTipo.ValueMember = "Id";
                cmbTipo.DataSource = tipos;
            }
        }

        private async Task btnBuscar_Click(object? s, EventArgs e)
        {
            var productos = await productosService.GetAllWithFilterAsync(txtBusqueda.Text);
            if (productos != null) dataGridProductos.DataSource = productos;
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
                TipoProductoId = (int)(cmbTipo.SelectedValue ?? 0),
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
            txtNombre.Clear(); txtDescripcion.Clear(); txtPrecio.Clear(); txtStock.Clear();
            txtImagenUrl.Clear(); txtFormato.Clear(); txtPlataforma.Clear();
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
                if (productoModificado.TipoProductoId != 0) cmbTipo.SelectedValue = productoModificado.TipoProductoId;
                tabControl.SelectedTab = tabPageAgregarEditar;
            }
        }

        private async Task btnEliminar_Click(object? s, EventArgs e)
        {
            if (dataGridProductos.CurrentRow != null)
            {
                var p = (Producto)dataGridProductos.CurrentRow.DataBoundItem;
                var confirm = MessageBox.Show($"¿Eliminar producto {p.Name}?", "Confirmar", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    bool ok = await productosService.DeleteProductoAsync(p.Id);
                    if (ok) { MessageBox.Show("Eliminado"); LoadProductos(); }
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
    }
}