using DotNetEnv;
using Firebase.Auth;
using Firebase.Auth.Providers;

namespace Desktop.Views
{
    public partial class IniciarSesionView : Form
    {
        FirebaseAuthClient? firebaseAuthClient;
        string? authDomain, apiKey;
        int intentos = 0;

        TextBox txtUsuario = new TextBox();
        TextBox txtPassword = new TextBox();
        CheckBox chkVerPassword = new CheckBox();
        Button btnIniciarSesion = new Button();
        Button btnCancelar = new Button();

        public IniciarSesionView()
        {
            InitializeComponent();
            Env.Load("../../../");
            authDomain = Environment.GetEnvironmentVariable("AUTHDOMAINFB");
            apiKey = Environment.GetEnvironmentVariable("APIKEYFIREBASE");
            ConfiguracionFirebaseAuthClient();
        }

        private void InitializeComponent()
        {
            this.Text = "Iniciar Sesión";
            this.Size = new Size(360, 220);
            this.StartPosition = FormStartPosition.CenterScreen;
            var lblU = new Label { Text = "Usuario", Left = 20, Top = 20, Width = 80 };
            txtUsuario.Left = 110; txtUsuario.Top = 20; txtUsuario.Width = 200;
            var lblP = new Label { Text = "Contraseña", Left = 20, Top = 60, Width = 80 };
            txtPassword.Left = 110; txtPassword.Top = 60; txtPassword.Width = 200; txtPassword.PasswordChar = '*';
            chkVerPassword.Text = "Ver contraseña"; chkVerPassword.Left = 110; chkVerPassword.Top = 90;
            chkVerPassword.CheckedChanged += chkVerPassword_CheckedChanged;
            btnIniciarSesion.Text = "Iniciar Sesión"; btnIniciarSesion.Left = 110; btnIniciarSesion.Top = 120;
            btnIniciarSesion.Click += async (s, e) => await btnIniciarSesion_Click(s, e);
            btnCancelar.Text = "Cancelar"; btnCancelar.Left = 220; btnCancelar.Top = 120;
            btnCancelar.Click += (s, e) => btnCancelar_Click(s, e);
            this.Controls.AddRange(new Control[] { lblU, txtUsuario, lblP, txtPassword, chkVerPassword, btnIniciarSesion, btnCancelar });
        }

        private void ConfiguracionFirebaseAuthClient()
        {
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
            intentos++;
            try
            {
                var user = await firebaseAuthClient!.SignInWithEmailAndPasswordAsync(txtUsuario.Text, txtPassword.Text);
                if (user == null)
                {
                    MessageBox.Show("Usuario o contraseña incorrectos.");
                    return;
                }
                MessageBox.Show($"Bienvenido, {txtUsuario.Text}!");
                this.Hide();
                var mainView = new MenuPrincipalView();
                mainView.Show();
            }
            catch (FirebaseAuthException ex)
            {
                MessageBox.Show($"Error al iniciar sesión: {ex.Reason}");
            }
            if (intentos >= 3)
            {
                MessageBox.Show("Has alcanzado el número máximo de intentos. La aplicación se cerrará.");
                Application.Exit();
            }
        }

        private void btnCancelar_Click(object? sender, EventArgs e)
        {
            this.Close();
        }

        private void chkVerPassword_CheckedChanged(object? sender, EventArgs e)
        {
            txtPassword.PasswordChar = chkVerPassword.Checked ? '\0' : '*';
        }
    }
}