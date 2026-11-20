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
            menuStrip1 = new MenuStrip();
            iconMenuItem1 = new IconMenuItem();
            subMenuClientes = new IconMenuItem();
            subMenuProductos = new IconMenuItem();
            subMenuTiposProducto = new IconMenuItem();
            subMenuPlataformas = new IconMenuItem();
            subMenuFormatos = new IconMenuItem();
            subMenuVentas = new IconMenuItem();
            subMenuReportes = new IconMenuItem();
            subMenuListadoClientes = new IconMenuItem();
            subMenuListadoProductos = new IconMenuItem();
            iconMenuItem2 = new IconMenuItem();
            SubMenuSalirDelSistema = new IconMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { iconMenuItem1, subMenuReportes, iconMenuItem2 });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // iconMenuItem1
            // 
            iconMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { subMenuClientes, subMenuProductos, subMenuTiposProducto, subMenuPlataformas, subMenuFormatos, subMenuVentas });
            iconMenuItem1.IconChar = IconChar.House;
            iconMenuItem1.IconColor = Color.Black;
            iconMenuItem1.IconFont = IconFont.Auto;
            iconMenuItem1.Name = "iconMenuItem1";
            iconMenuItem1.Size = new Size(81, 20);
            iconMenuItem1.Text = "Principal";
            // 
            // subMenuClientes
            // 
            subMenuClientes.IconChar = IconChar.Users;
            subMenuClientes.IconColor = Color.Black;
            subMenuClientes.IconFont = IconFont.Auto;
            subMenuClientes.Name = "subMenuClientes";
            subMenuClientes.Size = new Size(171, 22);
            subMenuClientes.Text = "Clientes";
            subMenuClientes.Click += subMenuClientes_Click;
            // 
            // subMenuProductos
            // 
            subMenuProductos.IconChar = IconChar.Gamepad;
            subMenuProductos.IconColor = Color.Black;
            subMenuProductos.IconFont = IconFont.Auto;
            subMenuProductos.Name = "subMenuProductos";
            subMenuProductos.Size = new Size(171, 22);
            subMenuProductos.Text = "Productos";
            subMenuProductos.Click += subMenuProductos_Click;
            // 
            // subMenuTiposProducto
            // 
            subMenuTiposProducto.IconChar = IconChar.Tags;
            subMenuTiposProducto.IconColor = Color.Black;
            subMenuTiposProducto.IconFont = IconFont.Auto;
            subMenuTiposProducto.Name = "subMenuTiposProducto";
            subMenuTiposProducto.Size = new Size(171, 22);
            subMenuTiposProducto.Text = "Tipos de Producto";
            subMenuTiposProducto.Click += subMenuTiposProducto_Click;
            // 
            // subMenuPlataformas
            // 
            subMenuPlataformas.IconChar = IconChar.Desktop;
            subMenuPlataformas.IconColor = Color.Black;
            subMenuPlataformas.IconFont = IconFont.Auto;
            subMenuPlataformas.Name = "subMenuPlataformas";
            subMenuPlataformas.Size = new Size(171, 22);
            subMenuPlataformas.Text = "Plataformas";
            subMenuPlataformas.Click += subMenuPlataformas_Click;
            // 
            // subMenuFormatos
            // 
            subMenuFormatos.IconChar = IconChar.Box;
            subMenuFormatos.IconColor = Color.Black;
            subMenuFormatos.IconFont = IconFont.Auto;
            subMenuFormatos.Name = "subMenuFormatos";
            subMenuFormatos.Size = new Size(171, 22);
            subMenuFormatos.Text = "Formatos";
            subMenuFormatos.Click += subMenuFormatos_Click;
            // 
            // subMenuVentas
            // 
            subMenuVentas.IconChar = IconChar.CartShopping;
            subMenuVentas.IconColor = Color.Black;
            subMenuVentas.IconFont = IconFont.Auto;
            subMenuVentas.Name = "subMenuVentas";
            subMenuVentas.Size = new Size(171, 22);
            subMenuVentas.Text = "Ventas";
            subMenuVentas.Click += subMenuVentas_Click;
            // 
            // subMenuReportes
            // 
            subMenuReportes.DropDownItems.AddRange(new ToolStripItem[] { subMenuListadoClientes, subMenuListadoProductos });
            subMenuReportes.IconChar = IconChar.Print;
            subMenuReportes.IconColor = Color.Black;
            subMenuReportes.IconFont = IconFont.Auto;
            subMenuReportes.Name = "subMenuReportes";
            subMenuReportes.Size = new Size(81, 20);
            subMenuReportes.Text = "Reportes";
            // 
            // subMenuListadoClientes
            // 
            subMenuListadoClientes.IconChar = IconChar.PersonWalkingLuggage;
            subMenuListadoClientes.IconColor = Color.Black;
            subMenuListadoClientes.IconFont = IconFont.Auto;
            subMenuListadoClientes.Name = "subMenuListadoClientes";
            subMenuListadoClientes.Size = new Size(185, 22);
            subMenuListadoClientes.Text = "Listado de Clientes";
            subMenuListadoClientes.Click += subMenuListadoClientes_Click;
            // 
            // subMenuListadoProductos
            // 
            subMenuListadoProductos.IconChar = IconChar.Box;
            subMenuListadoProductos.IconColor = Color.Black;
            subMenuListadoProductos.IconFont = IconFont.Auto;
            subMenuListadoProductos.Name = "subMenuListadoProductos";
            subMenuListadoProductos.Size = new Size(185, 22);
            subMenuListadoProductos.Text = "Listado de Productos";
            subMenuListadoProductos.Click += subMenuListadoProductos_Click;
            // 
            // iconMenuItem2
            // 
            iconMenuItem2.DropDownItems.AddRange(new ToolStripItem[] { SubMenuSalirDelSistema });
            iconMenuItem2.IconChar = IconChar.DoorClosed;
            iconMenuItem2.IconColor = Color.Black;
            iconMenuItem2.IconFont = IconFont.Auto;
            iconMenuItem2.Name = "iconMenuItem2";
            iconMenuItem2.Size = new Size(57, 20);
            iconMenuItem2.Text = "Salir";
            // 
            // SubMenuSalirDelSistema
            // 
            SubMenuSalirDelSistema.IconChar = IconChar.DoorOpen;
            SubMenuSalirDelSistema.IconColor = Color.Black;
            SubMenuSalirDelSistema.IconFont = IconFont.Auto;
            SubMenuSalirDelSistema.Name = "SubMenuSalirDelSistema";
            SubMenuSalirDelSistema.Size = new Size(167, 22);
            SubMenuSalirDelSistema.Text = "Salir del sistema...";
            SubMenuSalirDelSistema.Click += SubMenuSalirDelSistema_Click;
            // 
            // MenuPrincipalView
            // 
            ClientSize = new Size(800, 450);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Name = "MenuPrincipalView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sistema de Tienda de Videojuegos - 2do año TSDS";
            WindowState = FormWindowState.Maximized;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private FontAwesome.Sharp.IconMenuItem iconMenuItem1;
        private FontAwesome.Sharp.IconMenuItem subMenuClientes;
        private FontAwesome.Sharp.IconMenuItem subMenuProductos;
        private FontAwesome.Sharp.IconMenuItem subMenuTiposProducto;
        private FontAwesome.Sharp.IconMenuItem subMenuPlataformas;
        private FontAwesome.Sharp.IconMenuItem subMenuFormatos;
        private FontAwesome.Sharp.IconMenuItem subMenuVentas;
        private FontAwesome.Sharp.IconMenuItem subMenuReportes;
        private FontAwesome.Sharp.IconMenuItem subMenuListadoClientes;
        private FontAwesome.Sharp.IconMenuItem subMenuListadoProductos;
        private FontAwesome.Sharp.IconMenuItem iconMenuItem2;
        private FontAwesome.Sharp.IconMenuItem SubMenuSalirDelSistema;
    }
}
