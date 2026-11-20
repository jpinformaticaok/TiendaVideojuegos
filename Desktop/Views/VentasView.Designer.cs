using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace Desktop.Views
{
    partial class VentasView
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
            gridDetalle = new DataGridView();
            labelDetalle = new Label();
            btnActualizar = new IconButton();
            gridVentas = new DataGridView();
            tabPageNueva = new TabPage();
            label2 = new Label();
            cmbCliente = new ComboBox();
            label3 = new Label();
            cmbProducto = new ComboBox();
            label4 = new Label();
            txtCantidad = new TextBox();
            btnAgregar = new IconButton();
            btnQuitar = new IconButton();
            gridItems = new DataGridView();
            lblTotal = new Label();
            btnGuardar = new IconButton();
            panelTitulo = new Panel();
            lblTitulo = new Label();
            lblSubtitulo = new Label();
            tabControl.SuspendLayout();
            tabPageLista.SuspendLayout();
            ((ISupportInitialize)gridDetalle).BeginInit();
            ((ISupportInitialize)gridVentas).BeginInit();
            tabPageNueva.SuspendLayout();
            ((ISupportInitialize)gridItems).BeginInit();
            panelTitulo.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl
            // 
            tabControl.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tabControl.Controls.Add(tabPageLista);
            tabControl.Controls.Add(tabPageNueva);
            tabControl.Location = new Point(12, 76);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(776, 390);
            tabControl.TabIndex = 0;
            // 
            // tabPageLista
            // 
            tabPageLista.Controls.Add(gridDetalle);
            tabPageLista.Controls.Add(labelDetalle);
            tabPageLista.Controls.Add(btnActualizar);
            tabPageLista.Controls.Add(gridVentas);
            tabPageLista.Location = new Point(4, 24);
            tabPageLista.Name = "tabPageLista";
            tabPageLista.Size = new Size(768, 393);
            tabPageLista.TabIndex = 0;
            tabPageLista.Text = "Lista";
            tabPageLista.UseVisualStyleBackColor = true;
            // 
            // gridDetalle
            // 
            gridDetalle.AllowUserToAddRows = false;
            gridDetalle.AllowUserToDeleteRows = false;
            gridDetalle.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridDetalle.Location = new Point(6, 230);
            gridDetalle.Name = "gridDetalle";
            gridDetalle.ReadOnly = true;
            gridDetalle.Size = new Size(734, 110);
            gridDetalle.TabIndex = 0;
            // 
            // labelDetalle
            // 
            labelDetalle.AutoSize = true;
            labelDetalle.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelDetalle.Location = new Point(6, 205);
            labelDetalle.Name = "labelDetalle";
            labelDetalle.Size = new Size(234, 19);
            labelDetalle.TabIndex = 1;
            labelDetalle.Text = "Detalle de la factura seleccionada";
            // 
            // btnActualizar
            // 
            btnActualizar.IconChar = IconChar.SyncAlt;
            btnActualizar.IconColor = Color.Black;
            btnActualizar.IconFont = IconFont.Auto;
            btnActualizar.IconSize = 15;
            btnActualizar.ImageAlign = ContentAlignment.MiddleLeft;
            btnActualizar.Location = new Point(650, 356);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(90, 23);
            btnActualizar.TabIndex = 2;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += btnActualizar_Click;
            // 
            // gridVentas
            // 
            gridVentas.AllowUserToAddRows = false;
            gridVentas.AllowUserToDeleteRows = false;
            gridVentas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridVentas.Location = new Point(6, 6);
            gridVentas.Name = "gridVentas";
            gridVentas.ReadOnly = true;
            gridVentas.Size = new Size(734, 190);
            gridVentas.TabIndex = 3;
            gridVentas.SelectionChanged += gridVentas_SelectionChanged;
            // 
            // tabPageNueva
            // 
            tabPageNueva.Controls.Add(label2);
            tabPageNueva.Controls.Add(cmbCliente);
            tabPageNueva.Controls.Add(label3);
            tabPageNueva.Controls.Add(cmbProducto);
            tabPageNueva.Controls.Add(label4);
            tabPageNueva.Controls.Add(txtCantidad);
            tabPageNueva.Controls.Add(btnAgregar);
            tabPageNueva.Controls.Add(btnQuitar);
            tabPageNueva.Controls.Add(gridItems);
            tabPageNueva.Controls.Add(lblTotal);
            tabPageNueva.Controls.Add(btnGuardar);
            tabPageNueva.Location = new Point(4, 24);
            tabPageNueva.Name = "tabPageNueva";
            tabPageNueva.Size = new Size(768, 362);
            tabPageNueva.TabIndex = 1;
            tabPageNueva.Text = "Nueva Venta";
            tabPageNueva.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 21);
            label2.Name = "label2";
            label2.Size = new Size(44, 15);
            label2.TabIndex = 0;
            label2.Text = "Cliente";
            // 
            // cmbCliente
            // 
            cmbCliente.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCliente.Location = new Point(90, 17);
            cmbCliente.Name = "cmbCliente";
            cmbCliente.Size = new Size(300, 23);
            cmbCliente.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 61);
            label3.Name = "label3";
            label3.Size = new Size(56, 15);
            label3.TabIndex = 2;
            label3.Text = "Producto";
            // 
            // cmbProducto
            // 
            cmbProducto.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProducto.Location = new Point(90, 57);
            cmbProducto.Name = "cmbProducto";
            cmbProducto.Size = new Size(300, 23);
            cmbProducto.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(410, 61);
            label4.Name = "label4";
            label4.Size = new Size(55, 15);
            label4.TabIndex = 4;
            label4.Text = "Cantidad";
            // 
            // txtCantidad
            // 
            txtCantidad.Location = new Point(480, 57);
            txtCantidad.Name = "txtCantidad";
            txtCantidad.Size = new Size(60, 23);
            txtCantidad.TabIndex = 5;
            txtCantidad.Text = "1";
            // 
            // btnAgregar
            // 
            btnAgregar.IconChar = IconChar.Add;
            btnAgregar.IconColor = Color.Black;
            btnAgregar.IconFont = IconFont.Auto;
            btnAgregar.IconSize = 15;
            btnAgregar.ImageAlign = ContentAlignment.MiddleLeft;
            btnAgregar.Location = new Point(560, 56);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(90, 23);
            btnAgregar.TabIndex = 6;
            btnAgregar.Text = " Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnQuitar
            // 
            btnQuitar.IconChar = IconChar.Trash;
            btnQuitar.IconColor = Color.Black;
            btnQuitar.IconFont = IconFont.Auto;
            btnQuitar.IconSize = 15;
            btnQuitar.ImageAlign = ContentAlignment.MiddleLeft;
            btnQuitar.Location = new Point(656, 56);
            btnQuitar.Name = "btnQuitar";
            btnQuitar.Size = new Size(90, 23);
            btnQuitar.TabIndex = 7;
            btnQuitar.Text = " Quitar";
            btnQuitar.UseVisualStyleBackColor = true;
            btnQuitar.Click += btnQuitar_Click;
            // 
            // gridItems
            // 
            gridItems.AllowUserToAddRows = false;
            gridItems.AllowUserToDeleteRows = false;
            gridItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridItems.Location = new Point(12, 100);
            gridItems.Name = "gridItems";
            gridItems.ReadOnly = true;
            gridItems.Size = new Size(734, 200);
            gridItems.TabIndex = 8;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotal.Location = new Point(12, 320);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(65, 21);
            lblTotal.TabIndex = 9;
            lblTotal.Text = "Total: 0";
            // 
            // btnGuardar
            // 
            btnGuardar.IconChar = IconChar.Save;
            btnGuardar.IconColor = Color.Black;
            btnGuardar.IconFont = IconFont.Auto;
            btnGuardar.IconSize = 15;
            btnGuardar.ImageAlign = ContentAlignment.MiddleLeft;
            btnGuardar.Location = new Point(620, 315);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(132, 30);
            btnGuardar.TabIndex = 10;
            btnGuardar.Text = "Guardar Venta";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
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
            lblTitulo.Size = new Size(223, 30);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Facturación - Ventas";
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.ForeColor = Color.White;
            lblSubtitulo.Location = new Point(23, 44);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(125, 15);
            lblSubtitulo.TabIndex = 1;
            lblSubtitulo.Text = "Solo recibos por ahora";
            // 
            // VentasView
            // 
            ClientSize = new Size(800, 484);
            Controls.Add(panelTitulo);
            Controls.Add(tabControl);
            Name = "VentasView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ventas";
            tabControl.ResumeLayout(false);
            tabPageLista.ResumeLayout(false);
            tabPageLista.PerformLayout();
            ((ISupportInitialize)gridDetalle).EndInit();
            ((ISupportInitialize)gridVentas).EndInit();
            tabPageNueva.ResumeLayout(false);
            tabPageNueva.PerformLayout();
            ((ISupportInitialize)gridItems).EndInit();
            panelTitulo.ResumeLayout(false);
            panelTitulo.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageLista;
        private System.Windows.Forms.TabPage tabPageNueva;
        private System.Windows.Forms.DataGridView gridVentas;
        private System.Windows.Forms.DataGridView gridDetalle;
        private FontAwesome.Sharp.IconButton btnActualizar;
        private System.Windows.Forms.Label labelDetalle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.ComboBox cmbCliente;
        private System.Windows.Forms.ComboBox cmbProducto;
        private System.Windows.Forms.TextBox txtCantidad;
        private FontAwesome.Sharp.IconButton btnAgregar;
        private FontAwesome.Sharp.IconButton btnQuitar;
        private FontAwesome.Sharp.IconButton btnGuardar;
        private System.Windows.Forms.DataGridView gridItems;
        private Panel panelTitulo;
        private Label lblTitulo;
        private Label lblSubtitulo;
    }
}