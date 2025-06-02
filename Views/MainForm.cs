using CafeteriaV2.Models.Entities;
using CafeteriaV2.Views.Forms;
using CafeteriaV2.Views.MenuArbol.arqueos;
using CafeteriaV2.Views.MenuArbol.clientes;
using CafeteriaV2.Views.MenuArbol.compras;

using CafeteriaV2.Views.MenuArbol.configuracion;
using CafeteriaV2.Views.MenuArbol.productos;
using CafeteriaV2.Views.MenuArbol.promociones;
using CafeteriaV2.Views.MenuArbol.reportes;
using CafeteriaV2.Views.MenuArbol.usuarios;
using CafeteriaV2.Views.MenuArbol.ventas;






//using CafeteriaV2.Views.MenuArbol;
using System;
using System.Windows.Forms;
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
            MenuArbol.NodeMouseDoubleClick += MenuArbol_NodeMouseDoubleClick;
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

        private void MenuArbol_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            string opcion = e.Node.Text;

            switch (opcion)
            {
                // 🧮 Arqueo Diario y Caja
                case "🕘 Iniciar Turno / Día":
                    new IniciarTurnoDía().ShowDialog();
                    break;
                case "🕔 Cerrar Turno / Día":
                    new CerrarTurnoDía().ShowDialog();
                    break;
                case "💵 Registrar Retiros":
                    new RegistrarRetiros().ShowDialog();
                    break;
                case "📊 Resumen Diario":
                    new ResumenDiario().ShowDialog();
                    break;
                case "📊 Informe Semanal / Mensual":
                    new InformeSemanalMensual().ShowDialog();
                    break;
                case "🔍 Auditoría de Caja":
                    new AuditoríaCaja().ShowDialog();
                    break;

                // 👥 Clientes y Fidelización
                case "➕ Registrar Cliente":
                    new RegistrarCliente().ShowDialog();
                    break;
                case "🔍 Ver Clientes":
                    new VerClientes().ShowDialog();
                    break;
                case "🏆 Movimiento de Puntos":
                    new Views.MenuArbol.clientes.MovimientoPuntos().ShowDialog();
                    break;
                case "🎁 Canjear Puntos":
                    new CanjearPuntos().ShowDialog();
                    break;
                case "📈 Estadísticas de Compras":
                    new EstadísticasCompras().ShowDialog();
                    break;
                case "🗑️ Clientes Inactivos":
                    new ClientesInactivos().ShowDialog();
                    break;

                // 🧾 Compras y Proveedores
                case "🧾 Registrar Factura de Compra":
                    new RegistrarFacturaCompra().ShowDialog();
                    break;
                case "🗂 Ver Compras por Fecha":
                    new VerComprasXFecha().ShowDialog();
                    break;
                case "🧾 Notas de Crédito":
                    new NotasCredito().ShowDialog();
                    break;
                case "👤 Proveedores Activos/Inactivos":
                    new ProveedoresActivos1Inactivos1().ShowDialog();
                    break;
                case "📈 Estadísticas por Proveedor":
                    new EstadísticasXProveedor().ShowDialog();
                    break;
                case "💲 Comparar Precios de Productos":
                    new CompararPreciosProductos().ShowDialog();
                    break;

                // ⚙️ Configuración y Utilidades
                case "📥 Importar Datos":
                    new ImportarDatos().ShowDialog();
                    break;
                case "🏷️ Categorías de Productos":
                    new CategoríasProductos().ShowDialog();
                    break;

                // 📦 Productos y Stock
                case "🔁 Actualizar Precios en Lote":
                    new ActualizarPreciosEnLote().ShowDialog();
                    break;
                case "➕ Agregar Producto":
                    new AgregarProducto().ShowDialog();
                    break;
                case "🔍 Consultar Productos":
                    new ConsultarProductos().ShowDialog();
                    break;
                case "📋 Listado para impresión / Excel":
                    new ListadoParaImpresión1Excel1().ShowDialog();
                    break;
                case "📉 Productos con Bajo Stock":
                    new ProductosBajoStock().ShowDialog();
                    break;
                case "📅 Productos Próximos a Vencer":
                    new ProductosProximosVencer().ShowDialog();
                    break;
                case "🧷 Unidades y Categorías":
                    new UnidadesCategorías().ShowDialog();
                    break;

                // 🎁 Promociones y Marketing
                case "➕ Crear Nueva Promoción":
                    new CrearNuevaPromoción().ShowDialog();
                    break;
                case "💌 Enviar Notificación a Clientes":
                    new EnviarNotificaciónClientes().ShowDialog();
                    break;
                case "🗂 Listar Promociones Activas":
                    new ListarPromocionesActivas().ShowDialog();
                    break;
                case "⏰ Promociones por Fecha":
                    new PromocionesXFecha().ShowDialog();
                    break;
                case "🛍️ Regalos por Compra":
                    new RegalosXCompra().ShowDialog();
                    break;

                // "📊 Reportes e Informes"
                case "💰 Arqueos y Retiros":
                    new ArqueosRetiros().ShowDialog();
                    break;
                case "💸 Compras por Proveedor":
                    new ComprasXProveedor().ShowDialog();
                    break;
                case "🧾 Facturas y Notas de Crédito":
                    new FacturasNotasCrédito().ShowDialog();
                    break;
                case "🏆 Puntos Otorgados y Canjeados":
                    new PuntosOtorgadosCanjeados().ShowDialog();
                    break;
                case "📦 Stock Valorizado":
                    new StockValorizado().ShowDialog();
                    break;
                case "📋 Ventas por Día/Mes":
                    new VentasXDíaXMes().ShowDialog();
                    break;

                // 👤 Usuarios y Seguridad
                case "🔐 Cambiar Contraseña":
                    new CambiarContraseña().ShowDialog();
                    break;
                case "➕ Crear Nuevo Usuario":
                    new CrearNuevoUsuario().ShowDialog();
                    break;
                case "📜 Historial de Sesiones":
                    new HistorialSesiones().ShowDialog();
                    break;
                case "📋 Permisos por Rol":
                    new PermisosXRol().ShowDialog();
                    break;
                case "🧑‍💼 Ver Usuarios y Roles":
                    new VerUsuariosRoles().ShowDialog();
                    break;

                // 🧾 Ventas
                case "🔍 Consultar Detalles de Venta":
                    new ConsultarDetallesVenta().ShowDialog();
                    break;
                case "📅 Historial de Ventas":
                    new HistorialVentas().ShowDialog();
                    break;
                case "📦 Productos más vendidos":
                    new ProductosMasVendidos().ShowDialog();
                    break;
                case "💰 Registrar Venta":
                    new RegistrarVenta().ShowDialog();
                    break;
                case "🧾 Ticket Actual":
                    new TicketActual().ShowDialog();
                    break;


                //default:
                //    MessageBox.Show("Función aún no implementada para: " + opcion, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    break;
            }
        }


    }
}
