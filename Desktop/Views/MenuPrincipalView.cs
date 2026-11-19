using Desktop.ViewReports;

namespace Desktop.Views
{
    public partial class MenuPrincipalView : Form
    {
        public MenuPrincipalView()
        {
            InitializeComponent();
        }

        private void subMenuClientes_Click(object? sender, EventArgs e)
        {
            OpenDialog(new ClientesView());
        }

        private void subMenuProductos_Click(object? sender, EventArgs e)
        {
            OpenMdi(new ProductosView());
        }

        private void subMenuTiposProducto_Click(object? sender, EventArgs e)
        {
            OpenMdi(new TiposProductoView());
        }

        private void subMenuVentas_Click(object? sender, EventArgs e)
        {
            OpenMdi(new VentasView());
        }

        private void subMenuListadoClientes_Click(object? sender, EventArgs e)
        {
            new ClientesViewReport().ShowDialog();
        }

        private void subMenuListadoProductos_Click(object? sender, EventArgs e)
        {
            new ProductosViewReport().ShowDialog();
        }

        private void SubMenuSalirDelSistema_Click(object? sender, EventArgs e)
        {
            Application.Exit();
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
