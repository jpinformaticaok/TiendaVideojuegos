using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace Desktop.Views
{
    partial class SplashView
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pbSplash = new System.Windows.Forms.ProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            this.Text = "SplashView";
            this.ClientSize = new Size(800, 450);
            this.BackColor = SystemColors.ActiveCaption;
            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Name = "SplashView";
            this.label1.AutoSize = true;
            this.label1.Font = new Font("Rockwell", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            this.label1.Location = new Point(12, 109);
            this.label1.Name = "label1";
            this.label1.Size = new Size(414, 59);
            this.label1.Text = "Tienda Videojuegos";
            this.pictureBox1.Location = new Point(321, 90);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new Size(478, 331);
            this.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabStop = false;
            this.pbSplash.Location = new Point(12, 369);
            this.pbSplash.Name = "pbSplash";
            this.pbSplash.Size = new Size(488, 52);
            this.pbSplash.Step = 20;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            this.Controls.Add(this.pbSplash);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Activated += new System.EventHandler(this.SplashView_Activated);
            this.ResumeLayout(false);
        }


        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ProgressBar pbSplash;
        private System.Windows.Forms.Timer timer1;
    }
}