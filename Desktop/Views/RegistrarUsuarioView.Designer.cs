using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace Desktop.Views
{
    partial class RegistrarUsuarioView
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
            this.panelTitulo = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtRepetir = new System.Windows.Forms.TextBox();
            this.chkVerPassword = new System.Windows.Forms.CheckBox();
            this.btnCrear = new FontAwesome.Sharp.IconButton();
            this.btnCancelar = new FontAwesome.Sharp.IconButton();
            this.SuspendLayout();
            this.Text = "Crear Usuario";
            this.ClientSize = new Size(640, 350);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RegistrarUsuarioView";
            this.panelTitulo.BackColor = Color.FromArgb(30, 30, 50);
            this.panelTitulo.Dock = DockStyle.Top;
            this.panelTitulo.Height = 70;
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.lblTitulo.ForeColor = Color.FromArgb(120, 180, 255);
            this.lblTitulo.Location = new Point(20, 12);
            this.lblTitulo.Text = "Crear Usuario";
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.ForeColor = Color.White;
            this.lblSubtitulo.Location = new Point(23, 44);
            this.lblSubtitulo.Text = "Registro con Firebase Authentication";
            this.panelTitulo.Controls.Add(this.lblTitulo);
            this.panelTitulo.Controls.Add(this.lblSubtitulo);
            this.label1.AutoSize = true;
            this.label1.Location = new Point(30, 95);
            this.label1.Text = "Email";
            this.txtEmail.Location = new Point(160, 91);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new Size(440, 23);
            this.txtEmail.TabIndex = 0;
            this.label2.AutoSize = true;
            this.label2.Location = new Point(30, 137);
            this.label2.Text = "Contraseña";
            this.txtPassword.Location = new Point(160, 133);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new Size(440, 23);
            this.txtPassword.TabIndex = 1;
            this.label3.AutoSize = true;
            this.label3.Location = new Point(30, 179);
            this.label3.Text = "Repetir contraseña";
            this.txtRepetir.Location = new Point(160, 175);
            this.txtRepetir.Name = "txtRepetir";
            this.txtRepetir.PasswordChar = '*';
            this.txtRepetir.Size = new Size(440, 23);
            this.txtRepetir.TabIndex = 2;
            this.chkVerPassword.AutoSize = true;
            this.chkVerPassword.Location = new Point(160, 210);
            this.chkVerPassword.Name = "chkVerPassword";
            this.chkVerPassword.Size = new Size(105, 19);
            this.chkVerPassword.TabIndex = 3;
            this.chkVerPassword.Text = "Ver Contraseña";
            this.chkVerPassword.UseVisualStyleBackColor = true;
            this.chkVerPassword.CheckedChanged += new System.EventHandler(this.chkVerPassword_CheckedChanged);
            this.btnCrear.IconChar = IconChar.UserPlus;
            this.btnCrear.IconColor = Color.Black;
            this.btnCrear.IconFont = IconFont.Auto;
            this.btnCrear.IconSize = 15;
            this.btnCrear.ImageAlign = ContentAlignment.MiddleLeft;
            this.btnCrear.Location = new Point(390, 265);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new Size(120, 30);
            this.btnCrear.TabIndex = 4;
            this.btnCrear.Text = "Crear Usuario";
            this.btnCrear.TextAlign = ContentAlignment.MiddleRight;
            this.btnCrear.UseVisualStyleBackColor = true;
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
            this.btnCancelar.IconChar = IconChar.SignOut;
            this.btnCancelar.IconColor = Color.Black;
            this.btnCancelar.IconFont = IconFont.Auto;
            this.btnCancelar.IconSize = 15;
            this.btnCancelar.ImageAlign = ContentAlignment.MiddleRight;
            this.btnCancelar.Location = new Point(520, 265);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new Size(80, 30);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = ContentAlignment.MiddleLeft;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            this.Controls.Add(this.panelTitulo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtRepetir);
            this.Controls.Add(this.chkVerPassword);
            this.Controls.Add(this.btnCrear);
            this.Controls.Add(this.btnCancelar);
            this.AcceptButton = btnCrear;
            this.CancelButton = btnCancelar;
            this.ActiveControl = txtEmail;
            this.ResumeLayout(false);
        }


        #endregion

        private System.Windows.Forms.Panel panelTitulo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblSubtitulo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtRepetir;
        private System.Windows.Forms.CheckBox chkVerPassword;
        private FontAwesome.Sharp.IconButton btnCrear;
        private FontAwesome.Sharp.IconButton btnCancelar;
    }
}