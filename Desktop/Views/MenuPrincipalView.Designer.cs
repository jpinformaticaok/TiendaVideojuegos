using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace Desktop.Views
{
    partial class MenuPrincipalView
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.iconMenuItem1 = new FontAwesome.Sharp.IconMenuItem();
            this.subMenuClientes = new FontAwesome.Sharp.IconMenuItem();
            this.subMenuProductos = new FontAwesome.Sharp.IconMenuItem();
            this.subMenuTiposProducto = new FontAwesome.Sharp.IconMenuItem();
            this.subMenuVentas = new FontAwesome.Sharp.IconMenuItem();
            this.subMenuReportes = new FontAwesome.Sharp.IconMenuItem();
            this.subMenuListadoClientes = new FontAwesome.Sharp.IconMenuItem();
            this.subMenuListadoProductos = new FontAwesome.Sharp.IconMenuItem();
            this.iconMenuItem2 = new FontAwesome.Sharp.IconMenuItem();
            this.SubMenuSalirDelSistema = new FontAwesome.Sharp.IconMenuItem();
            this.SuspendLayout();
            //
            // menuStrip1
            //
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iconMenuItem1,
            this.subMenuReportes,
            this.iconMenuItem2});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            //
            // iconMenuItem1
            //
            this.iconMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subMenuClientes,
            this.subMenuProductos,
            this.subMenuTiposProducto,
            this.subMenuVentas});
            this.iconMenuItem1.IconChar = FontAwesome.Sharp.IconChar.House;
            this.iconMenuItem1.IconColor = System.Drawing.Color.Black;
            this.iconMenuItem1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconMenuItem1.Name = "iconMenuItem1";
            this.iconMenuItem1.Size = new System.Drawing.Size(81, 20);
            this.iconMenuItem1.Text = "Principal";
            //
            // subMenuClientes
            //
            this.subMenuClientes.IconChar = FontAwesome.Sharp.IconChar.Users;
            this.subMenuClientes.IconColor = System.Drawing.Color.Black;
            this.subMenuClientes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.subMenuClientes.Name = "subMenuClientes";
            this.subMenuClientes.Size = new System.Drawing.Size(224, 22);
            this.subMenuClientes.Text = "Clientes";
            this.subMenuClientes.Click += new System.EventHandler(this.subMenuClientes_Click);
            //
            // subMenuProductos
            //
            this.subMenuProductos.IconChar = FontAwesome.Sharp.IconChar.Gamepad;
            this.subMenuProductos.IconColor = System.Drawing.Color.Black;
            this.subMenuProductos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.subMenuProductos.Name = "subMenuProductos";
            this.subMenuProductos.Size = new System.Drawing.Size(224, 22);
            this.subMenuProductos.Text = "Productos";
            this.subMenuProductos.Click += new System.EventHandler(this.subMenuProductos_Click);
            //
            // subMenuTiposProducto
            //
            this.subMenuTiposProducto.IconChar = FontAwesome.Sharp.IconChar.Tags;
            this.subMenuTiposProducto.IconColor = System.Drawing.Color.Black;
            this.subMenuTiposProducto.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.subMenuTiposProducto.Name = "subMenuTiposProducto";
            this.subMenuTiposProducto.Size = new System.Drawing.Size(224, 22);
            this.subMenuTiposProducto.Text = "Tipos de Producto";
            this.subMenuTiposProducto.Click += new System.EventHandler(this.subMenuTiposProducto_Click);
            //
            // subMenuVentas
            //
            this.subMenuVentas.IconChar = FontAwesome.Sharp.IconChar.ShoppingCart;
            this.subMenuVentas.IconColor = System.Drawing.Color.Black;
            this.subMenuVentas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.subMenuVentas.Name = "subMenuVentas";
            this.subMenuVentas.Size = new System.Drawing.Size(224, 22);
            this.subMenuVentas.Text = "Ventas";
            this.subMenuVentas.Click += new System.EventHandler(this.subMenuVentas_Click);
            //
            // subMenuReportes
            //
            this.subMenuReportes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subMenuListadoClientes,
            this.subMenuListadoProductos});
            this.subMenuReportes.IconChar = FontAwesome.Sharp.IconChar.Print;
            this.subMenuReportes.IconColor = System.Drawing.Color.Black;
            this.subMenuReportes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.subMenuReportes.Name = "subMenuReportes";
            this.subMenuReportes.Size = new System.Drawing.Size(81, 20);
            this.subMenuReportes.Text = "Reportes";
            //
            // subMenuListadoClientes
            //
            this.subMenuListadoClientes.IconChar = FontAwesome.Sharp.IconChar.PersonWalkingLuggage;
            this.subMenuListadoClientes.IconColor = System.Drawing.Color.Black;
            this.subMenuListadoClientes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.subMenuListadoClientes.Name = "subMenuListadoClientes";
            this.subMenuListadoClientes.Size = new System.Drawing.Size(224, 22);
            this.subMenuListadoClientes.Text = "Listado de Clientes";
            this.subMenuListadoClientes.Click += new System.EventHandler(this.subMenuListadoClientes_Click);
            //
            // subMenuListadoProductos
            //
            this.subMenuListadoProductos.IconChar = FontAwesome.Sharp.IconChar.Box;
            this.subMenuListadoProductos.IconColor = System.Drawing.Color.Black;
            this.subMenuListadoProductos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.subMenuListadoProductos.Name = "subMenuListadoProductos";
            this.subMenuListadoProductos.Size = new System.Drawing.Size(224, 22);
            this.subMenuListadoProductos.Text = "Listado de Productos";
            this.subMenuListadoProductos.Click += new System.EventHandler(this.subMenuListadoProductos_Click);
            //
            // iconMenuItem2
            //
            this.iconMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SubMenuSalirDelSistema});
            this.iconMenuItem2.IconChar = FontAwesome.Sharp.IconChar.DoorClosed;
            this.iconMenuItem2.IconColor = System.Drawing.Color.Black;
            this.iconMenuItem2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconMenuItem2.Name = "iconMenuItem2";
            this.iconMenuItem2.Size = new System.Drawing.Size(57, 20);
            this.iconMenuItem2.Text = "Salir";
            //
            // SubMenuSalirDelSistema
            //
            this.SubMenuSalirDelSistema.IconChar = FontAwesome.Sharp.IconChar.DoorOpen;
            this.SubMenuSalirDelSistema.IconColor = System.Drawing.Color.Black;
            this.SubMenuSalirDelSistema.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.SubMenuSalirDelSistema.Name = "SubMenuSalirDelSistema";
            this.SubMenuSalirDelSistema.Size = new System.Drawing.Size(224, 22);
            this.SubMenuSalirDelSistema.Text = "Salir del sistema...";
            this.SubMenuSalirDelSistema.Click += new System.EventHandler(this.SubMenuSalirDelSistema_Click);
            //
            // MenuPrincipalView
            //
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MenuPrincipalView";
            this.Text = "Sistema de Tienda de Videojuegos - 2do año TSDS";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private FontAwesome.Sharp.IconMenuItem iconMenuItem1;
        private FontAwesome.Sharp.IconMenuItem subMenuClientes;
        private FontAwesome.Sharp.IconMenuItem subMenuProductos;
        private FontAwesome.Sharp.IconMenuItem subMenuTiposProducto;
        private FontAwesome.Sharp.IconMenuItem subMenuVentas;
        private FontAwesome.Sharp.IconMenuItem subMenuReportes;
        private FontAwesome.Sharp.IconMenuItem subMenuListadoClientes;
        private FontAwesome.Sharp.IconMenuItem subMenuListadoProductos;
        private FontAwesome.Sharp.IconMenuItem iconMenuItem2;
        private FontAwesome.Sharp.IconMenuItem SubMenuSalirDelSistema;
    }
}
