using Desktop.Services;
using FontAwesome.Sharp;
using Services.Models;

namespace Desktop.Views
{
    public partial class ClientesView : Form
    {
        private ClientesService clientesService = new ClientesService();
        private Cliente? clienteModificado;

        private Label label1 = new Label();
        private TabControl tabControl = new TabControl();
        private TabPage tabPageLista = new TabPage();
        private TabPage tabPageAgregarEditar = new TabPage();
        private DataGridView dataGridClientes = new DataGridView();
        private TextBox txtBusqueda = new TextBox();
        private Label label2 = new Label();
        private IconButton btnBuscar = new IconButton();
        private IconButton btnNuevo = new IconButton();
        private IconButton btnModificar = new IconButton();
        private IconButton btnEliminar = new IconButton();
        private TextBox txtNombre = new TextBox();
        private TextBox txtApellido = new TextBox();
        private TextBox txtDni = new TextBox();
        private TextBox txtDireccion = new TextBox();
        private Label label3 = new Label();
        private Label label4 = new Label();
        private Label label5 = new Label();
        private Label label6 = new Label();
        private IconButton btnGuardar = new IconButton();
        private IconButton btnCancelar = new IconButton();

        public ClientesView()
        {
            InitializeComponent();
            LoadClientes();
        }

        private void InitializeComponent()
        {
            this.Text = "Clientes";
            this.ClientSize = new Size(800, 450);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Name = "ClientesView";

            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(176, 30);
            label1.Text = "CRUD - Clientes";

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

            dataGridClientes.AllowUserToAddRows = false;
            dataGridClientes.AllowUserToDeleteRows = false;
            dataGridClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridClientes.Location = new Point(6, 59);
            dataGridClientes.Name = "dataGridClientes";
            dataGridClientes.ReadOnly = true;
            dataGridClientes.Size = new Size(626, 286);

            btnNuevo.IconChar = IconChar.Plus;
            btnNuevo.IconColor = Color.Black;
            btnNuevo.IconFont = IconFont.Auto;
            btnNuevo.IconSize = 15;
            btnNuevo.ImageAlign = ContentAlignment.MiddleLeft;
            btnNuevo.Location = new Point(665, 72);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(75, 23);
            btnNuevo.Text = " Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += (s, e) => btnNuevo_Click(s, e);

            btnModificar.IconChar = IconChar.Pen;
            btnModificar.IconColor = Color.Black;
            btnModificar.IconFont = IconFont.Auto;
            btnModificar.IconSize = 15;
            btnModificar.ImageAlign = ContentAlignment.MiddleLeft;
            btnModificar.Location = new Point(665, 128);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(75, 23);
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += (s, e) => btnModificar_Click(s, e);

            btnEliminar.IconChar = IconChar.Trash;
            btnEliminar.IconColor = Color.Black;
            btnEliminar.IconFont = IconFont.Auto;
            btnEliminar.IconSize = 15;
            btnEliminar.ImageAlign = ContentAlignment.MiddleLeft;
            btnEliminar.Location = new Point(665, 176);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 23);
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += async (s, e) => await btnEliminar_Click(s, e);

            tabPageLista.Controls.Add(btnEliminar);
            tabPageLista.Controls.Add(btnModificar);
            tabPageLista.Controls.Add(btnNuevo);
            tabPageLista.Controls.Add(btnBuscar);
            tabPageLista.Controls.Add(txtBusqueda);
            tabPageLista.Controls.Add(label2);
            tabPageLista.Controls.Add(dataGridClientes);

            tabPageAgregarEditar.Text = "Agregar / Editar";
            tabPageAgregarEditar.UseVisualStyleBackColor = true;

            label3.AutoSize = true;
            label3.Location = new Point(46, 50);
            label3.Text = "Nombre";
            txtNombre.Location = new Point(120, 42);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(513, 23);

            label4.AutoSize = true;
            label4.Location = new Point(46, 133);
            label4.Text = "Apellido";
            txtApellido.Location = new Point(120, 130);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(513, 23);

            label5.AutoSize = true;
            label5.Location = new Point(70, 212);
            label5.Text = "DNI";
            txtDni.Location = new Point(120, 209);
            txtDni.Name = "txtDni";
            txtDni.Size = new Size(513, 23);

            label6.AutoSize = true;
            label6.Location = new Point(40, 289);
            label6.Text = "Direccion";
            txtDireccion.Location = new Point(120, 281);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(513, 23);

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
                txtDireccion, txtDni, txtApellido, txtNombre, label6, label5, label4, label3, btnCancelar, btnGuardar
            });

            this.Controls.Add(tabControl);
            this.Controls.Add(label1);
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
            txtNombre.Clear();
            txtApellido.Clear();
            txtDni.Clear();
            txtDireccion.Clear();
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