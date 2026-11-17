namespace Desktop.Views
{
    public partial class MenuPrincipalView : Form
    {
        public MenuPrincipalView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Menú Principal - Tienda Videojuegos";
            this.Size = new Size(600, 400);
            this.StartPosition = FormStartPosition.CenterScreen;
            var btnClientes = new Button { Text = "Clientes", Left = 20, Top = 20, Width = 150 };
            btnClientes.Click += (s, e) => new ClientesView().ShowDialog();
            var btnProductos = new Button { Text = "Productos", Left = 20, Top = 60, Width = 150 };
            btnProductos.Click += (s, e) => new ProductosView().ShowDialog();
            var btnVentas = new Button { Text = "Ventas", Left = 20, Top = 100, Width = 150 };
            btnVentas.Click += (s, e) => new VentasView().ShowDialog();
            var btnReportes = new Button { Text = "Reportes", Left = 20, Top = 140, Width = 150 };
            btnReportes.Click += (s, e) => new ReportesView().ShowDialog();
            this.Controls.AddRange(new Control[] { btnClientes, btnProductos, btnVentas, btnReportes });
        }
    }
}