using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.Sqlite;
using CafeteriaV2.Modelos;

namespace CafeteriaV2.Data
{
    public static class FacturaCompraRepository
    {
        public static void Agregar(FacturaCompra factura)
        {
            using (var conn = new SqliteConnection(BaseDatos.ConnectionString))
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    var cmd = conn.CreateCommand();
                    cmd.Transaction = transaction;
                    cmd.CommandText = @"
                        INSERT INTO FacturasCompra (Fecha, ProveedorId, Total, UsuarioId)
                        VALUES (@Fecha, @ProveedorId, @Total, @UsuarioId);
                        SELECT last_insert_rowid();";

                    cmd.Parameters.AddWithValue("@Fecha", factura.Fecha.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@ProveedorId", factura.ProveedorId);
                    cmd.Parameters.AddWithValue("@Total", factura.Total);
                    cmd.Parameters.AddWithValue("@UsuarioId", factura.UsuarioId);

                    factura.Id = Convert.ToInt32(cmd.ExecuteScalar());

                    foreach (var detalle in factura.Detalles)
                    {
                        var detalleCmd = conn.CreateCommand();
                        detalleCmd.Transaction = transaction;
                        detalleCmd.CommandText = @"
                            INSERT INTO DetalleFacturaCompra (FacturaId, ProductoId, Cantidad, PrecioUnitario, Subtotal)
                            VALUES (@FacturaId, @ProductoId, @Cantidad, @PrecioUnitario, @Subtotal);";

                        detalleCmd.Parameters.AddWithValue("@FacturaId", factura.Id);
                        detalleCmd.Parameters.AddWithValue("@ProductoId", detalle.ProductoId);
                        detalleCmd.Parameters.AddWithValue("@Cantidad", detalle.Cantidad);
                        detalleCmd.Parameters.AddWithValue("@PrecioUnitario", detalle.PrecioUnitario);
                        detalleCmd.Parameters.AddWithValue("@Subtotal", detalle.Subtotal);

                        detalleCmd.ExecuteNonQuery();
                    }

                    transaction.Commit();
                }
            }
        }

        public static List<FacturaCompra> ObtenerTodas()
        {
            var facturas = new List<FacturaCompra>();

            using (var conn = new SqliteConnection(BaseDatos.ConnectionString))
            {
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM FacturasCompra ORDER BY Fecha DESC";

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var factura = new FacturaCompra
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Fecha = DateTime.Parse(reader["Fecha"].ToString()),
                            ProveedorId = Convert.ToInt32(reader["ProveedorId"]),
                            Total = Convert.ToDouble(reader["Total"]),
                            UsuarioId = Convert.ToInt32(reader["UsuarioId"]),
                            Detalles = ObtenerDetallesFactura(Convert.ToInt32(reader["Id"]))
                        };

                        facturas.Add(factura);
                    }
                }
            }

            return facturas;
        }

        private static List<DetalleFacturaCompra> ObtenerDetallesFactura(int facturaId)
        {
            var detalles = new List<DetalleFacturaCompra>();

            using (var conn = new SqliteConnection(BaseDatos.ConnectionString))
            {
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM DetalleFacturaCompra WHERE FacturaId = @FacturaId";
                cmd.Parameters.AddWithValue("@FacturaId", facturaId);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        detalles.Add(new DetalleFacturaCompra
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            FacturaId = Convert.ToInt32(reader["FacturaId"]),
                            ProductoId = Convert.ToInt32(reader["ProductoId"]),
                            Cantidad = Convert.ToDouble(reader["Cantidad"]),
                            PrecioUnitario = Convert.ToDouble(reader["PrecioUnitario"]),
                            Subtotal = Convert.ToDouble(reader["Subtotal"])
                        });
                    }
                }
            }

            return detalles;
        }
    }
}
