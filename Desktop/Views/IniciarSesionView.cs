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


        public IniciarSesionView()
        {
            InitializeComponent();
            pictureBox1.Image = CrearLogo();
            EnvConfig.Cargar();
            authDomain = Environment.GetEnvironmentVariable("AUTHDOMAINFB");
            apiKey = Environment.GetEnvironmentVariable("APIKEYFIREBASE");
            ConfiguracionFirebaseAuthClient();
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

        private async void btnIniciarSesion_Click(object? sender, EventArgs e)
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

        private void btnCrearUsuario_Click(object? sender, EventArgs e)
        {
            using var registro = new RegistrarUsuarioView();
            if (registro.ShowDialog(this) == DialogResult.OK)
            {
                txtUsuario.Text = registro.EmailCreado;
                txtPassword.Clear();
                txtPassword.Focus();
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