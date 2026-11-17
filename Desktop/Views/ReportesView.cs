using Microsoft.Reporting.WinForms;
using Services.Models;

namespace Desktop.Views
{
    public partial class ReportesView : Form
    {
        public ReportesView()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.Text = "Reportes";
            this.Size = new Size(800, 600);
            var rv = new ReportViewer { Dock = DockStyle.Fill };
            var clientes = new List<Cliente> { new Cliente { Id = 1, Firstname = "Juan", Lastname = "Pérez", Address = "Calle Falsa", Dni = "123" } };
            rv.LocalReport.ReportEmbeddedResource = "Desktop.Reports.Clientes.rdlc";
            rv.LocalReport.DataSources.Add(new ReportDataSource("DSClientes", clientes));
            rv.RefreshReport();
            this.Controls.Add(rv);
        }
    }
}