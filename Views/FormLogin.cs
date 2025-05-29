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
                var usuarios = UsuarioRepository.ObtenerTodos();
                if (usuarios.Count == 0)
                {
                    // No hay usuarios, activar modo registro automáticamente  
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

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (modoRegistro)
            {
                RegistrarUsuario();
            }
            else
            {
                AutenticarUsuario();
            }
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
                // Verificar si el usuario ya existe  
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

                // Cambiar a modo login después del registro  
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
            modoRegistro = true;
            lblTitulo.Text = "Registrar Usuario";
            btnLogin.Text = "Registrar";
            btnCambiarModo.Text = "¿Ya tienes cuenta? Inicia sesión";

            lblConfirmarContrasena.Visible = true;
            txtConfirmarContrasena.Visible = true;
            lblRol.Visible = true;
            cmbRol.Visible = true;

            // Ajustar tamaño del formulario  
            this.Height = 350;
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

            // Ajustar tamaño del formulario  
            this.Height = 280;
        }

        private void btnCambiarModo_Click(object sender, EventArgs e)
        {
            if (modoRegistro)
            {
                CambiarAModoLogin();
            }
            else
            {
                CambiarAModoRegistro();
            }
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}