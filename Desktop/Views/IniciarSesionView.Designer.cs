using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace Desktop.Views
{
    partial class IniciarSesionView
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.chkVerPassword = new System.Windows.Forms.CheckBox();
            this.btnIniciarSesion = new FontAwesome.Sharp.IconButton();
            this.btnCrearUsuario = new FontAwesome.Sharp.IconButton();
            this.btnCancelar = new FontAwesome.Sharp.IconButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.SuspendLayout();
            this.Text = "Iniciar Sesión";
            this.ClientSize = new Size(987, 355);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IniciarSesionView";
            this.pictureBox1.Location = new Point(30, 38);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Size(313, 286);
            this.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabStop = false;
            this.label1.AutoSize = true;
            this.label1.Location = new Point(376, 67);
            this.label1.Name = "label1";
            this.label1.Size = new Size(47, 15);
            this.label1.Text = "Usuario";
            this.label2.AutoSize = true;
            this.label2.Location = new Point(376, 107);
            this.label2.Name = "label2";
            this.label2.Size = new Size(67, 15);
            this.label2.Text = "Contraseña";
            this.txtUsuario.Location = new Point(452, 59);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new Size(478, 23);
            this.txtUsuario.TabIndex = 0;
            this.txtPassword.Location = new Point(452, 107);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new Size(478, 23);
            this.txtPassword.TabIndex = 1;
            this.chkVerPassword.AutoSize = true;
            this.chkVerPassword.Location = new Point(452, 171);
            this.chkVerPassword.Name = "chkVerPassword";
            this.chkVerPassword.Size = new Size(105, 19);
            this.chkVerPassword.TabIndex = 2;
            this.chkVerPassword.Text = "Ver Contraseña";
            this.chkVerPassword.UseVisualStyleBackColor = true;
            this.chkVerPassword.CheckedChanged += new System.EventHandler(this.chkVerPassword_CheckedChanged);
            this.btnIniciarSesion.IconChar = IconChar.Unlock;
            this.btnIniciarSesion.IconColor = Color.Black;
            this.btnIniciarSesion.IconFont = IconFont.Auto;
            this.btnIniciarSesion.IconSize = 15;
            this.btnIniciarSesion.ImageAlign = ContentAlignment.MiddleLeft;
            this.btnIniciarSesion.Location = new Point(472, 217);
            this.btnIniciarSesion.Name = "btnIniciarSesion";
            this.btnIniciarSesion.Size = new Size(97, 23);
            this.btnIniciarSesion.TabIndex = 3;
            this.btnIniciarSesion.Text = "Iniciar Sesión";
            this.btnIniciarSesion.TextAlign = ContentAlignment.MiddleRight;
            this.btnIniciarSesion.UseVisualStyleBackColor = true;
            this.btnIniciarSesion.Click += new System.EventHandler(this.btnIniciarSesion_Click);
            this.btnCrearUsuario.IconChar = IconChar.UserPlus;
            this.btnCrearUsuario.IconColor = Color.Black;
            this.btnCrearUsuario.IconFont = IconFont.Auto;
            this.btnCrearUsuario.IconSize = 15;
            this.btnCrearUsuario.ImageAlign = ContentAlignment.MiddleLeft;
            this.btnCrearUsuario.Location = new Point(584, 217);
            this.btnCrearUsuario.Name = "btnCrearUsuario";
            this.btnCrearUsuario.Size = new Size(130, 23);
            this.btnCrearUsuario.TabIndex = 4;
            this.btnCrearUsuario.Text = "Crear Usuario";
            this.btnCrearUsuario.TextAlign = ContentAlignment.MiddleRight;
            this.btnCrearUsuario.UseVisualStyleBackColor = true;
            this.btnCrearUsuario.Click += new System.EventHandler(this.btnCrearUsuario_Click);
            this.btnCancelar.IconChar = IconChar.SignOut;
            this.btnCancelar.IconColor = Color.Black;
            this.btnCancelar.IconFont = IconFont.Auto;
            this.btnCancelar.IconSize = 15;
            this.btnCancelar.ImageAlign = ContentAlignment.MiddleRight;
            this.btnCancelar.Location = new Point(730, 217);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new Size(90, 23);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = ContentAlignment.MiddleLeft;
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.chkVerPassword);
            this.Controls.Add(this.btnIniciarSesion);
            this.Controls.Add(this.btnCrearUsuario);
            this.Controls.Add(this.btnCancelar);
            this.AcceptButton = btnIniciarSesion;
            this.CancelButton = btnCancelar;
            this.ActiveControl = txtUsuario;
            this.ResumeLayout(false);
        }


        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.CheckBox chkVerPassword;
        private FontAwesome.Sharp.IconButton btnIniciarSesion;
        private FontAwesome.Sharp.IconButton btnCrearUsuario;
        private FontAwesome.Sharp.IconButton btnCancelar;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}