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
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageLista = new System.Windows.Forms.TabPage();
            this.tabPageNueva = new System.Windows.Forms.TabPage();
            this.gridVentas = new System.Windows.Forms.DataGridView();
            this.gridDetalle = new System.Windows.Forms.DataGridView();
            this.btnActualizar = new FontAwesome.Sharp.IconButton();
            this.labelDetalle = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.cmbCliente = new System.Windows.Forms.ComboBox();
            this.cmbProducto = new System.Windows.Forms.ComboBox();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.btnAgregar = new FontAwesome.Sharp.IconButton();
            this.btnQuitar = new FontAwesome.Sharp.IconButton();
            this.btnGuardar = new FontAwesome.Sharp.IconButton();
            this.gridItems = new System.Windows.Forms.DataGridView();
            this.SuspendLayout();
            this.Text = "Ventas";
            this.ClientSize = new Size(800, 450);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Name = "VentasView";
            this.label1.AutoSize = true;
            this.label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            this.label1.Location = new Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Text = "Facturación - Ventas";
            this.tabControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.tabControl.Controls.Add(this.tabPageLista);
            this.tabControl.Controls.Add(this.tabPageNueva);
            this.tabControl.Location = new Point(12, 59);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new Size(776, 379);
            // ---------- Pestaña Lista ----------
            this.tabPageLista.Text = "Lista";
            this.tabPageLista.UseVisualStyleBackColor = true;
            this.gridVentas.AllowUserToAddRows = false;
            this.gridVentas.AllowUserToDeleteRows = false;
            this.gridVentas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridVentas.Location = new Point(6, 6);
            this.gridVentas.Name = "gridVentas";
            this.gridVentas.ReadOnly = true;
            this.gridVentas.Size = new Size(734, 190);
            this.gridVentas.SelectionChanged += new System.EventHandler(this.gridVentas_SelectionChanged);
            this.labelDetalle.AutoSize = true;
            this.labelDetalle.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.labelDetalle.Location = new Point(6, 205);
            this.labelDetalle.Name = "labelDetalle";
            this.labelDetalle.Text = "Detalle de la factura seleccionada";
            this.gridDetalle.AllowUserToAddRows = false;
            this.gridDetalle.AllowUserToDeleteRows = false;
            this.gridDetalle.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridDetalle.Location = new Point(6, 230);
            this.gridDetalle.Name = "gridDetalle";
            this.gridDetalle.ReadOnly = true;
            this.gridDetalle.Size = new Size(734, 110);
            this.btnActualizar.IconChar = IconChar.Rotate;
            this.btnActualizar.IconColor = Color.Black;
            this.btnActualizar.IconFont = IconFont.Auto;
            this.btnActualizar.IconSize = 15;
            this.btnActualizar.ImageAlign = ContentAlignment.MiddleLeft;
            this.btnActualizar.Location = new Point(650, 343);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new Size(90, 23);
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            this.tabPageLista.Controls.Add(this.gridDetalle);
            this.tabPageLista.Controls.Add(this.labelDetalle);
            this.tabPageLista.Controls.Add(this.btnActualizar);
            this.tabPageLista.Controls.Add(this.gridVentas);
            // ---------- Pestaña Nueva venta ----------
            this.tabPageNueva.Text = "Nueva Venta";
            this.tabPageNueva.UseVisualStyleBackColor = true;
            this.label2.AutoSize = true;
            this.label2.Location = new Point(12, 21);
            this.label2.Text = "Cliente";
            this.cmbCliente.Location = new Point(90, 17);
            this.cmbCliente.Name = "cmbCliente";
            this.cmbCliente.Size = new Size(300, 23);
            this.cmbCliente.DropDownStyle = ComboBoxStyle.DropDownList;
            this.label3.AutoSize = true;
            this.label3.Location = new Point(12, 61);
            this.label3.Text = "Producto";
            this.cmbProducto.Location = new Point(90, 57);
            this.cmbProducto.Name = "cmbProducto";
            this.cmbProducto.Size = new Size(300, 23);
            this.cmbProducto.DropDownStyle = ComboBoxStyle.DropDownList;
            this.label4.AutoSize = true;
            this.label4.Location = new Point(410, 61);
            this.label4.Text = "Cantidad";
            this.txtCantidad.Location = new Point(480, 57);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new Size(60, 23);
            this.txtCantidad.Text = "1";
            this.btnAgregar.IconChar = IconChar.Plus;
            this.btnAgregar.IconColor = Color.Black;
            this.btnAgregar.IconFont = IconFont.Auto;
            this.btnAgregar.IconSize = 15;
            this.btnAgregar.ImageAlign = ContentAlignment.MiddleLeft;
            this.btnAgregar.Location = new Point(560, 56);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new Size(90, 23);
            this.btnAgregar.Text = " Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            this.btnQuitar.IconChar = IconChar.Trash;
            this.btnQuitar.IconColor = Color.Black;
            this.btnQuitar.IconFont = IconFont.Auto;
            this.btnQuitar.IconSize = 15;
            this.btnQuitar.ImageAlign = ContentAlignment.MiddleLeft;
            this.btnQuitar.Location = new Point(656, 56);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new Size(90, 23);
            this.btnQuitar.Text = " Quitar";
            this.btnQuitar.UseVisualStyleBackColor = true;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            this.gridItems.AllowUserToAddRows = false;
            this.gridItems.AllowUserToDeleteRows = false;
            this.gridItems.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridItems.Location = new Point(12, 100);
            this.gridItems.Name = "gridItems";
            this.gridItems.ReadOnly = true;
            this.gridItems.Size = new Size(734, 200);
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.lblTotal.Location = new Point(12, 320);
            this.lblTotal.Text = "Total: 0";
            this.btnGuardar.IconChar = IconChar.Save;
            this.btnGuardar.IconColor = Color.Black;
            this.btnGuardar.IconFont = IconFont.Auto;
            this.btnGuardar.IconSize = 15;
            this.btnGuardar.ImageAlign = ContentAlignment.MiddleLeft;
            this.btnGuardar.Location = new Point(620, 315);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new Size(132, 30);
            this.btnGuardar.Text = "Guardar Venta";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            this.tabPageNueva.Controls.Add(this.label2);
            this.tabPageNueva.Controls.Add(this.cmbCliente);
            this.tabPageNueva.Controls.Add(this.label3);
            this.tabPageNueva.Controls.Add(this.cmbProducto);
            this.tabPageNueva.Controls.Add(this.label4);
            this.tabPageNueva.Controls.Add(this.txtCantidad);
            this.tabPageNueva.Controls.Add(this.btnAgregar);
            this.tabPageNueva.Controls.Add(this.btnQuitar);
            this.tabPageNueva.Controls.Add(this.gridItems);
            this.tabPageNueva.Controls.Add(this.lblTotal);
            this.tabPageNueva.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.label1);
            this.ResumeLayout(false);
        }


        #endregion

        private System.Windows.Forms.Label label1;
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
    }
}