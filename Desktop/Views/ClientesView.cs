using Desktop.Services;
using Services.Models;

namespace Desktop.Views
{
    public partial class ClientesView : Form
    {
        ClientesService clientesService = new ClientesService();
        Cliente? clienteModificado;
        TabControl tabControl = new TabControl();
        TabPage tabPageLista = new TabPage("Lista");
        TabPage tabPageAgregarEditar = new TabPage("Agregar/Editar");
        DataGridView dataGridClientes = new DataGridView();
        TextBox txtBusqueda = new TextBox();
        Button btnBuscar = new Button();
        Button btnNuevo = new Button();
        Button btnModificar = new Button();
        Button btnEliminar = new Button();
        TextBox txtNombre = new TextBox();
        TextBox txtApellido = new TextBox();
        TextBox txtDni = new TextBox();
        TextBox txtDireccion = new TextBox();
        Button btnGuardar = new Button();
        Button btnCancelar = new Button();

        public ClientesView()
        {
            InitializeComponent();
            LoadClientes();
        }

        private void InitializeComponent()
        {
            this.Text = "Clientes";
            this.Size = new Size(800, 500);
            tabControl.Dock = DockStyle.Fill;
            // Lista
            txtBusqueda.Left = 10; txtBusqueda.Top = 10; txtBusqueda.Width = 200;
            btnBuscar.Text = "Buscar"; btnBuscar.Left = 220; btnBuscar.Top = 8; btnBuscar.Click += async (s, e) => await btnBuscar_Click(s, e);
            dataGridClientes.Left = 10; dataGridClientes.Top = 40; dataGridClientes.Width = 760; dataGridClientes.Height = 360;
            dataGridClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            btnNuevo.Text = "Nuevo"; btnNuevo.Left = 10; btnNuevo.Top = 410; btnNuevo.Click += (s, e) => btnNuevo_Click(s, e);
            btnModificar.Text = "Modificar"; btnModificar.Left = 100; btnModificar.Top = 410; btnModificar.Click += (s, e) => btnModificar_Click(s, e);
            btnEliminar.Text = "Eliminar"; btnEliminar.Left = 200; btnEliminar.Top = 410; btnEliminar.Click += async (s, e) => await btnEliminar_Click(s, e);
            tabPageLista.Controls.AddRange(new Control[] { txtBusqueda, btnBuscar, dataGridClientes, btnNuevo, btnModificar, btnEliminar });
            // Agregar/Editar
            int y = 20;
            tabPageAgregarEditar.Controls.Add(new Label { Text = "Nombre", Left = 10, Top = y, Width = 80 }); txtNombre.Left = 100; txtNombre.Top = y; tabPageAgregarEditar.Controls.Add(txtNombre); y += 30;
            tabPageAgregarEditar.Controls.Add(new Label { Text = "Apellido", Left = 10, Top = y, Width = 80 }); txtApellido.Left = 100; txtApellido.Top = y; tabPageAgregarEditar.Controls.Add(txtApellido); y += 30;
            tabPageAgregarEditar.Controls.Add(new Label { Text = "DNI", Left = 10, Top = y, Width = 80 }); txtDni.Left = 100; txtDni.Top = y; tabPageAgregarEditar.Controls.Add(txtDni); y += 30;
            tabPageAgregarEditar.Controls.Add(new Label { Text = "Dirección", Left = 10, Top = y, Width = 80 }); txtDireccion.Left = 100; txtDireccion.Top = y; tabPageAgregarEditar.Controls.Add(txtDireccion); y += 40;
            btnGuardar.Text = "Guardar"; btnGuardar.Left = 100; btnGuardar.Top = y; btnGuardar.Click += async (s, e) => await btnGuardar_Click(s, e);
            btnCancelar.Text = "Cancelar"; btnCancelar.Left = 200; btnCancelar.Top = y; btnCancelar.Click += (s, e) => btnCancelar_Click(s, e);
            tabPageAgregarEditar.Controls.AddRange(new Control[] { btnGuardar, btnCancelar });
            tabControl.TabPages.Add(tabPageLista);
            tabControl.TabPages.Add(tabPageAgregarEditar);
            this.Controls.Add(tabControl);
        }

        private async void LoadClientes()
        {
            var clientes = await clientesService.GetAllAsync();
            if (clientes != null) dataGridClientes.DataSource = clientes;
        }

        private async Task btnBuscar_Click(object? s, EventArgs e)
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

        private async Task btnGuardar_Click(object? s, EventArgs e)
        {
            Cliente cliente = new Cliente
            {
                Firstname = txtNombre.Text,
                Lastname = txtApellido.Text,
                Dni = txtDni.Text,
                Address = txtDireccion.Text,
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
            txtNombre.Clear(); txtApellido.Clear(); txtDni.Clear(); txtDireccion.Clear();
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
                tabControl.SelectedTab = tabPageAgregarEditar;
            }
        }

        private async Task btnEliminar_Click(object? s, EventArgs e)
        {
            if (dataGridClientes.CurrentRow != null)
            {
                var c = (Cliente)dataGridClientes.CurrentRow.DataBoundItem;
                var confirm = MessageBox.Show($"¿Eliminar cliente {c.Firstname} {c.Lastname}?", "Confirmar", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    bool ok = await clientesService.DeleteClienteAsync(c.Id);
                    if (ok) { MessageBox.Show("Eliminado"); LoadClientes(); }
                }
            }
        }
    }
}