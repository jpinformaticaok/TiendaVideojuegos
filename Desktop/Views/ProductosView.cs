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

        private List<TipoProducto> tipos = new List<TipoProducto>();

        public ProductosView()
        {
            InitializeComponent();
            LoadProductos();
            LoadTipos();
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

        private async void btnBuscar_Click(object? s, EventArgs e)
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

        private async void btnGuardar_Click(object? s, EventArgs e)
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

        private async void btnEliminar_Click(object? s, EventArgs e)
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
        private void dataGridProductos_SelectionChanged(object? sender, EventArgs e)
        {
            ShowImage();
        }

        private void btnTiposProducto_Click(object? sender, EventArgs e)
        {
            new TiposProductoView().ShowDialog();
        }

    }
}