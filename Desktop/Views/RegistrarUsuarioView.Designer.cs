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
            panelTitulo = new Panel();
            lblTitulo = new Label();
            lblSubtitulo = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtEmail = new TextBox();
            txtPassword = new TextBox();
            txtRepetir = new TextBox();
            chkVerPassword = new CheckBox();
            btnCrear = new IconButton();
            btnCancelar = new IconButton();
            panelTitulo.SuspendLayout();
            SuspendLayout();
            // 
            // panelTitulo
            // 
            panelTitulo.BackColor = Color.FromArgb(30, 30, 50);
            panelTitulo.Controls.Add(lblTitulo);
            panelTitulo.Controls.Add(lblSubtitulo);
            panelTitulo.Dock = DockStyle.Top;
            panelTitulo.Location = new Point(0, 0);
            panelTitulo.Name = "panelTitulo";
            panelTitulo.Size = new Size(640, 70);
            panelTitulo.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.FromArgb(120, 180, 255);
            lblTitulo.Location = new Point(20, 12);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(154, 30);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Crear Usuario";
            // 
            // lblSubtitulo
            // 
            lblSubtitulo.AutoSize = true;
            lblSubtitulo.ForeColor = Color.White;
            lblSubtitulo.Location = new Point(23, 44);
            lblSubtitulo.Name = "lblSubtitulo";
            lblSubtitulo.Size = new Size(201, 15);
            lblSubtitulo.TabIndex = 1;
            lblSubtitulo.Text = "Registro con Firebase Authentication";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 95);
            label1.Name = "label1";
            label1.Size = new Size(36, 15);
            label1.TabIndex = 1;
            label1.Text = "Email";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(30, 137);
            label2.Name = "label2";
            label2.Size = new Size(67, 15);
            label2.TabIndex = 2;
            label2.Text = "Contraseña";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(30, 179);
            label3.Name = "label3";
            label3.Size = new Size(105, 15);
            label3.TabIndex = 3;
            label3.Text = "Repetir contraseña";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(160, 91);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(440, 23);
            txtEmail.TabIndex = 0;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(160, 133);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(440, 23);
            txtPassword.TabIndex = 1;
            // 
            // txtRepetir
            // 
            txtRepetir.Location = new Point(160, 175);
            txtRepetir.Name = "txtRepetir";
            txtRepetir.PasswordChar = '*';
            txtRepetir.Size = new Size(440, 23);
            txtRepetir.TabIndex = 2;
            // 
            // chkVerPassword
            // 
            chkVerPassword.AutoSize = true;
            chkVerPassword.Location = new Point(160, 210);
            chkVerPassword.Name = "chkVerPassword";
            chkVerPassword.Size = new Size(105, 19);
            chkVerPassword.TabIndex = 3;
            chkVerPassword.Text = "Ver Contraseña";
            chkVerPassword.UseVisualStyleBackColor = true;
            chkVerPassword.CheckedChanged += chkVerPassword_CheckedChanged;
            // 
            // btnCrear
            // 
            btnCrear.IconChar = IconChar.UserPlus;
            btnCrear.IconColor = Color.Black;
            btnCrear.IconFont = IconFont.Auto;
            btnCrear.IconSize = 15;
            btnCrear.ImageAlign = ContentAlignment.MiddleLeft;
            btnCrear.Location = new Point(390, 265);
            btnCrear.Name = "btnCrear";
            btnCrear.Size = new Size(103, 30);
            btnCrear.TabIndex = 4;
            btnCrear.Text = "Crear Usuario";
            btnCrear.TextAlign = ContentAlignment.MiddleRight;
            btnCrear.UseVisualStyleBackColor = true;
            btnCrear.Click += btnCrear_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.IconChar = IconChar.SignOut;
            btnCancelar.IconColor = Color.Black;
            btnCancelar.IconFont = IconFont.Auto;
            btnCancelar.IconSize = 15;
            btnCancelar.ImageAlign = ContentAlignment.MiddleRight;
            btnCancelar.Location = new Point(520, 265);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(80, 30);
            btnCancelar.TabIndex = 5;
            btnCancelar.Text = "Cancelar";
            btnCancelar.TextAlign = ContentAlignment.MiddleLeft;
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // RegistrarUsuarioView
            // 
            AcceptButton = btnCrear;
            CancelButton = btnCancelar;
            ClientSize = new Size(640, 316);
            Controls.Add(panelTitulo);
            Controls.Add(label1);
            Controls.Add(txtEmail);
            Controls.Add(label2);
            Controls.Add(txtPassword);
            Controls.Add(label3);
            Controls.Add(txtRepetir);
            Controls.Add(chkVerPassword);
            Controls.Add(btnCrear);
            Controls.Add(btnCancelar);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "RegistrarUsuarioView";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Crear Usuario";
            panelTitulo.ResumeLayout(false);
            panelTitulo.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
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