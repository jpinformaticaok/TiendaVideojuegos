using DotNetEnv;
using Firebase.Auth;
using Firebase.Auth.Providers;
using FontAwesome.Sharp;

namespace Desktop.Views
{
    public partial class IniciarSesionView : Form
    {
        FirebaseAuthClient? firebaseAuthClient;
        string? authDomain, apiKey;
        int intentos = 0;

        private Label label1 = new Label();
        private Label label2 = new Label();
        private TextBox txtUsuario = new TextBox();
        private TextBox txtPassword = new TextBox();
        private CheckBox chkVerPassword = new CheckBox();
        private IconButton btnIniciarSesion = new IconButton();
        private IconButton btnCancelar = new IconButton();
        private PictureBox pictureBox1 = new PictureBox();

        public IniciarSesionView()
        {
            InitializeComponent();
            EnvConfig.Cargar();
            authDomain = Environment.GetEnvironmentVariable("AUTHDOMAINFB");
            apiKey = Environment.GetEnvironmentVariable("APIKEYFIREBASE");
            ConfiguracionFirebaseAuthClient();
        }

        private void InitializeComponent()
        {
            this.Text = "Iniciar Sesión";
            this.ClientSize = new Size(987, 355);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IniciarSesionView";

            pictureBox1.Image = CrearLogo();
            pictureBox1.Location = new Point(30, 38);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(313, 286);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabStop = false;

            label1.AutoSize = true;
            label1.Location = new Point(376, 67);
            label1.Name = "label1";
            label1.Size = new Size(47, 15);
            label1.Text = "Usuario";

            label2.AutoSize = true;
            label2.Location = new Point(376, 107);
            label2.Name = "label2";
            label2.Size = new Size(67, 15);
            label2.Text = "Contraseña";

            txtUsuario.Location = new Point(452, 59);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(478, 23);
            txtUsuario.TabIndex = 0;

            txtPassword.Location = new Point(452, 107);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(478, 23);
            txtPassword.TabIndex = 1;

            chkVerPassword.AutoSize = true;
            chkVerPassword.Location = new Point(452, 171);
            chkVerPassword.Name = "chkVerPassword";
            chkVerPassword.Size = new Size(105, 19);
            chkVerPassword.TabIndex = 2;
            chkVerPassword.Text = "Ver Contraseña";
            chkVerPassword.UseVisualStyleBackColor = true;
            chkVerPassword.CheckedChanged += chkVerPassword_CheckedChanged;

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
            btnIniciarSesion.Click += async (s, e) => await btnIniciarSesion_Click(s, e);

            btnCancelar.IconChar = IconChar.SignOut;
            btnCancelar.IconColor = Color.Black;
            btnCancelar.IconFont = IconFont.Auto;
            btnCancelar.IconSize = 15;
            btnCancelar.ImageAlign = ContentAlignment.MiddleRight;
            btnCancelar.Location = new Point(855, 217);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 4;
            btnCancelar.Text = "Cancelar";
            btnCancelar.TextAlign = ContentAlignment.MiddleLeft;
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += (s, e) => btnCancelar_Click(s, e);

            this.Controls.Add(pictureBox1);
            this.Controls.Add(label2);
            this.Controls.Add(label1);
            this.Controls.Add(txtPassword);
            this.Controls.Add(txtUsuario);
            this.Controls.Add(chkVerPassword);
            this.Controls.Add(btnIniciarSesion);
            this.Controls.Add(btnCancelar);

            this.AcceptButton = btnIniciarSesion;
            this.CancelButton = btnCancelar;
            this.ActiveControl = txtUsuario;
        }

        private Image CrearLogo()
        {
            var bmp = new Bitmap(313, 286);
            using (var g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.FromArgb(30, 30, 50));
                using var brush = new SolidBrush(Color.FromArgb(120, 180, 255));
                using var font = new Font("Segoe UI", 24F, FontStyle.Bold);
                using var font2 = new Font("Segoe UI", 12F, FontStyle.Regular);
                var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                g.DrawString("TIENDA", font, brush, new RectangleF(0, 70, 313, 50), sf);
                g.DrawString("VIDEOJUEGOS", font2, Brushes.White, new RectangleF(0, 125, 313, 40), sf);
                using var pen = new Pen(Color.FromArgb(120, 180, 255), 3);
                g.DrawRectangle(pen, 55, 190, 203, 35);
            }
            return bmp;
        }

        private void ConfiguracionFirebaseAuthClient()
        {
            if (string.IsNullOrWhiteSpace(apiKey) || string.IsNullOrWhiteSpace(authDomain))
                return;

            var config = new FirebaseAuthConfig
            {
                ApiKey = apiKey,
                AuthDomain = authDomain,
                Providers = new FirebaseAuthProvider[] { new EmailProvider() }
            };
            firebaseAuthClient = new FirebaseAuthClient(config);
        }

        private async Task btnIniciarSesion_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsuario.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Ingrese su usuario y contraseña.", "Iniciar Sesión", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (firebaseAuthClient == null)
            {
                MessageBox.Show("La configuración de Firebase no está disponible. Verifique el archivo .env.", "Iniciar Sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            btnIniciarSesion.Enabled = false;
            try
            {
                var user = await firebaseAuthClient.SignInWithEmailAndPasswordAsync(txtUsuario.Text.Trim(), txtPassword.Text);
                if (user == null)
                {
                    MessageBox.Show("Usuario o contraseña incorrectos.", "Iniciar Sesión", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                MessageBox.Show($"Bienvenido, {txtUsuario.Text}!", "Iniciar Sesión", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (FirebaseAuthException ex)
            {
                intentos++;
                MessageBox.Show($"Error al iniciar sesión: {ex.Reason}", "Iniciar Sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Clear();
                txtPassword.Focus();

                if (intentos >= 3)
                {
                    MessageBox.Show("Has alcanzado el número máximo de intentos. La aplicación se cerrará.", "Iniciar Sesión", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                }
            }
            finally
            {
                btnIniciarSesion.Enabled = true;
            }
        }

        private void btnCancelar_Click(object? sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void chkVerPassword_CheckedChanged(object? sender, EventArgs e)
        {
            txtPassword.PasswordChar = chkVerPassword.Checked ? '\0' : '*';
        }
    }
}