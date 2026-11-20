using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace Desktop.Views
{
    partial class ProductosView
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
            btnTiposProducto = new Button();
            btnEliminar = new IconButton();
            btnModificar = new IconButton();
            btnNuevo = new IconButton();
            picProducto = new PictureBox();
            btnBuscar = new IconButton();
            txtBusqueda = new TextBox();
            label2 = new Label();
            dataGridProductos = new DataGridView();
            tabPageAgregarEditar = new TabPage();
            label3 = new Label();
            txtNombre = new TextBox();
            label4 = new Label();
            txtDescripcion = new TextBox();
            label5 = new Label();
            txtPrecio = new TextBox();
            label6 = new Label();
            txtStock = new TextBox();
            label7 = new Label();
            txtImagenUrl = new TextBox();
            label8 = new Label();
            cmbTipo = new ComboBox();
            label9 = new Label();
            txtFormato = new TextBox();
            label10 = new Label();
            txtPlataforma = new TextBox();
            btnGuardar = new IconButton();
            btnCancelar = new IconButton();
            panelTitulo = new Panel();
            lblTitulo = new Label();
            lblSubtitulo = new Label();
            tabControl.SuspendLayout();
            tabPageLista.SuspendLayout();
            ((ISupportInitialize)picProducto).BeginInit();
            ((ISupportInitialize)dataGridProductos).BeginInit();
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
            tabControl.Size = new Size(776, 443);
            tabControl.TabIndex = 0;
            // 
            // tabPageLista
            // 
            tabPageLista.Controls.Add(btnTiposProducto);
            tabPageLista.Controls.Add(btnEliminar);
            tabPageLista.Controls.Add(btnModificar);
            tabPageLista.Controls.Add(btnNuevo);
            tabPageLista.Controls.Add(picProducto);
            tabPageLista.Controls.Add(btnBuscar);
            tabPageLista.Controls.Add(txtBusqueda);
            tabPageLista.Controls.Add(label2);
            tabPageLista.Controls.Add(dataGridProductos);
            tabPageLista.Location = new Point(4, 24);
            tabPageLista.Name = "tabPageLista";
            tabPageLista.Size = new Size(768, 415);
            tabPageLista.TabIndex = 0;
            tabPageLista.Text = "Lista";
            tabPageLista.UseVisualStyleBackColor = true;
            // 
            // btnTiposProducto
            // 
            btnTiposProducto.Location = new Point(642, 304);
            btnTiposProducto.Name = "btnTiposProducto";
            btnTiposProducto.Size = new Size(98, 23);
            btnTiposProducto.TabIndex = 0;
            btnTiposProducto.Text = "Tipos";
            btnTiposProducto.UseVisualStyleBackColor = true;
            btnTiposProducto.Click += btnTiposProducto_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.IconChar = IconChar.Trash;
            btnEliminar.IconColor = Color.Black;
            btnEliminar.IconFont = IconFont.Auto;
            btnEliminar.IconSize = 15;
            btnEliminar.ImageAlign = ContentAlignment.MiddleLeft;
            btnEliminar.Location = new Point(642, 266);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(98, 23);
            btnEliminar.TabIndex = 1;
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
            btnModificar.Location = new Point(642, 228);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(98, 23);
            btnModificar.TabIndex = 2;
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
            btnNuevo.Location = new Point(642, 190);
            btnNuevo.Name = "btnNuevo";
            btnNuevo.Size = new Size(98, 23);
            btnNuevo.TabIndex = 3;
            btnNuevo.Text = " Nuevo";
            btnNuevo.UseVisualStyleBackColor = true;
            btnNuevo.Click += btnNuevo_Click;
            // 
            // picProducto
            // 
            picProducto.BorderStyle = BorderStyle.FixedSingle;
            picProducto.Location = new Point(642, 59);
            picProducto.Name = "picProducto";
            picProducto.Size = new Size(120, 120);
            picProducto.SizeMode = PictureBoxSizeMode.Zoom;
            picProducto.TabIndex = 4;
            picProducto.TabStop = false;
            // 
            // btnBuscar
            // 
            btnBuscar.IconChar = IconChar.Search;
            btnBuscar.IconColor = Color.Black;
            btnBuscar.IconFont = IconFont.Auto;
            btnBuscar.IconSize = 15;
            btnBuscar.ImageAlign = ContentAlignment.MiddleLeft;
            btnBuscar.Location = new Point(665, 21);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(75, 23);
            btnBuscar.TabIndex = 5;
            btnBuscar.Text = "   Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // txtBusqueda
            // 
            txtBusqueda.Location = new Point(54, 21);
            txtBusqueda.Name = "txtBusqueda";
            txtBusqueda.Size = new Size(578, 23);
            txtBusqueda.TabIndex = 6;
            txtBusqueda.KeyPress += txtBusqueda_KeyPress;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 21);
            label2.Name = "label2";
            label2.Size = new Size(42, 15);
            label2.TabIndex = 7;
            label2.Text = "Buscar";
            // 
            // dataGridProductos
            // 
            dataGridProductos.AllowUserToAddRows = false;
            dataGridProductos.AllowUserToDeleteRows = false;
            dataGridProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridProductos.Location = new Point(6, 59);
            dataGridProductos.Name = "dataGridProductos";
            dataGridProductos.ReadOnly = true;
            dataGridProductos.Size = new Size(626, 286);
            dataGridProductos.TabIndex = 8;
            dataGridProductos.SelectionChanged += dataGridProductos_SelectionChanged;
            // 
            // tabPageAgregarEditar
            // 
            tabPageAgregarEditar.Controls.Add(label3);
            tabPageAgregarEditar.Controls.Add(txtNombre);
            tabPageAgregarEditar.Controls.Add(label4);
            tabPageAgregarEditar.Controls.Add(txtDescripcion);
            tabPageAgregarEditar.Controls.Add(label5);
            tabPageAgregarEditar.Controls.Add(txtPrecio);
            tabPageAgregarEditar.Controls.Add(label6);
            tabPageAgregarEditar.Controls.Add(txtStock);
            tabPageAgregarEditar.Controls.Add(label7);
            tabPageAgregarEditar.Controls.Add(txtImagenUrl);
            tabPageAgregarEditar.Controls.Add(label8);
            tabPageAgregarEditar.Controls.Add(cmbTipo);
            tabPageAgregarEditar.Controls.Add(label9);
            tabPageAgregarEditar.Controls.Add(txtFormato);
            tabPageAgregarEditar.Controls.Add(label10);
            tabPageAgregarEditar.Controls.Add(txtPlataforma);
            tabPageAgregarEditar.Controls.Add(btnGuardar);
            tabPageAgregarEditar.Controls.Add(btnCancelar);
            tabPageAgregarEditar.Location = new Point(4, 24);
            tabPageAgregarEditar.Name = "tabPageAgregarEditar";
            tabPageAgregarEditar.Size = new Size(768, 415);
            tabPageAgregarEditar.TabIndex = 1;
            tabPageAgregarEditar.Text = "Agregar / Editar";
            tabPageAgregarEditar.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(40, 27);
            label3.Name = "label3";
            label3.Size = new Size(51, 15);
            label3.TabIndex = 0;
            label3.Text = "Nombre";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(120, 19);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(513, 23);
            txtNombre.TabIndex = 1;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(40, 70);
            label4.Name = "label4";
            label4.Size = new Size(69, 15);
            label4.TabIndex = 2;
            label4.Text = "Descripción";
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(120, 70);
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(513, 23);
            txtDescripcion.TabIndex = 3;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(40, 120);
            label5.Name = "label5";
            label5.Size = new Size(40, 15);
            label5.TabIndex = 4;
            label5.Text = "Precio";
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(120, 120);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(513, 23);
            txtPrecio.TabIndex = 5;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(40, 168);
            label6.Name = "label6";
            label6.Size = new Size(36, 15);
            label6.TabIndex = 6;
            label6.Text = "Stock";
            // 
            // txtStock
            // 
            txtStock.Location = new Point(120, 168);
            txtStock.Name = "txtStock";
            txtStock.Size = new Size(513, 23);
            txtStock.TabIndex = 7;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(40, 371);
            label7.Name = "label7";
            label7.Size = new Size(71, 15);
            label7.TabIndex = 8;
            label7.Text = "Imagen URL";
            // 
            // txtImagenUrl
            // 
            txtImagenUrl.Location = new Point(120, 368);
            txtImagenUrl.Name = "txtImagenUrl";
            txtImagenUrl.Size = new Size(513, 23);
            txtImagenUrl.TabIndex = 9;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(40, 322);
            label8.Name = "label8";
            label8.Size = new Size(31, 15);
            label8.TabIndex = 10;
            label8.Text = "Tipo";
            // 
            // cmbTipo
            // 
            cmbTipo.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipo.Location = new Point(120, 322);
            cmbTipo.Name = "cmbTipo";
            cmbTipo.Size = new Size(513, 23);
            cmbTipo.TabIndex = 11;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(40, 219);
            label9.Name = "label9";
            label9.Size = new Size(52, 15);
            label9.TabIndex = 12;
            label9.Text = "Formato";
            // 
            // txtFormato
            // 
            txtFormato.Location = new Point(120, 219);
            txtFormato.Name = "txtFormato";
            txtFormato.Size = new Size(513, 23);
            txtFormato.TabIndex = 13;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(40, 267);
            label10.Name = "label10";
            label10.Size = new Size(65, 15);
            label10.TabIndex = 14;
            label10.Text = "Plataforma";
            // 
            // txtPlataforma
            // 
            txtPlataforma.Location = new Point(120, 267);
            txtPlataforma.Name = "txtPlataforma";
            txtPlataforma.Size = new Size(513, 23);
            txtPlataforma.TabIndex = 15;
            // 
            // btnGuardar
            // 
            btnGuardar.IconChar = IconChar.Save;
            btnGuardar.IconColor = Color.Black;
            btnGuardar.IconFont = IconFont.Auto;
            btnGuardar.IconSize = 15;
            btnGuardar.ImageAlign = ContentAlignment.MiddleLeft;
            btnGuardar.Location = new Point(665, 87);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(84, 23);
            btnGuardar.TabIndex = 16;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.IconChar = IconChar.Cancel;
            btnCancelar.IconColor = Color.Black;
            btnCancelar.IconFont = IconFont.Auto;
            btnCancelar.IconSize = 15;
            btnCancelar.ImageAlign = ContentAlignment.MiddleLeft;
            btnCancelar.Location = new Point(665, 182);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(84, 23);
            btnCancelar.TabIndex = 17;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // panelTitulo
            // 
            panelTitulo.BackColor = Color.FromArgb(30, 30, 50);
            panelTitulo.Controls.Add(lblTitulo);
            panelTitulo.Controls.Add(lblSubtitulo);
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
            lblTitulo.Size = new Size(200, 30);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "CRUD - Productos";
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.ForeColor = Color.White;
            lblSubtitulo.Location = new Point(23, 44);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(201, 15);
            lblSubtitulo.TabIndex = 1;
            lblSubtitulo.Text = "Registro con Firebase Authentication";
            // 
            // ProductosView
            // 
            ClientSize = new Size(800, 533);
            Controls.Add(panelTitulo);
            Controls.Add(tabControl);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "ProductosView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Productos";
            tabControl.ResumeLayout(false);
            tabPageLista.ResumeLayout(false);
            tabPageLista.PerformLayout();
            ((ISupportInitialize)picProducto).EndInit();
            ((ISupportInitialize)dataGridProductos).EndInit();
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
        private System.Windows.Forms.DataGridView dataGridProductos;
        private System.Windows.Forms.TextBox txtBusqueda;
        private System.Windows.Forms.Label label2;
        private FontAwesome.Sharp.IconButton btnBuscar;
        private FontAwesome.Sharp.IconButton btnNuevo;
        private FontAwesome.Sharp.IconButton btnModificar;
        private FontAwesome.Sharp.IconButton btnEliminar;
        private FontAwesome.Sharp.IconButton btnGuardar;
        private FontAwesome.Sharp.IconButton btnCancelar;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.TextBox txtImagenUrl;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.TextBox txtFormato;
        private System.Windows.Forms.TextBox txtPlataforma;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.PictureBox picProducto;
        private System.Windows.Forms.Button btnTiposProducto;
        private Panel panelTitulo;
        private Label lblTitulo;
        private Label lblSubtitulo;
    }
}