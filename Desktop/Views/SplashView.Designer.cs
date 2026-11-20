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
            components = new Container();
            pbSplash = new ProgressBar();
            timer1 = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // pbSplash
            // 
            pbSplash.Location = new Point(109, 322);
            pbSplash.Name = "pbSplash";
            pbSplash.Size = new Size(585, 12);
            pbSplash.Step = 20;
            pbSplash.TabIndex = 0;
            // 
            // timer1
            // 
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // SplashView
            // 
            BackColor = SystemColors.ActiveCaption;
            BackgroundImage = Properties.Resources.logo_grande;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 354);
            ControlBox = false;
            Controls.Add(pbSplash);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "SplashView";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SplashView";
            Activated += SplashView_Activated;
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.ProgressBar pbSplash;
        private System.Windows.Forms.Timer timer1;
    }
}