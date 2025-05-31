using CafeteriaV2.Models.Entities;
using CafeteriaV2.Views.Forms;
using CafeteriaV2.Views.MenuArbol;
using System;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace CafeteriaV2
{
    public partial class MainForm : Form
    {
        private Usuario usuarioAutenticado;
        private bool cerrarSesion = false; // ✅ Control de cierre autorizado

        public MainForm(Usuario usuario)
        {
            InitializeComponent();
            usuarioAutenticado = usuario;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Text = $"Cafetería - {usuarioAutenticado.NombreUsuario} ({usuarioAutenticado.Rol})";

            if (usuarioAutenticado.Rol == "Admin")
            {
                MessageBox.Show($"Bienvenido, {usuarioAutenticado.NombreUsuario}. Has iniciado sesión como administrador.",
                                "Acceso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (usuarioAutenticado.Rol == "Cajero")
            {
                MessageBox.Show($"Bienvenido, {usuarioAutenticado.NombreUsuario}. Has iniciado sesión como cajero.",
                                "Acceso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                TreeNode nodoUsuarios = MenuArbol.Nodes.Find("NodoUsuarios", true).FirstOrDefault();
                if (nodoUsuarios != null)
                    nodoUsuarios.Remove();

                TreeNode nodoPromociones = MenuArbol.Nodes.Find("NodoPromociones", true).FirstOrDefault();
                if (nodoPromociones != null)
                    nodoPromociones.Remove();

                TreeNode nodoProveedores = MenuArbol.Nodes.Find("NodoAgregarProveedor", true).FirstOrDefault();
                if (nodoProveedores != null)
                    nodoProveedores.Remove();

                TreeNode nodoProductos = MenuArbol.Nodes.Find("NodoAgregarProducto", true).FirstOrDefault();
                if (nodoProductos != null)
                    nodoProductos.Remove();
            }
            else
            {
                MessageBox.Show($"El rol del usuario {usuarioAutenticado.NombreUsuario} no está reconocido. Acceso denegado.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            TreeNode nodoMenu = MenuArbol.Nodes.Find("NodoMenu", true).FirstOrDefault();
            if (nodoMenu != null)
            {
                nodoMenu.Expand();
            }
        }


        private void MenuArbol_AfterSelect(object sender, TreeViewEventArgs e)
        {

            switch (e.Node.Name)
            {
                case "NodoAgregarProducto":
                    new AgregarProductoForm().ShowDialog();
                    break;
                case "NodoConsultarProducto":
                    new ConsultaProductoForm().ShowDialog();
                    break;
                case "NodoAgregarPromocion":
                    new AgregarPromocionForm().ShowDialog();
                    break;
                case "NodoConsultarPromocion":
                    new ConsultaPromocionForm().ShowDialog();
                    break;
                case "NodoAgregarProveedor":
                    new AgregarProveedorForm().ShowDialog();
                    break;
                case "NodoConsultarProveedor":
                    new ConsultaProveedorForm().ShowDialog();
                    break;
                case "NodoAgregarUsuario":
                    new AgregarUsuarioForm().ShowDialog();
                    break;
                case "NodoConsultarUsuario":
                    new ConsultaUsuarioForm().ShowDialog();
                    break;
                case "NodoAgregarCliente":
                    new AgregarClienteForm().ShowDialog();
                    break;
                case "NodoConsultarCliente":
                    new ConsultaClienteForm().ShowDialog();
                    break;
            }

            MenuArbol.SelectedNode = null;
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show("¿Seguro que deseas cerrar sesión?", "Cerrar sesión", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                cerrarSesion = true; // ✅ Permitir cierre del formulario

                this.Hide();

                using (var loginForm = new FormLogin())
                {
                    if (loginForm.ShowDialog() == DialogResult.OK)
                    {
                        var usuario = loginForm.UsuarioAutenticado;
                        var nuevoMainForm = new MainForm(usuario);
                        nuevoMainForm.ShowDialog();
                    }
                }

                this.Close();
            }
        }

        // ✅ Manejo del intento de cierre desde la X
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!cerrarSesion)
            {
                e.Cancel = true;
                MessageBox.Show("Debes cerrar sesión desde el botón correspondiente.",
                    "Cierre no permitido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
