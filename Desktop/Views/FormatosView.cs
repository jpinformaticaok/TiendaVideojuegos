using Desktop.Services;
using FontAwesome.Sharp;
using Services.Models;

namespace Desktop.Views
{
    public partial class FormatosView : Form
    {
        private FormatosService formatosService = new FormatosService();
        private Formato? formatoModificado;


        public FormatosView()
        {
            InitializeComponent();
            LoadFormatos();
        }



        private async void LoadFormatos()
        {
            var formatos = await formatosService.GetAllAsync();
            if (formatos != null) dataGridFormatos.DataSource = formatos;
        }

        private async void Filtrar()
        {
            var formatos = await formatosService.GetAllAsync();
            if (formatos != null)
            {
                var filtro = txtBusqueda.Text.ToUpper();
                dataGridFormatos.DataSource = formatos.Where(f => f.Name.ToUpper().Contains(filtro)).ToList();
            }
        }

        private void btnNuevo_Click(object? s, EventArgs e)
        {
            tabControl.SelectedTab = tabPageAgregarEditar;
            formatoModificado = null;
            txtNombre.Clear();
        }

        private void btnCancelar_Click(object? s, EventArgs e)
        {
            tabControl.SelectedTab = tabPageLista;
            txtNombre.Clear();
            formatoModificado = null;
        }

        private async void btnGuardar_Click(object? s, EventArgs e)
        {
            bool ok;
            if (formatoModificado == null)
                ok = await formatosService.AddFormatoAsync(new Formato { Name = txtNombre.Text });
            else
            {
                formatoModificado.Name = txtNombre.Text;
                ok = await formatosService.UpdateFormatoAsync(formatoModificado);
            }

            if (ok)
            {
                MessageBox.Show("Formato guardado correctamente");
                LoadFormatos();
                txtNombre.Clear();
                tabControl.SelectedTab = tabPageLista;
            }
            else MessageBox.Show("Error al guardar el formato");
        }

        private void btnModificar_Click(object? s, EventArgs e)
        {
            if (dataGridFormatos.CurrentRow != null)
            {
                formatoModificado = (Formato)dataGridFormatos.CurrentRow.DataBoundItem;
                txtNombre.Text = formatoModificado.Name;
                tabControl.SelectedTab = tabPageAgregarEditar;
            }
        }

        private async void btnEliminar_Click(object? s, EventArgs e)
        {
            if (dataGridFormatos.CurrentRow != null)
            {
                var f = (Formato)dataGridFormatos.CurrentRow.DataBoundItem;
                var confirm = MessageBox.Show($"¿Está seguro de eliminar el formato {f.Name}?", "Confirmar eliminación", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    bool ok = await formatosService.DeleteFormatoAsync(f.Id);
                    if (ok)
                    {
                        MessageBox.Show("Formato eliminado");
                        LoadFormatos();
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
