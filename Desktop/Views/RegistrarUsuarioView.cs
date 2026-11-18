using Firebase.Auth;
using Firebase.Auth.Providers;
using FontAwesome.Sharp;

namespace Desktop.Views
{
    public partial class RegistrarUsuarioView : Form
    {
        private FirebaseAuthClient? firebaseAuthClient;
        private string? authDomain, apiKey;

        private Panel panelTitulo = new Panel();
        private Label lblTitulo = new Label();
        private Label lblSubtitulo = new Label();
        private Label label1 = new Label();
        private Label label2 = new Label();
        private Label label3 = new Label();
        private TextBox txtEmail = new TextBox();
        private TextBox txtPassword = new TextBox();
        private TextBox txtRepetir = new TextBox();
        private CheckBox chkVerPassword = new CheckBox();
        private IconButton btnCrear = new IconButton();
        private IconButton btnCancelar = new IconButton();

        public string EmailCreado { get; private set; } = string.Empty;

        public RegistrarUsuarioView()
        {
            InitializeComponent();
            EnvConfig.Cargar();
            authDomain = Environment.GetEnvironmentVariable("AUTHDOMAINFB");
            apiKey = Environment.GetEnvironmentVariable("APIKEYFIREBASE");
            ConfiguracionFirebaseAuthClient();
        }

        private void InitializeComponent()
        {
            this.Text = "Crear Usuario";
            this.ClientSize = new Size(640, 350);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RegistrarUsuarioView";

            panelTitulo.BackColor = Color.FromArgb(30, 30, 50);
            panelTitulo.Dock = DockStyle.Top;
            panelTitulo.Height = 70;

            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.FromArgb(120, 180, 255);
            lblTitulo.Location = new Point(20, 12);
            lblTitulo.Text = "Crear Usuario";

            lblSubtitulo.AutoSize = true;
            lblSubtitulo.ForeColor = Color.White;
            lblSubtitulo.Location = new Point(23, 44);
            lblSubtitulo.Text = "Registro con Firebase Authentication";

            panelTitulo.Controls.Add(lblTitulo);
            panelTitulo.Controls.Add(lblSubtitulo);

            label1.AutoSize = true;
            label1.Location = new Point(30, 95);
            label1.Text = "Email";

            txtEmail.Location = new Point(160, 91);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(440, 23);
            txtEmail.TabIndex = 0;

            label2.AutoSize = true;
            label2.Location = new Point(30, 137);
            label2.Text = "Contraseña";

            txtPassword.Location = new Point(160, 133);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(440, 23);
            txtPassword.TabIndex = 1;

            label3.AutoSize = true;
            label3.Location = new Point(30, 179);
            label3.Text = "Repetir contraseña";

            txtRepetir.Location = new Point(160, 175);
            txtRepetir.Name = "txtRepetir";
            txtRepetir.PasswordChar = '*';
            txtRepetir.Size = new Size(440, 23);
            txtRepetir.TabIndex = 2;

            chkVerPassword.AutoSize = true;
            chkVerPassword.Location = new Point(160, 210);
            chkVerPassword.Name = "chkVerPassword";
            chkVerPassword.Size = new Size(105, 19);
            chkVerPassword.TabIndex = 3;
            chkVerPassword.Text = "Ver Contraseña";
            chkVerPassword.UseVisualStyleBackColor = true;
            chkVerPassword.CheckedChanged += chkVerPassword_CheckedChanged;

            btnCrear.IconChar = IconChar.UserPlus;
            btnCrear.IconColor = Color.Black;
            btnCrear.IconFont = IconFont.Auto;
            btnCrear.IconSize = 15;
            btnCrear.ImageAlign = ContentAlignment.MiddleLeft;
            btnCrear.Location = new Point(390, 265);
            btnCrear.Name = "btnCrear";
            btnCrear.Size = new Size(120, 30);
            btnCrear.TabIndex = 4;
            btnCrear.Text = "Crear Usuario";
            btnCrear.TextAlign = ContentAlignment.MiddleRight;
            btnCrear.UseVisualStyleBackColor = true;
            btnCrear.Click += async (s, e) => await btnCrear_Click(s, e);

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
            btnCancelar.Click += (s, e) => btnCancelar_Click(s, e);

            this.Controls.Add(panelTitulo);
            this.Controls.Add(label1);
            this.Controls.Add(txtEmail);
            this.Controls.Add(label2);
            this.Controls.Add(txtPassword);
            this.Controls.Add(label3);
            this.Controls.Add(txtRepetir);
            this.Controls.Add(chkVerPassword);
            this.Controls.Add(btnCrear);
            this.Controls.Add(btnCancelar);

            this.AcceptButton = btnCrear;
            this.CancelButton = btnCancelar;
            this.ActiveControl = txtEmail;
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

        private async Task btnCrear_Click(object? sender, EventArgs e)
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
