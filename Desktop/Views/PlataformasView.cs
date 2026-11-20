using Desktop.Services;
using FontAwesome.Sharp;
using Services.Models;

namespace Desktop.Views
{
    public partial class PlataformasView : Form
    {
        private PlataformasService plataformasService = new PlataformasService();
        private Plataforma? plataformaModificada;


        public PlataformasView()
        {
            InitializeComponent();
            LoadPlataformas();
        }



        private async void LoadPlataformas()
        {
            var plataformas = await plataformasService.GetAllAsync();
            if (plataformas != null) dataGridPlataformas.DataSource = plataformas;
        }

        private async void Filtrar()
        {
            var plataformas = await plataformasService.GetAllAsync();
            if (plataformas != null)
            {
                var filtro = txtBusqueda.Text.ToUpper();
                dataGridPlataformas.DataSource = plataformas.Where(p => p.Name.ToUpper().Contains(filtro)).ToList();
            }
        }

        private void btnNuevo_Click(object? s, EventArgs e)
        {
            tabControl.SelectedTab = tabPageAgregarEditar;
            plataformaModificada = null;
            txtNombre.Clear();
        }

        private void btnCancelar_Click(object? s, EventArgs e)
        {
            tabControl.SelectedTab = tabPageLista;
            txtNombre.Clear();
            plataformaModificada = null;
        }

        private async void btnGuardar_Click(object? s, EventArgs e)
        {
            bool ok;
            if (plataformaModificada == null)
                ok = await plataformasService.AddPlataformaAsync(new Plataforma { Name = txtNombre.Text });
            else
            {
                plataformaModificada.Name = txtNombre.Text;
                ok = await plataformasService.UpdatePlataformaAsync(plataformaModificada);
            }

            if (ok)
            {
                MessageBox.Show("Plataforma guardada correctamente");
                LoadPlataformas();
                txtNombre.Clear();
                tabControl.SelectedTab = tabPageLista;
            }
            else MessageBox.Show("Error al guardar la plataforma");
        }

        private void btnModificar_Click(object? s, EventArgs e)
        {
            if (dataGridPlataformas.CurrentRow != null)
            {
                plataformaModificada = (Plataforma)dataGridPlataformas.CurrentRow.DataBoundItem;
                txtNombre.Text = plataformaModificada.Name;
                tabControl.SelectedTab = tabPageAgregarEditar;
            }
        }

        private async void btnEliminar_Click(object? s, EventArgs e)
        {
            if (dataGridPlataformas.CurrentRow != null)
            {
                var p = (Plataforma)dataGridPlataformas.CurrentRow.DataBoundItem;
                var confirm = MessageBox.Show($"¿Está seguro de eliminar la plataforma {p.Name}?", "Confirmar eliminación", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    bool ok = await plataformasService.DeletePlataformaAsync(p.Id);
                    if (ok)
                    {
                        MessageBox.Show("Plataforma eliminada");
                        LoadPlataformas();
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
