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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(IniciarSesionView));
            label1 = new Label();
            label2 = new Label();
            txtUsuario = new TextBox();
            txtPassword = new TextBox();
            chkVerPassword = new CheckBox();
            btnIniciarSesion = new IconButton();
            btnCrearUsuario = new IconButton();
            btnCancelar = new IconButton();
            pictureBox1 = new PictureBox();
            ((ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(376, 67);
            label1.Name = "label1";
            label1.Size = new Size(47, 15);
            label1.TabIndex = 2;
            label1.Text = "Usuario";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(376, 107);
            label2.Name = "label2";
            label2.Size = new Size(67, 15);
            label2.TabIndex = 1;
            label2.Text = "Contraseña";
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(452, 59);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(397, 23);
            txtUsuario.TabIndex = 0;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(452, 107);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(397, 23);
            txtPassword.TabIndex = 1;
            // 
            // chkVerPassword
            // 
            chkVerPassword.AutoSize = true;
            chkVerPassword.Location = new Point(452, 171);
            chkVerPassword.Name = "chkVerPassword";
            chkVerPassword.Size = new Size(103, 19);
            chkVerPassword.TabIndex = 2;
            chkVerPassword.Text = "Ver contraseña";
            chkVerPassword.UseVisualStyleBackColor = true;
            chkVerPassword.CheckedChanged += chkVerPassword_CheckedChanged;
            // 
            // btnIniciarSesion
            // 
            btnIniciarSesion.IconChar = IconChar.Unlock;
            btnIniciarSesion.IconColor = Color.Black;
            btnIniciarSesion.IconFont = IconFont.Auto;
            btnIniciarSesion.IconSize = 15;
            btnIniciarSesion.ImageAlign = ContentAlignment.MiddleLeft;
            btnIniciarSesion.Location = new Point(472, 217);
            btnIniciarSesion.Name = "btnIniciarSesion";
            btnIniciarSesion.Size = new Size(97, 23);
            btnIniciarSesion.TabIndex = 3;
            btnIniciarSesion.Text = "Iniciar Sesión";
            btnIniciarSesion.TextAlign = ContentAlignment.MiddleRight;
            btnIniciarSesion.UseVisualStyleBackColor = true;
            btnIniciarSesion.Click += btnIniciarSesion_Click;
            // 
            // btnCrearUsuario
            // 
            btnCrearUsuario.IconChar = IconChar.UserPlus;
            btnCrearUsuario.IconColor = Color.Black;
            btnCrearUsuario.IconFont = IconFont.Auto;
            btnCrearUsuario.IconSize = 15;
            btnCrearUsuario.ImageAlign = ContentAlignment.MiddleLeft;
            btnCrearUsuario.Location = new Point(584, 217);
            btnCrearUsuario.Name = "btnCrearUsuario";
            btnCrearUsuario.Size = new Size(102, 23);
            btnCrearUsuario.TabIndex = 4;
            btnCrearUsuario.Text = "Crear Usuario";
            btnCrearUsuario.TextAlign = ContentAlignment.MiddleRight;
            btnCrearUsuario.UseVisualStyleBackColor = true;
            btnCrearUsuario.Click += btnCrearUsuario_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.IconChar = IconChar.SignOut;
            btnCancelar.IconColor = Color.Black;
            btnCancelar.IconFont = IconFont.Auto;
            btnCancelar.IconSize = 15;
            btnCancelar.ImageAlign = ContentAlignment.MiddleRight;
            btnCancelar.Location = new Point(704, 217);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(90, 23);
            btnCancelar.TabIndex = 5;
            btnCancelar.Text = "Cancelar";
            btnCancelar.TextAlign = ContentAlignment.MiddleLeft;
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(30, 38);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(313, 286);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // IniciarSesionView
            // 
            AcceptButton = btnIniciarSesion;
            CancelButton = btnCancelar;
            ClientSize = new Size(890, 355);
            Controls.Add(pictureBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtPassword);
            Controls.Add(txtUsuario);
            Controls.Add(chkVerPassword);
            Controls.Add(btnIniciarSesion);
            Controls.Add(btnCrearUsuario);
            Controls.Add(btnCancelar);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "IniciarSesionView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Iniciar Sesión";
            ((ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
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