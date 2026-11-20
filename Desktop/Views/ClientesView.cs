using Desktop.Services;
using FontAwesome.Sharp;
using Services.Models;

namespace Desktop.Views
{
    public partial class ClientesView : Form
    {
        private ClientesService clientesService = new ClientesService();
        private Cliente? clienteModificado;


        public ClientesView()
        {
            InitializeComponent();
            LoadClientes();
        }

        

        private async void LoadClientes()
        {
            var clientes = await clientesService.GetAllAsync();
            if (clientes != null) dataGridClientes.DataSource = clientes;
        }

        private async void btnBuscar_Click(object? s, EventArgs e)
        {
            var clientes = await clientesService.GetAllWithFilterAsync(txtBusqueda.Text);
            if (clientes != null) dataGridClientes.DataSource = clientes;
        }

        private void btnNuevo_Click(object? s, EventArgs e)
        {
            tabControl.SelectedTab = tabPageAgregarEditar;
            clienteModificado = null;
            ClearTextBox();
        }

        private void btnCancelar_Click(object? s, EventArgs e)
        {
            tabControl.SelectedTab = tabPageLista;
            ClearTextBox();
            clienteModificado = null;
        }

        private async void btnGuardar_Click(object? s, EventArgs e)
        {
            Cliente cliente = new Cliente
            {
                Firstname = txtNombre.Text.Trim(),
                Lastname = txtApellido.Text.Trim(),
                Dni = txtDni.Text.Trim(),
                Address = txtDireccion.Text.Trim(),
                Localidad = txtLocalidad.Text.Trim(),
                Provincia = txtProvincia.Text.Trim(),
                Pais = txtPais.Text.Trim(),
            };
            bool ok;
            if (clienteModificado == null)
                ok = await clientesService.AddClienteAsync(cliente);
            else
            {
                cliente.Id = clienteModificado.Id;
                cliente.Created_at = clienteModificado.Created_at;
                ok = await clientesService.UpdateClienteAsync(cliente);
            }

            if (ok)
            {
                MessageBox.Show("Cliente guardado correctamente");
                LoadClientes();
                ClearTextBox();
                tabControl.SelectedTab = tabPageLista;
            }
            else MessageBox.Show("Error al guardar el cliente");
        }

        private void ClearTextBox()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtDni.Clear();
            txtDireccion.Clear();
            txtLocalidad.Clear();
            txtProvincia.Clear();
            txtPais.Clear();
        }

        private void btnModificar_Click(object? s, EventArgs e)
        {
            if (dataGridClientes.CurrentRow != null)
            {
                clienteModificado = (Cliente)dataGridClientes.CurrentRow.DataBoundItem;
                txtNombre.Text = clienteModificado.Firstname;
                txtApellido.Text = clienteModificado.Lastname;
                txtDni.Text = clienteModificado.Dni;
                txtDireccion.Text = clienteModificado.Address;
                txtLocalidad.Text = clienteModificado.Localidad ?? string.Empty;
                txtProvincia.Text = clienteModificado.Provincia ?? string.Empty;
                txtPais.Text = clienteModificado.Pais ?? string.Empty;
                tabControl.SelectedTab = tabPageAgregarEditar;
            }
        }

        private async void btnEliminar_Click(object? s, EventArgs e)
        {
            if (dataGridClientes.CurrentRow != null)
            {
                var c = (Cliente)dataGridClientes.CurrentRow.DataBoundItem;
                var confirm = MessageBox.Show($"¿Está seguro de eliminar al cliente {c.Firstname} {c.Lastname}?", "Confirmar eliminación", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    bool ok = await clientesService.DeleteClienteAsync(c.Id);
                    if (ok)
                    {
                        MessageBox.Show("Cliente eliminado");
                        LoadClientes();
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
    }
}