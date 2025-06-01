using System;

namespace CafeteriaV2.Data
{
    public static class BaseDatos
    {
        public static string ConnectionString { get; } = "Data Source=miCafeteria.db";

        public static void Inicializar()
        {
            try
            {
                using (var conn = new Microsoft.Data.Sqlite.SqliteConnection(ConnectionString))
                {
                    conn.Open();
                    var cmd = conn.CreateCommand();

                    cmd.CommandText = @"
                        -- ========================
                        -- TABLAS DE USUARIOS Y ROLES
                        -- ========================
                        CREATE TABLE IF NOT EXISTS Usuarios (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            NombreUsuario TEXT NOT NULL UNIQUE,
                            ContrasenaHash TEXT NOT NULL,
                            Rol TEXT NOT NULL, -- Admin, Cajero, etc.
                            Estado TEXT NOT NULL DEFAULT 'Activo',
                            FechaAlta TEXT NOT NULL
                        );

                        -- ========================
                        -- TABLAS DE PROVEEDORES Y PRODUCTOS
                        -- ========================
                        CREATE TABLE IF NOT EXISTS Proveedores (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            Nombre TEXT NOT NULL,
                            RUT TEXT,
                            Telefono TEXT NOT NULL,
                            Email TEXT,
                            Direccion TEXT,
                            FechaAlta TEXT NOT NULL,
                            FechaModificacion TEXT NOT NULL
                        );

                        CREATE TABLE IF NOT EXISTS Productos (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            Nombre TEXT NOT NULL,
                            Descripcion TEXT,
                            Precio REAL NOT NULL,
                            Costo REAL NOT NULL,
                            Stock REAL NOT NULL,
                            UnidadMedida TEXT NOT NULL CHECK (UnidadMedida IN ('Unidad', 'Peso')),
                            Categoria TEXT,
                            Estado TEXT NOT NULL,
                            FechaAlta TEXT NOT NULL,
                            FechaModificacion TEXT NOT NULL,
                            Vencimiento TEXT,
                            ProveedorId INTEGER NOT NULL,
                            CodigoInterno INTEGER NOT NULL,
                            FOREIGN KEY (ProveedorId) REFERENCES Proveedores(Id)
                        );

                        -- ========================
                        -- CLIENTES Y SISTEMA DE FIDELIDAD
                        -- ========================
                        CREATE TABLE IF NOT EXISTS Clientes (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            Nombre TEXT NOT NULL,
                            Telefono TEXT,
                            Email TEXT,
                            FechaAlta TEXT NOT NULL,
                            PuntosAcumulados INTEGER DEFAULT 0,
                            Estado TEXT NOT NULL
                        );

                        CREATE TABLE IF NOT EXISTS MovimientoPuntos (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            ClienteId INTEGER NOT NULL,
                            Fecha TEXT NOT NULL,
                            Puntos INTEGER NOT NULL,
                            Motivo TEXT,
                            FOREIGN KEY (ClienteId) REFERENCES Clientes(Id)
                        );

                        -- ========================
                        -- VENTAS Y DETALLES
                        -- ========================
                        CREATE TABLE IF NOT EXISTS VentasPublico (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            Fecha TEXT NOT NULL,
                            Total REAL NOT NULL,
                            MetodoPago TEXT NOT NULL,
                            ClienteId INTEGER,
                            CajeroId INTEGER NOT NULL,
                            FOREIGN KEY (ClienteId) REFERENCES Clientes(Id),
                            FOREIGN KEY (CajeroId) REFERENCES Usuarios(Id)
                        );

                        CREATE TABLE IF NOT EXISTS DetalleVentaPublico (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            VentaId INTEGER NOT NULL,
                            ProductoId INTEGER NOT NULL,
                            Cantidad REAL NOT NULL,
                            PrecioUnitario REAL NOT NULL,
                            FOREIGN KEY (VentaId) REFERENCES VentasPublico(Id),
                            FOREIGN KEY (ProductoId) REFERENCES Productos(Id)
                        );

                        -- ========================
                        -- ARQUEO Y RETIROS DE CAJA
                        -- ========================
                        CREATE TABLE IF NOT EXISTS ArqueoDiario (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            Fecha TEXT NOT NULL UNIQUE,
                            SaldoInicial REAL NOT NULL,
                            SaldoFinal REAL,
                            TotalVentas REAL,
                            Diferencia REAL,
                            Observaciones TEXT,
                            Turno TEXT NOT NULL,
                            UsuarioId INTEGER NOT NULL,
                            FOREIGN KEY (UsuarioId) REFERENCES Usuarios(Id)
                        );

                        CREATE TABLE IF NOT EXISTS RetirosCaja (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            ArqueoId INTEGER,
                            UsuarioId INTEGER NOT NULL,
                            Turno TEXT NOT NULL,
                            Fecha TEXT NOT NULL,
                            Monto REAL NOT NULL,
                            Motivo TEXT,
                            FOREIGN KEY (ArqueoId) REFERENCES ArqueoDiario(Id),
                            FOREIGN KEY (UsuarioId) REFERENCES Usuarios(Id)
                        );

                        -- ========================
                        -- PROMOCIONES Y BONIFICACIONES
                        -- ========================
                        CREATE TABLE IF NOT EXISTS Promociones (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            Nombre TEXT NOT NULL,
                            Descripcion TEXT,
                            Activa INTEGER NOT NULL,
                            Tipo INTEGER NOT NULL,
                            DescuentoPorcentaje REAL,
                            DescuentoFijo REAL,
                            MontoMinimo REAL,
                            ProductoId INTEGER,
                            PuntosOtorgados INTEGER,
                            FechaInicio TEXT NOT NULL,
                            FechaFin TEXT NOT NULL,
                            FOREIGN KEY (ProductoId) REFERENCES Productos(Id)
                        );

                        -- ========================
                        -- COMPRAS A PROVEEDORES
                        -- ========================
                        CREATE TABLE IF NOT EXISTS FacturasCompra (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            Fecha TEXT NOT NULL,
                            ProveedorId INTEGER NOT NULL,
                            Total REAL NOT NULL,
                            UsuarioId INTEGER NOT NULL,
                            FOREIGN KEY (ProveedorId) REFERENCES Proveedores(Id),
                            FOREIGN KEY (UsuarioId) REFERENCES Usuarios(Id)
                        );

                        CREATE TABLE IF NOT EXISTS DetalleFacturaCompra (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            FacturaId INTEGER NOT NULL,
                            ProductoId INTEGER NOT NULL,
                            Cantidad REAL NOT NULL,
                            PrecioUnitario REAL NOT NULL,
                            Subtotal REAL NOT NULL,
                            FOREIGN KEY (FacturaId) REFERENCES FacturasCompra(Id),
                            FOREIGN KEY (ProductoId) REFERENCES Productos(Id)
                        );

                        -- ========================
                        -- NOTAS DE CRÉDITO
                        -- ========================
                        CREATE TABLE IF NOT EXISTS NotasCredito (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            Fecha TEXT NOT NULL,
                            FacturaId INTEGER NOT NULL,
                            ProveedorId INTEGER NOT NULL,
                            Total REAL NOT NULL,
                            Motivo TEXT,
                            UsuarioId INTEGER NOT NULL,
                            FOREIGN KEY (FacturaId) REFERENCES FacturasCompra(Id),
                            FOREIGN KEY (ProveedorId) REFERENCES Proveedores(Id),
                            FOREIGN KEY (UsuarioId) REFERENCES Usuarios(Id)
                        );

                        CREATE TABLE IF NOT EXISTS DetalleNotaCredito (
                            Id INTEGER PRIMARY KEY AUTOINCREMENT,
                            NotaCreditoId INTEGER NOT NULL,
                            ProductoId INTEGER NOT NULL,
                            Cantidad REAL NOT NULL,
                            PrecioUnitario REAL NOT NULL,
                            Subtotal REAL NOT NULL,
                            FOREIGN KEY (NotaCreditoId) REFERENCES NotasCredito(Id),
                            FOREIGN KEY (ProductoId) REFERENCES Productos(Id)
                        );
                    ";

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al inicializar la base de datos: " + ex.Message);
            }
        }
    }
}
