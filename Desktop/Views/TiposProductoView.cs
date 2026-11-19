using Desktop.Services;
using FontAwesome.Sharp;
using Services.Models;

namespace Desktop.Views
{
    public partial class TiposProductoView : Form
    {
        private TiposProductoService tiposService = new TiposProductoService();
        private TipoProducto? tipoModificado;


        public TiposProductoView()
        {
            InitializeComponent();
            LoadTipos();
        }

        

        private async void LoadTipos()
        {
            var tipos = await tiposService.GetAllAsync();
            if (tipos != null) dataGridTipos.DataSource = tipos;
        }

        private async void Filtrar()
        {
            var tipos = await tiposService.GetAllAsync();
            if (tipos != null)
            {
                var filtro = txtBusqueda.Text.ToUpper();
                dataGridTipos.DataSource = tipos.Where(t => t.Name.ToUpper().Contains(filtro)).ToList();
            }
        }

        private void btnNuevo_Click(object? s, EventArgs e)
        {
            tabControl.SelectedTab = tabPageAgregarEditar;
            tipoModificado = null;
            txtNombre.Clear();
        }

        private void btnCancelar_Click(object? s, EventArgs e)
        {
            tabControl.SelectedTab = tabPageLista;
            txtNombre.Clear();
            tipoModificado = null;
        }

        private async void btnGuardar_Click(object? s, EventArgs e)
        {
            bool ok;
            if (tipoModificado == null)
                ok = await tiposService.AddTipoProductoAsync(new TipoProducto { Name = txtNombre.Text });
            else
            {
                tipoModificado.Name = txtNombre.Text;
                ok = await tiposService.UpdateTipoProductoAsync(tipoModificado);
            }

            if (ok)
            {
                MessageBox.Show("Tipo de producto guardado correctamente");
                LoadTipos();
                txtNombre.Clear();
                tabControl.SelectedTab = tabPageLista;
            }
            else MessageBox.Show("Error al guardar el tipo de producto");
        }

        private void btnModificar_Click(object? s, EventArgs e)
        {
            if (dataGridTipos.CurrentRow != null)
            {
                tipoModificado = (TipoProducto)dataGridTipos.CurrentRow.DataBoundItem;
                txtNombre.Text = tipoModificado.Name;
                tabControl.SelectedTab = tabPageAgregarEditar;
            }
        }

        private async void btnEliminar_Click(object? s, EventArgs e)
        {
            if (dataGridTipos.CurrentRow != null)
            {
                var t = (TipoProducto)dataGridTipos.CurrentRow.DataBoundItem;
                var confirm = MessageBox.Show($"¿Está seguro de eliminar el tipo {t.Name}?", "Confirmar eliminación", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    bool ok = await tiposService.DeleteTipoProductoAsync(t.Id);
                    if (ok)
                    {
                        MessageBox.Show("Tipo de producto eliminado");
                        LoadTipos();
                    }
                }
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
        private void btnBuscar_Click(object? sender, EventArgs e)
        {
            Filtrar();
        }

    }
}