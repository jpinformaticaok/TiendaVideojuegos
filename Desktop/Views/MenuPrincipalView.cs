using Desktop.ViewReports;
using FontAwesome.Sharp;

namespace Desktop.Views
{
    public partial class MenuPrincipalView : Form
    {
        private MenuStrip menuStrip1 = new MenuStrip();

        public MenuPrincipalView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Sistema de Tienda de Videojuegos - 2do año TSDS";
            this.ClientSize = new Size(800, 450);
            this.IsMdiContainer = true;
            this.WindowState = FormWindowState.Maximized;
            this.Name = "MenuPrincipalView";

            var subMenuClientes = CreateItem("Clientes", IconChar.Users, (s, e) => OpenDialog(new ClientesView()));
            var subMenuProductos = CreateItem("Productos", IconChar.Gamepad, (s, e) => OpenMdi(new ProductosView()));
            var subMenuTiposProducto = CreateItem("Tipos de Producto", IconChar.Tags, (s, e) => OpenMdi(new TiposProductoView()));
            var subMenuVentas = CreateItem("Ventas", IconChar.ShoppingCart, (s, e) => OpenMdi(new VentasView()));

            var iconMenuItem1 = new IconMenuItem
            {
                IconChar = IconChar.House,
                IconColor = Color.Black,
                IconFont = IconFont.Auto,
                Name = "iconMenuItem1",
                Size = new Size(81, 20),
                Text = "Principal"
            };
            iconMenuItem1.DropDownItems.AddRange(new ToolStripItem[]
            {
                subMenuClientes, subMenuProductos, subMenuTiposProducto, subMenuVentas
            });

            var subMenuListadoClientes = CreateItem("Listado de Clientes", IconChar.PersonWalkingLuggage, (s, e) => new ClientesViewReport().ShowDialog());
            var subMenuListadoProductos = CreateItem("Listado de Productos", IconChar.Box, (s, e) => new ProductosViewReport().ShowDialog());

            var subMenuReportes = new IconMenuItem
            {
                IconChar = IconChar.Print,
                IconColor = Color.Black,
                IconFont = IconFont.Auto,
                Name = "subMenuReportes",
                Size = new Size(81, 20),
                Text = "Reportes"
            };
            subMenuReportes.DropDownItems.AddRange(new ToolStripItem[] { subMenuListadoClientes, subMenuListadoProductos });

            var SubMenuSalirDelSistema = CreateItem("Salir del sistema...", IconChar.DoorOpen, (s, e) => Application.Exit());

            var iconMenuItem2 = new IconMenuItem
            {
                IconChar = IconChar.DoorClosed,
                IconColor = Color.Black,
                IconFont = IconFont.Auto,
                Name = "iconMenuItem2",
                Size = new Size(57, 20),
                Text = "Salir"
            };
            iconMenuItem2.DropDownItems.AddRange(new ToolStripItem[] { SubMenuSalirDelSistema });

            menuStrip1.Items.AddRange(new ToolStripItem[] { iconMenuItem1, subMenuReportes, iconMenuItem2 });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";

            this.MainMenuStrip = menuStrip1;
            this.Controls.Add(menuStrip1);
        }

        private IconMenuItem CreateItem(string text, IconChar icon, EventHandler handler)
        {
            var item = new IconMenuItem
            {
                IconChar = icon,
                IconColor = Color.Black,
                IconFont = IconFont.Auto,
                Size = new Size(224, 22),
                Text = text
            };
            item.Click += handler;
            return item;
        }

        private void OpenMdi(Form form)
        {
            form.MdiParent = this;
            form.Show();
        }

        private void OpenDialog(Form form)
        {
            form.ShowDialog();
        }
    }
}