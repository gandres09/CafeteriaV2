using CafeteriaV2.Models.Entities;
using CafeteriaV2.Views.Forms;
//using CafeteriaV2.Views.MenuArbol;
using System;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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

            }
            else
            {
                MessageBox.Show($"El rol del usuario {usuarioAutenticado.NombreUsuario} no está reconocido. Acceso denegado.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

            //TreeNode nodoMenu = MenuArbol.Nodes.Find("NodoMenu", true).FirstOrDefault();
            //if (nodoMenu != null)
            //{
            //    nodoMenu.Expand();
            //}
            ConstruirArbolMenu();
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

        private void ConstruirArbolMenu()
        {
            MenuArbol.Nodes.Clear();

            TreeNode ventas = new TreeNode("🧾 Ventas");
            ventas.Nodes.Add("💰 Registrar Venta");
            ventas.Nodes.Add("📅 Historial de Ventas");
            ventas.Nodes.Add("🧾 Ticket Actual");
            ventas.Nodes.Add("📦 Productos más vendidos");
            ventas.Nodes.Add("🔍 Consultar Detalles de Venta");

            TreeNode productos = new TreeNode("📦 Productos y Stock");
            productos.Nodes.Add("➕ Agregar Producto");
            productos.Nodes.Add("🔍 Consultar Productos");
            productos.Nodes.Add("📉 Productos con Bajo Stock");
            productos.Nodes.Add("📅 Productos Próximos a Vencer");
            productos.Nodes.Add("🔁 Actualizar Precios en Lote");
            productos.Nodes.Add("🧷 Unidades y Categorías");
            productos.Nodes.Add("📋 Listado para impresión / Excel");

            TreeNode compras = new TreeNode("🧾 Compras y Proveedores");
            compras.Nodes.Add("🧾 Registrar Factura de Compra");
            compras.Nodes.Add("🗂 Ver Compras por Fecha");
            compras.Nodes.Add("🧾 Notas de Crédito");
            compras.Nodes.Add("👤 Proveedores Activos/Inactivos");
            compras.Nodes.Add("📈 Estadísticas por Proveedor");
            compras.Nodes.Add("💲 Comparar Precios de Productos");

            TreeNode arqueo = new TreeNode("🧮 Arqueo Diario y Caja");
            arqueo.Nodes.Add("🕘 Iniciar Turno / Día");
            arqueo.Nodes.Add("🕔 Cerrar Turno / Día");
            arqueo.Nodes.Add("💵 Registrar Retiros");
            arqueo.Nodes.Add("📊 Resumen Diario");
            arqueo.Nodes.Add("📊 Informe Semanal / Mensual");
            arqueo.Nodes.Add("🔍 Auditoría de Caja");

            TreeNode clientes = new TreeNode("👥 Clientes y Fidelización");
            clientes.Nodes.Add("➕ Registrar Cliente");
            clientes.Nodes.Add("🔍 Ver Clientes");
            clientes.Nodes.Add("🏆 Movimiento de Puntos");
            clientes.Nodes.Add("🎁 Canjear Puntos");
            clientes.Nodes.Add("📈 Estadísticas de Compras");
            clientes.Nodes.Add("🗑️ Clientes Inactivos");

            TreeNode promociones = new TreeNode("🎁 Promociones y Marketing");
            promociones.Nodes.Add("➕ Crear Nueva Promoción");
            promociones.Nodes.Add("🗂 Listar Promociones Activas");
            promociones.Nodes.Add("⏰ Promociones por Fecha");
            promociones.Nodes.Add("🛍️ Regalos por Compra");
            promociones.Nodes.Add("💌 Enviar Notificación a Clientes");

            TreeNode usuarios = new TreeNode("👤 Usuarios y Seguridad");
            usuarios.Nodes.Add("➕ Crear Nuevo Usuario");
            usuarios.Nodes.Add("🧑‍💼 Ver Usuarios y Roles");
            usuarios.Nodes.Add("🔐 Cambiar Contraseña");
            usuarios.Nodes.Add("📜 Historial de Sesiones");
            usuarios.Nodes.Add("📋 Permisos por Rol");

            TreeNode configuracion = new TreeNode("⚙️ Configuración y Utilidades");
            configuracion.Nodes.Add("🏷️ Categorías de Productos");
            configuracion.Nodes.Add("📦 Unidades de Medida");
            configuracion.Nodes.Add("🔁 Respaldar Base de Datos");
            configuracion.Nodes.Add("📥 Importar Datos");
            configuracion.Nodes.Add("🌐 Parámetros del Sistema");
            configuracion.Nodes.Add("🕵️‍♂️ Registro de Cambios / Logs");

            TreeNode reportes = new TreeNode("📊 Reportes e Informes");
            reportes.Nodes.Add("📋 Ventas por Día/Mes");
            reportes.Nodes.Add("📦 Stock Valorizado");
            reportes.Nodes.Add("💸 Compras por Proveedor");
            reportes.Nodes.Add("🧾 Facturas y Notas de Crédito");
            reportes.Nodes.Add("💰 Arqueos y Retiros");
            reportes.Nodes.Add("🏆 Puntos Otorgados y Canjeados");

            MenuArbol.Nodes.Add(ventas);
            MenuArbol.Nodes.Add(productos);
            MenuArbol.Nodes.Add(compras);
            MenuArbol.Nodes.Add(arqueo);
            MenuArbol.Nodes.Add(clientes);
            MenuArbol.Nodes.Add(promociones);
            MenuArbol.Nodes.Add(usuarios);
            MenuArbol.Nodes.Add(configuracion);
            MenuArbol.Nodes.Add(reportes);
        }

    }
}
