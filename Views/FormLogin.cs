using CafeteriaV2.Data;
using CafeteriaV2.Models.Entities;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace CafeteriaV2.Views.Forms
{
    public partial class FormLogin : Form
    {
        public Usuario UsuarioAutenticado { get; private set; }
        private bool modoRegistro = false;

        public FormLogin()
        {
            InitializeComponent();
            VerificarSiExistenUsuarios();
        }

        private void VerificarSiExistenUsuarios()
        {
            try
            {
                var usuarios = UsuarioRepository.CantidadUsuarios();
                if (usuarios == 0)
                {
                    CambiarAModoRegistro();
                    MessageBox.Show("No hay usuarios en el sistema. Cree el primer usuario administrador.",
                        "Primer Usuario", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al verificar usuarios: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (modoRegistro)
                RegistrarUsuario();
            else
                AutenticarUsuario();
        }

        private void AutenticarUsuario()
        {
            if (string.IsNullOrWhiteSpace(txtUsuario.Text) ||
                string.IsNullOrWhiteSpace(txtContrasena.Text))
            {
                MessageBox.Show("Por favor ingrese usuario y contraseña", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var usuario = UsuarioRepository.ObtenerUsuarioPorNombre(txtUsuario.Text);

                if (usuario != null && VerificarContrasena(txtContrasena.Text, usuario.ContrasenaHash))
                {
                    if (usuario.Estado == "Activo")
                    {
                        UsuarioAutenticado = usuario;
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Usuario inactivo", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al autenticar: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RegistrarUsuario()
        {
            if (string.IsNullOrWhiteSpace(txtUsuario.Text) ||
                string.IsNullOrWhiteSpace(txtContrasena.Text) ||
                string.IsNullOrWhiteSpace(txtConfirmarContrasena.Text))
            {
                MessageBox.Show("Por favor complete todos los campos", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtContrasena.Text != txtConfirmarContrasena.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var usuarioExistente = UsuarioRepository.ObtenerUsuarioPorNombre(txtUsuario.Text);
                if (usuarioExistente != null)
                {
                    MessageBox.Show("El nombre de usuario ya existe", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var nuevoUsuario = new Usuario
                {
                    NombreUsuario = txtUsuario.Text,
                    ContrasenaHash = GenerarHashContrasena(txtContrasena.Text),
                    Rol = cmbRol.SelectedItem?.ToString() ?? "Cajero",
                    Estado = "Activo",
                    FechaAlta = DateTime.Now
                };

                UsuarioRepository.AgregarUsuario(nuevoUsuario);

                MessageBox.Show("Usuario creado exitosamente", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                CambiarAModoLogin();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar usuario: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CambiarAModoRegistro()
        {
            if (UsuarioRepository.CantidadUsuariosAdmin() > 0)
            {
                cmbRol.Items.Remove("Admin");
                cmbRol.Items.AddRange(new object[] { "Cajero" });
            }
            modoRegistro = true;
            lblTitulo.Text = "Registrar Usuario";
            btnLogin.Text = "Registrar";
            btnCambiarModo.Text = "¿Ya tienes cuenta? Inicia sesión";

            lblConfirmarContrasena.Visible = true;
            txtConfirmarContrasena.Visible = true;
            lblRol.Visible = true;
            cmbRol.Visible = true;

            this.Height = 380;
        }

        private void CambiarAModoLogin()
        {
            modoRegistro = false;
            lblTitulo.Text = "Iniciar Sesión";
            btnLogin.Text = "Ingresar";
            btnCambiarModo.Text = "¿No tienes cuenta? Regístrate";

            lblConfirmarContrasena.Visible = false;
            txtConfirmarContrasena.Visible = false;
            lblRol.Visible = false;
            cmbRol.Visible = false;

            this.Height = 380;
        }

        private void btnCambiarModo_Click(object sender, EventArgs e)
        {
            if (modoRegistro)
                CambiarAModoLogin();
            else
                CambiarAModoRegistro();

            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txtUsuario.Clear();
            txtContrasena.Clear();
            txtConfirmarContrasena.Clear();
            cmbRol.SelectedIndex = 0;
        }

        private string GenerarHashContrasena(string contrasena)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(contrasena));
                return Convert.ToBase64String(bytes);
            }
        }

        private bool VerificarContrasena(string contrasena, string hash)
        {
            return GenerarHashContrasena(contrasena) == hash;
        }

        // ✅ MÉTODO CENTRALIZADO PARA VERIFICAR CIERRE
        private bool PuedeCerrarAplicacion()
        {
            if (ArqueoDiarioRepository.HayDiaIniciadoSinCerrar())
            {
                MessageBox.Show("No se puede cerrar la aplicación mientras haya un día sin cerrar.",
                    "Día en curso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult != DialogResult.OK && !PuedeCerrarAplicacion())
            {
                e.Cancel = true;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (PuedeCerrarAplicacion())
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }
    }
}
