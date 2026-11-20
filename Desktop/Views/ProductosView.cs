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
        private PlataformasService plataformasService = new PlataformasService();
        private FormatosService formatosService = new FormatosService();
        private Producto? productoModificado;

        private List<Producto> productos = new List<Producto>();
        private List<TipoProducto> tipos = new List<TipoProducto>();
        private List<Plataforma> plataformas = new List<Plataforma>();
        private List<Formato> formatos = new List<Formato>();
        private bool cargandoCombos;

        public ProductosView()
        {
            InitializeComponent();
            LoadProductos();
            LoadTipos();
            LoadPlataformas();
            LoadFormatos();
        }



        private async void LoadProductos()
        {
            var productosDb = await productosService.GetAllAsync();
            if (productosDb != null)
            {
                productos = productosDb;
                AplicarFiltros();
            }
        }

        private void AjustarColumnas()
        {
            // La imagen se muestra en el PictureBox; los IDs y las navegaciones de tipo no van en la grilla
            foreach (var columna in new[] { "ImageUrl", "TipoProducto", "TipoProductoId", "PlataformaId", "FormatoId", "isDeleted" })
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

        private async void LoadPlataformas()
        {
            var plataformasDb = await plataformasService.GetAllAsync();
            if (plataformasDb == null) return;

            plataformas = plataformasDb;
            cmbPlataforma.DataSource = null;
            cmbPlataforma.DataSource = plataformas;

            cargandoCombos = true;
            cmbFiltroPlataforma.Items.Clear();
            cmbFiltroPlataforma.Items.Add("Todos");
            foreach (var plataforma in plataformas) cmbFiltroPlataforma.Items.Add(plataforma.Name);
            cmbFiltroPlataforma.SelectedIndex = 0;
            cargandoCombos = false;

            AplicarFiltros();
        }

        private async void LoadFormatos()
        {
            var formatosDb = await formatosService.GetAllAsync();
            if (formatosDb == null) return;

            formatos = formatosDb;
            cmbFormato.DataSource = null;
            cmbFormato.DataSource = formatos;

            cargandoCombos = true;
            cmbFiltroFormato.Items.Clear();
            cmbFiltroFormato.Items.Add("Todos");
            foreach (var formato in formatos) cmbFiltroFormato.Items.Add(formato.Name);
            cmbFiltroFormato.SelectedIndex = 0;
            cargandoCombos = false;

            AplicarFiltros();
        }

        private void AplicarFiltros()
        {
            var texto = txtBusqueda.Text.Trim().ToUpper();
            var plataforma = cmbFiltroPlataforma.SelectedItem as string;
            var formato = cmbFiltroFormato.SelectedItem as string;

            var lista = productos.AsEnumerable();
            if (!string.IsNullOrWhiteSpace(texto))
                lista = lista.Where(p => p.Name.ToUpper().Contains(texto) || p.Description.ToUpper().Contains(texto));
            if (!string.IsNullOrEmpty(plataforma) && plataforma != "Todos")
                lista = lista.Where(p => string.Equals(p.Plataforma?.Name, plataforma, StringComparison.OrdinalIgnoreCase));
            if (!string.IsNullOrEmpty(formato) && formato != "Todos")
                lista = lista.Where(p => string.Equals(p.Formato?.Name, formato, StringComparison.OrdinalIgnoreCase));

            dataGridProductos.DataSource = lista.ToList();
            AjustarColumnas();
        }

        private void cmbFiltro_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (!cargandoCombos) AplicarFiltros();
        }

        private void btnBuscar_Click(object? s, EventArgs e)
        {
            AplicarFiltros();
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
                Name = txtNombre.Text.Trim(),
                Description = txtDescripcion.Text.Trim(),
                Price = decimal.TryParse(txtPrecio.Text, out var p) ? p : 0,
                Stock = int.TryParse(txtStock.Text, out var st) ? st : 0,
                ImageUrl = txtImagenUrl.Text.Trim(),
                TipoProductoId = cmbTipo.SelectedItem is TipoProducto tipo ? tipo.Id : 0,
                PlataformaId = cmbPlataforma.SelectedItem is Plataforma plataforma ? plataforma.Id ?? 0 : 0,
                FormatoId = cmbFormato.SelectedItem is Formato formato ? formato.Id ?? 0 : 0,
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
            if (cmbTipo.Items.Count > 0) cmbTipo.SelectedIndex = 0;
            if (cmbPlataforma.Items.Count > 0) cmbPlataforma.SelectedIndex = 0;
            if (cmbFormato.Items.Count > 0) cmbFormato.SelectedIndex = 0;
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

                var tipo = tipos.FirstOrDefault(t => t.Id == productoModificado.TipoProductoId);
                if (tipo != null) cmbTipo.SelectedItem = tipo;
                var plataforma = plataformas.FirstOrDefault(pl => pl.Id == productoModificado.PlataformaId);
                if (plataforma != null) cmbPlataforma.SelectedItem = plataforma;
                var formato = formatos.FirstOrDefault(f => f.Id == productoModificado.FormatoId);
                if (formato != null) cmbFormato.SelectedItem = formato;

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
