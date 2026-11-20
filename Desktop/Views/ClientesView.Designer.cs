using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace Desktop.Views
{
    partial class ClientesView
    {
        /// <summary>
        /// Variable del diseÃ±ador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estÃ©n usando.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region CÃ³digo generado por el DiseÃ±ador de Windows Forms

        /// <summary>
        /// MÃ©todo necesario para admitir el DiseÃ±ador. No se puede modificar
        /// el contenido de este mÃ©todo con el editor de cÃ³digo.
        /// </summary>
        private void InitializeComponent()
        {
            tabControl = new TabControl();
            tabPageLista = new TabPage();
            btnEliminar = new IconButton();
            btnModificar = new IconButton();
            btnNuevo = new IconButton();
            btnBuscar = new IconButton();
            txtBusqueda = new TextBox();
            label2 = new Label();
            dataGridClientes = new DataGridView();
            tabPageAgregarEditar = new TabPage();
            txtDireccion = new TextBox();
            txtDni = new TextBox();
            txtApellido = new TextBox();
            txtNombre = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            btnCancelar = new IconButton();
            btnGuardar = new IconButton();
            panelTitulo = new Panel();
            lblTitulo = new Label();
            tabControl.SuspendLayout();
            tabPageLista.SuspendLayout();
            ((ISupportInitialize)dataGridClientes).BeginInit();
            tabPageAgregarEditar.SuspendLayout();
            panelTitulo.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl
            // 
            tabControl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tabControl.Controls.Add(tabPageLista);
            tabControl.Controls.Add(tabPageAgregarEditar);
            tabControl.Location = new Point(12, 76);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(776, 399);
            tabControl.TabIndex = 0;
            // 
            // tabPageLista
            // 
            tabPageLista.Controls.Add(btnEliminar);
            tabPageLista.Controls.Add(btnModificar);
            tabPageLista.Controls.Add(btnNuevo);
            tabPageLista.Controls.Add(btnBuscar);
            tabPageLista.Controls.Add(txtBusqueda);
            tabPageLista.Controls.Add(label2);
            tabPageLista.Controls.Add(dataGridClientes);
            tabPageLista.Location = new Point(4, 24);
            tabPageLista.Name = "tabPageLista";
            tabPageLista.Size = new Size(768, 371);
            tabPageLista.TabIndex = 0;
            tabPageLista.Text = "Lista";
            tabPageLista.UseVisualStyleBackColor = true;
            // 
            // btnEliminar
            // 
            btnEliminar.IconChar = IconChar.Trash;
            btnEliminar.IconColor = Color.Black;
            btnEliminar.IconFont = IconFont.Auto;
            btnEliminar.IconSize = 15;
            btnEliminar.ImageAlign = ContentAlignment.MiddleLeft;
            btnEliminar.Location = new Point(654, 176);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(101, 23);
            btnEliminar.TabIndex = 0;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnModificar
            // 
            btnModificar.IconChar = IconChar.Pen;
            btnModificar.IconColor = Color.Black;
            btnModificar.IconFont = IconFont.Auto;
            btnModificar.IconSize = 15;
            btnModificar.ImageAlign = ContentAlignment.MiddleLeft;
            btnModificar.Location = new Point(654, 128);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(101, 23);
            btnModificar.TabIndex = 1;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnNuevo
            // 
            btnNuevo.IconChar = IconChar.Add;
            btnNuevo.IconColor = Color.Black;
            btnNuevo.IconFont = IconFont.Auto;
            btnNuevo.IconSize = 15;
            btnNuevo.ImageAlign = ContentAlignment.MiddleLeft;
            btnNuevo.Location = new Point(654, 72);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(101, 23);
            btnNuevo.TabIndex = 2;
            btnNuevo.Text = " Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // btnBuscar
            // 
            btnBuscar.IconChar = IconChar.Search;
            btnBuscar.IconColor = Color.Black;
            btnBuscar.IconFont = IconFont.Auto;
            btnBuscar.IconSize = 15;
            btnBuscar.ImageAlign = ContentAlignment.MiddleLeft;
            btnBuscar.Location = new Point(654, 21);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(101, 23);
            btnBuscar.TabIndex = 3;
            btnBuscar.Text = "   Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // txtBusqueda
            // 
            txtBusqueda.Location = new Point(54, 21);
            txtBusqueda.Name = "txtBusqueda";
            txtBusqueda.Size = new Size(578, 23);
            txtBusqueda.TabIndex = 4;
            txtBusqueda.KeyPress += txtBusqueda_KeyPress;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 21);
            label2.Name = "label2";
            label2.Size = new Size(42, 15);
            label2.TabIndex = 5;
            label2.Text = "Buscar";
            // 
            // dataGridClientes
            // 
            dataGridClientes.AllowUserToAddRows = false;
            dataGridClientes.AllowUserToDeleteRows = false;
            dataGridClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridClientes.Location = new Point(6, 59);
            dataGridClientes.Name = "dataGridClientes";
            dataGridClientes.ReadOnly = true;
            dataGridClientes.Size = new Size(626, 286);
            dataGridClientes.TabIndex = 6;
            // 
            // tabPageAgregarEditar
            // 
            tabPageAgregarEditar.Controls.Add(txtDireccion);
            tabPageAgregarEditar.Controls.Add(txtDni);
            tabPageAgregarEditar.Controls.Add(txtApellido);
            tabPageAgregarEditar.Controls.Add(txtNombre);
            tabPageAgregarEditar.Controls.Add(label6);
            tabPageAgregarEditar.Controls.Add(label5);
            tabPageAgregarEditar.Controls.Add(label4);
            tabPageAgregarEditar.Controls.Add(label3);
            tabPageAgregarEditar.Controls.Add(btnCancelar);
            tabPageAgregarEditar.Controls.Add(btnGuardar);
            tabPageAgregarEditar.Location = new Point(4, 24);
            tabPageAgregarEditar.Name = "tabPageAgregarEditar";
            tabPageAgregarEditar.Size = new Size(768, 371);
            tabPageAgregarEditar.TabIndex = 1;
            tabPageAgregarEditar.Text = "Agregar / Editar";
            tabPageAgregarEditar.UseVisualStyleBackColor = true;
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(120, 281);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(513, 23);
            txtDireccion.TabIndex = 0;
            // 
            // txtDni
            // 
            txtDni.Location = new Point(120, 209);
            txtDni.Name = "txtDni";
            txtDni.Size = new Size(513, 23);
            txtDni.TabIndex = 1;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(120, 130);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(513, 23);
            txtApellido.TabIndex = 2;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(120, 42);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(513, 23);
            txtNombre.TabIndex = 3;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(40, 289);
            label6.Name = "label6";
            label6.Size = new Size(57, 15);
            label6.TabIndex = 4;
            label6.Text = "Dirección";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(70, 212);
            label5.Name = "label5";
            label5.Size = new Size(27, 15);
            label5.TabIndex = 5;
            label5.Text = "DNI";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(46, 133);
            label4.Name = "label4";
            label4.Size = new Size(51, 15);
            label4.TabIndex = 6;
            label4.Text = "Apellido";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(46, 50);
            label3.Name = "label3";
            label3.Size = new Size(51, 15);
            label3.TabIndex = 7;
            label3.Text = "Nombre";
            // 
            // btnCancelar
            // 
            btnCancelar.IconChar = IconChar.Cancel;
            btnCancelar.IconColor = Color.Black;
            btnCancelar.IconFont = IconFont.Auto;
            btnCancelar.IconSize = 15;
            btnCancelar.ImageAlign = ContentAlignment.MiddleLeft;
            btnCancelar.Location = new Point(666, 182);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(83, 23);
            btnCancelar.TabIndex = 8;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.IconChar = IconChar.Save;
            btnGuardar.IconColor = Color.Black;
            btnGuardar.IconFont = IconFont.Auto;
            btnGuardar.IconSize = 15;
            btnGuardar.ImageAlign = ContentAlignment.MiddleLeft;
            btnGuardar.Location = new Point(666, 87);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(83, 23);
            btnGuardar.TabIndex = 9;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // panelTitulo
            // 
            panelTitulo.BackColor = Color.FromArgb(30, 30, 50);
            panelTitulo.Controls.Add(lblTitulo);
            panelTitulo.Dock = DockStyle.Top;
            panelTitulo.Location = new Point(0, 0);
            panelTitulo.Name = "panelTitulo";
            panelTitulo.Size = new Size(800, 70);
            panelTitulo.TabIndex = 1;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.FromArgb(120, 180, 255);
            lblTitulo.Location = new Point(20, 12);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(176, 30);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "CRUD - Clientes";
            // 
            // ClientesView
            // 
            ClientSize = new Size(800, 487);
            Controls.Add(panelTitulo);
            Controls.Add(tabControl);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "ClientesView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Clientes";
            tabControl.ResumeLayout(false);
            tabPageLista.ResumeLayout(false);
            tabPageLista.PerformLayout();
            ((ISupportInitialize)dataGridClientes).EndInit();
            tabPageAgregarEditar.ResumeLayout(false);
            tabPageAgregarEditar.PerformLayout();
            panelTitulo.ResumeLayout(false);
            panelTitulo.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageLista;
        private System.Windows.Forms.TabPage tabPageAgregarEditar;
        private System.Windows.Forms.DataGridView dataGridClientes;
        private System.Windows.Forms.TextBox txtBusqueda;
        private System.Windows.Forms.Label label2;
        private FontAwesome.Sharp.IconButton btnBuscar;
        private FontAwesome.Sharp.IconButton btnNuevo;
        private FontAwesome.Sharp.IconButton btnModificar;
        private FontAwesome.Sharp.IconButton btnEliminar;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private FontAwesome.Sharp.IconButton btnGuardar;
        private FontAwesome.Sharp.IconButton btnCancelar;
        private Panel panelTitulo;
        private Label lblTitulo;
    }
}