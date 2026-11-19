using Firebase.Auth;
using Firebase.Auth.Providers;
using FontAwesome.Sharp;

namespace Desktop.Views
{
    public partial class RegistrarUsuarioView : Form
    {
        private FirebaseAuthClient? firebaseAuthClient;
        private string? authDomain, apiKey;


        public string EmailCreado { get; private set; } = string.Empty;

        public RegistrarUsuarioView()
        {
            InitializeComponent();
            EnvConfig.Cargar();
            authDomain = Environment.GetEnvironmentVariable("AUTHDOMAINFB");
            apiKey = Environment.GetEnvironmentVariable("APIKEYFIREBASE");
            ConfiguracionFirebaseAuthClient();
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

        private async void btnCrear_Click(object? sender, EventArgs e)
        {
            var email = txtEmail.Text.Trim();
            var password = txtPassword.Text;
            var repetir = txtRepetir.Text;

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(repetir))
            {
                MessageBox.Show("Complete email, contraseña y repetición de contraseña.", "Crear Usuario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!email.Contains('@') || !email.Contains('.'))
            {
                MessageBox.Show("Ingrese un email válido.", "Crear Usuario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmail.Focus();
                return;
            }

            if (password.Length < 6)
            {
                MessageBox.Show("La contraseña debe tener al menos 6 caracteres.", "Crear Usuario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
                return;
            }

            if (password != repetir)
            {
                MessageBox.Show("Las contraseñas no coinciden.", "Crear Usuario", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRepetir.Clear();
                txtRepetir.Focus();
                return;
            }

            if (firebaseAuthClient == null)
            {
                MessageBox.Show("La configuración de Firebase no está disponible. Verifique el archivo .env.", "Crear Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            btnCrear.Enabled = false;
            btnCancelar.Enabled = false;
            this.Cursor = Cursors.WaitCursor;
            try
            {
                await firebaseAuthClient.CreateUserWithEmailAndPasswordAsync(email, password);

                EmailCreado = email;
                MessageBox.Show($"Usuario creado correctamente: {email}\nYa puede iniciar sesión.", "Crear Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (FirebaseAuthException ex)
            {
                string mensaje = ex.Reason switch
                {
                    AuthErrorReason.EmailExists => "Ya existe un usuario registrado con ese email.",
                    AuthErrorReason.WeakPassword => "La contraseña es demasiado débil. Use al menos 6 caracteres.",
                    AuthErrorReason.InvalidEmailAddress => "El email ingresado no es válido.",
                    AuthErrorReason.OperationNotAllowed => "El registro con email y contraseña no está habilitado en Firebase.",
                    AuthErrorReason.TooManyAttemptsTryLater => "Demasiados intentos. Intente nuevamente más tarde.",
                    _ => $"No se pudo crear el usuario: {ex.Reason}"
                };
                MessageBox.Show(mensaje, "Crear Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo crear el usuario: " + ex.Message, "Crear Usuario", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
                btnCrear.Enabled = true;
                btnCancelar.Enabled = true;
            }
        }

        private void btnCancelar_Click(object? sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void chkVerPassword_CheckedChanged(object? sender, EventArgs e)
        {
            var c = chkVerPassword.Checked ? '\0' : '*';
            txtPassword.PasswordChar = c;
            txtRepetir.PasswordChar = c;
        }
    }
}
