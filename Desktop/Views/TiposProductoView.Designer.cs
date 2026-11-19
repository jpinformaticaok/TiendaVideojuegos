using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace Desktop.Views
{
    partial class TiposProductoView
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
            this.tabPageAgregarEditar = new System.Windows.Forms.TabPage();
            this.dataGridTipos = new System.Windows.Forms.DataGridView();
            this.txtBusqueda = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBuscar = new FontAwesome.Sharp.IconButton();
            this.btnNuevo = new FontAwesome.Sharp.IconButton();
            this.btnModificar = new FontAwesome.Sharp.IconButton();
            this.btnEliminar = new FontAwesome.Sharp.IconButton();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGuardar = new FontAwesome.Sharp.IconButton();
            this.btnCancelar = new FontAwesome.Sharp.IconButton();
            this.SuspendLayout();
            this.Text = "Tipos de Producto";
            this.ClientSize = new Size(800, 450);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Name = "TiposProductoView";
            this.label1.AutoSize = true;
            this.label1.Font = new Font("Segoe UI", 16F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            this.label1.Location = new Point(12, 9);
            this.label1.Text = "CRUD - Tipos de Producto";
            this.tabControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.tabControl.Controls.Add(this.tabPageLista);
            this.tabControl.Controls.Add(this.tabPageAgregarEditar);
            this.tabControl.Location = new Point(12, 59);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new Size(776, 379);
            this.tabPageLista.Text = "Lista";
            this.tabPageLista.UseVisualStyleBackColor = true;
            this.label2.AutoSize = true;
            this.label2.Location = new Point(6, 21);
            this.label2.Text = "Buscar";
            this.txtBusqueda.Location = new Point(54, 21);
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new Size(578, 23);
            this.txtBusqueda.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBusqueda_KeyPress);
            this.btnBuscar.IconChar = IconChar.Search;
            this.btnBuscar.IconColor = Color.Black;
            this.btnBuscar.IconFont = IconFont.Auto;
            this.btnBuscar.IconSize = 15;
            this.btnBuscar.ImageAlign = ContentAlignment.MiddleLeft;
            this.btnBuscar.Location = new Point(665, 21);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new Size(75, 23);
            this.btnBuscar.Text = "   Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            this.dataGridTipos.AllowUserToAddRows = false;
            this.dataGridTipos.AllowUserToDeleteRows = false;
            this.dataGridTipos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridTipos.Location = new Point(6, 59);
            this.dataGridTipos.Name = "dataGridTipos";
            this.dataGridTipos.ReadOnly = true;
            this.dataGridTipos.Size = new Size(626, 286);
            this.btnNuevo.IconChar = IconChar.Plus;
            this.btnNuevo.IconColor = Color.Black;
            this.btnNuevo.IconFont = IconFont.Auto;
            this.btnNuevo.IconSize = 15;
            this.btnNuevo.ImageAlign = ContentAlignment.MiddleLeft;
            this.btnNuevo.Location = new Point(665, 72);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new Size(75, 23);
            this.btnNuevo.Text = " Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            this.btnModificar.IconChar = IconChar.Pen;
            this.btnModificar.IconColor = Color.Black;
            this.btnModificar.IconFont = IconFont.Auto;
            this.btnModificar.IconSize = 15;
            this.btnModificar.ImageAlign = ContentAlignment.MiddleLeft;
            this.btnModificar.Location = new Point(665, 128);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new Size(75, 23);
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            this.btnEliminar.IconChar = IconChar.Trash;
            this.btnEliminar.IconColor = Color.Black;
            this.btnEliminar.IconFont = IconFont.Auto;
            this.btnEliminar.IconSize = 15;
            this.btnEliminar.ImageAlign = ContentAlignment.MiddleLeft;
            this.btnEliminar.Location = new Point(665, 176);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new Size(75, 23);
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            this.tabPageLista.Controls.Add(this.btnEliminar);
            this.tabPageLista.Controls.Add(this.btnModificar);
            this.tabPageLista.Controls.Add(this.btnNuevo);
            this.tabPageLista.Controls.Add(this.btnBuscar);
            this.tabPageLista.Controls.Add(this.txtBusqueda);
            this.tabPageLista.Controls.Add(this.label2);
            this.tabPageLista.Controls.Add(this.dataGridTipos);
            this.tabPageAgregarEditar.Text = "Agregar / Editar";
            this.tabPageAgregarEditar.UseVisualStyleBackColor = true;
            this.label3.AutoSize = true;
            this.label3.Location = new Point(46, 50);
            this.label3.Text = "Nombre";
            this.txtNombre.Location = new Point(120, 42);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new Size(513, 23);
            this.btnGuardar.IconChar = IconChar.Save;
            this.btnGuardar.IconColor = Color.Black;
            this.btnGuardar.IconFont = IconFont.Auto;
            this.btnGuardar.IconSize = 15;
            this.btnGuardar.ImageAlign = ContentAlignment.MiddleLeft;
            this.btnGuardar.Location = new Point(674, 87);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new Size(75, 23);
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            this.btnCancelar.IconChar = IconChar.Cancel;
            this.btnCancelar.IconColor = Color.Black;
            this.btnCancelar.IconFont = IconFont.Auto;
            this.btnCancelar.IconSize = 15;
            this.btnCancelar.ImageAlign = ContentAlignment.MiddleLeft;
            this.btnCancelar.Location = new Point(674, 182);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new Size(75, 23);
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            this.tabPageAgregarEditar.Controls.Add(this.txtNombre);
            this.tabPageAgregarEditar.Controls.Add(this.label3);
            this.tabPageAgregarEditar.Controls.Add(this.btnCancelar);
            this.tabPageAgregarEditar.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.label1);
            this.ResumeLayout(false);
        }


        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageLista;
        private System.Windows.Forms.TabPage tabPageAgregarEditar;
        private System.Windows.Forms.DataGridView dataGridTipos;
        private System.Windows.Forms.TextBox txtBusqueda;
        private System.Windows.Forms.Label label2;
        private FontAwesome.Sharp.IconButton btnBuscar;
        private FontAwesome.Sharp.IconButton btnNuevo;
        private FontAwesome.Sharp.IconButton btnModificar;
        private FontAwesome.Sharp.IconButton btnEliminar;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label3;
        private FontAwesome.Sharp.IconButton btnGuardar;
        private FontAwesome.Sharp.IconButton btnCancelar;
    }
}