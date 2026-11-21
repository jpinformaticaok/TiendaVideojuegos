namespace Desktop.ViewReports
{
    partial class ProductosAgrupadosViewReport
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

        private void InitializeComponent()
        {
            this.panelFiltros = new System.Windows.Forms.Panel();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.txtBusqueda = new System.Windows.Forms.TextBox();
            this.lblAgrupar = new System.Windows.Forms.Label();
            this.cmbAgruparPor = new System.Windows.Forms.ComboBox();
            this.lblPlataforma = new System.Windows.Forms.Label();
            this.cmbPlataforma = new System.Windows.Forms.ComboBox();
            this.lblFormato = new System.Windows.Forms.Label();
            this.cmbFormato = new System.Windows.Forms.ComboBox();
            this.lblTipo = new System.Windows.Forms.Label();
            this.cmbTipo = new System.Windows.Forms.ComboBox();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panelFiltros.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelFiltros
            // 
            this.panelFiltros.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.panelFiltros.Controls.Add(this.lblBuscar);
            this.panelFiltros.Controls.Add(this.txtBusqueda);
            this.panelFiltros.Controls.Add(this.lblAgrupar);
            this.panelFiltros.Controls.Add(this.cmbAgruparPor);
            this.panelFiltros.Controls.Add(this.lblPlataforma);
            this.panelFiltros.Controls.Add(this.cmbPlataforma);
            this.panelFiltros.Controls.Add(this.lblFormato);
            this.panelFiltros.Controls.Add(this.cmbFormato);
            this.panelFiltros.Controls.Add(this.lblTipo);
            this.panelFiltros.Controls.Add(this.cmbTipo);
            this.panelFiltros.Controls.Add(this.btnGenerar);
            this.panelFiltros.Controls.Add(this.btnLimpiar);
            this.panelFiltros.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFiltros.Location = new System.Drawing.Point(0, 0);
            this.panelFiltros.Name = "panelFiltros";
            this.panelFiltros.Size = new System.Drawing.Size(1100, 86);
            this.panelFiltros.TabIndex = 1;
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Location = new System.Drawing.Point(12, 10);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(42, 15);
            this.lblBuscar.TabIndex = 0;
            this.lblBuscar.Text = "Buscar";
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.Location = new System.Drawing.Point(12, 30);
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.PlaceholderText = "Nombre o descripcion";
            this.txtBusqueda.Size = new System.Drawing.Size(170, 23);
            this.txtBusqueda.TabIndex = 1;
            // 
            // lblAgrupar
            // 
            this.lblAgrupar.AutoSize = true;
            this.lblAgrupar.Location = new System.Drawing.Point(194, 10);
            this.lblAgrupar.Name = "lblAgrupar";
            this.lblAgrupar.Size = new System.Drawing.Size(72, 15);
            this.lblAgrupar.TabIndex = 2;
            this.lblAgrupar.Text = "Agrupar por";
            // 
            // cmbAgruparPor
            // 
            this.cmbAgruparPor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAgruparPor.FormattingEnabled = true;
            this.cmbAgruparPor.Location = new System.Drawing.Point(194, 30);
            this.cmbAgruparPor.Name = "cmbAgruparPor";
            this.cmbAgruparPor.Size = new System.Drawing.Size(120, 23);
            this.cmbAgruparPor.TabIndex = 3;
            // 
            // lblPlataforma
            // 
            this.lblPlataforma.AutoSize = true;
            this.lblPlataforma.Location = new System.Drawing.Point(326, 10);
            this.lblPlataforma.Name = "lblPlataforma";
            this.lblPlataforma.Size = new System.Drawing.Size(62, 15);
            this.lblPlataforma.TabIndex = 4;
            this.lblPlataforma.Text = "Plataforma";
            // 
            // cmbPlataforma
            // 
            this.cmbPlataforma.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPlataforma.FormattingEnabled = true;
            this.cmbPlataforma.Location = new System.Drawing.Point(326, 30);
            this.cmbPlataforma.Name = "cmbPlataforma";
            this.cmbPlataforma.Size = new System.Drawing.Size(130, 23);
            this.cmbPlataforma.TabIndex = 5;
            // 
            // lblFormato
            // 
            this.lblFormato.AutoSize = true;
            this.lblFormato.Location = new System.Drawing.Point(468, 10);
            this.lblFormato.Name = "lblFormato";
            this.lblFormato.Size = new System.Drawing.Size(50, 15);
            this.lblFormato.TabIndex = 6;
            this.lblFormato.Text = "Formato";
            // 
            // cmbFormato
            // 
            this.cmbFormato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFormato.FormattingEnabled = true;
            this.cmbFormato.Location = new System.Drawing.Point(468, 30);
            this.cmbFormato.Name = "cmbFormato";
            this.cmbFormato.Size = new System.Drawing.Size(120, 23);
            this.cmbFormato.TabIndex = 7;
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(600, 10);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(30, 15);
            this.lblTipo.TabIndex = 8;
            this.lblTipo.Text = "Tipo";
            // 
            // cmbTipo
            // 
            this.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipo.FormattingEnabled = true;
            this.cmbTipo.Location = new System.Drawing.Point(600, 30);
            this.cmbTipo.Name = "cmbTipo";
            this.cmbTipo.Size = new System.Drawing.Size(130, 23);
            this.cmbTipo.TabIndex = 9;
            // 
            // btnGenerar
            // 
            this.btnGenerar.Location = new System.Drawing.Point(748, 29);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(105, 28);
            this.btnGenerar.TabIndex = 10;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(863, 29);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(100, 28);
            this.btnLimpiar.TabIndex = 11;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.Location = new System.Drawing.Point(0, 86);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1100, 614);
            this.reportViewer1.TabIndex = 0;
            // 
            // ProductosAgrupadosViewReport
            // 
            this.ClientSize = new System.Drawing.Size(1100, 700);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.panelFiltros);
            this.MinimumSize = new System.Drawing.Size(900, 500);
            this.Name = "ProductosAgrupadosViewReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Productos agrupados";
            this.Load += new System.EventHandler(this.ProductosAgrupadosViewReport_Load);
            this.panelFiltros.ResumeLayout(false);
            this.panelFiltros.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelFiltros;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBusqueda;
        private System.Windows.Forms.Label lblAgrupar;
        private System.Windows.Forms.ComboBox cmbAgruparPor;
        private System.Windows.Forms.Label lblPlataforma;
        private System.Windows.Forms.ComboBox cmbPlataforma;
        private System.Windows.Forms.Label lblFormato;
        private System.Windows.Forms.ComboBox cmbFormato;
        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.ComboBox cmbTipo;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.Button btnLimpiar;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}
