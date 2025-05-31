using System;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using CafeteriaV2.Modelos;

namespace CafeteriaV2.Data
{
    public static class NotaCreditoCompraRepository
    {
        public static void Agregar(NotaCreditoCompra nota)
        {
            using (var conn = new SqliteConnection(BaseDatos.ConnectionString))
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    var cmd = conn.CreateCommand();
                    cmd.Transaction = transaction;
                    cmd.CommandText = @"
                        INSERT INTO NotasCreditoCompra (Fecha, ProveedorId, Total, UsuarioId, Motivo)
                        VALUES (@Fecha, @ProveedorId, @Total, @UsuarioId, @Motivo);
                        SELECT last_insert_rowid();";

                    cmd.Parameters.AddWithValue("@Fecha", nota.Fecha.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@ProveedorId", nota.ProveedorId);
                    cmd.Parameters.AddWithValue("@Total", nota.Total);
                    cmd.Parameters.AddWithValue("@UsuarioId", nota.UsuarioId);
                    cmd.Parameters.AddWithValue("@Motivo", nota.Motivo ?? "");

                    nota.Id = Convert.ToInt32(cmd.ExecuteScalar());

                    foreach (var detalle in nota.Detalles)
                    {
                        var detalleCmd = conn.CreateCommand();
                        detalleCmd.Transaction = transaction;
                        detalleCmd.CommandText = @"
                            INSERT INTO DetalleNotaCreditoCompra (NotaCreditoId, ProductoId, Cantidad, PrecioUnitario, Subtotal)
                            VALUES (@NotaCreditoId, @ProductoId, @Cantidad, @PrecioUnitario, @Subtotal);";

                        detalleCmd.Parameters.AddWithValue("@NotaCreditoId", nota.Id);
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

        public static List<NotaCreditoCompra> ObtenerTodas()
        {
            var notas = new List<NotaCreditoCompra>();

            using (var conn = new SqliteConnection(BaseDatos.ConnectionString))
            {
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM NotasCreditoCompra ORDER BY Fecha DESC";

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var nota = new NotaCreditoCompra
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Fecha = DateTime.Parse(reader["Fecha"].ToString()),
                            ProveedorId = Convert.ToInt32(reader["ProveedorId"]),
                            Total = Convert.ToDouble(reader["Total"]),
                            UsuarioId = Convert.ToInt32(reader["UsuarioId"]),
                            Motivo = reader["Motivo"].ToString(),
                            Detalles = ObtenerDetallesNotaCredito(Convert.ToInt32(reader["Id"]))
                        };

                        notas.Add(nota);
                    }
                }
            }

            return notas;
        }

        private static List<DetalleNotaCreditoCompra> ObtenerDetallesNotaCredito(int notaCreditoId)
        {
            var detalles = new List<DetalleNotaCreditoCompra>();

            using (var conn = new SqliteConnection(BaseDatos.ConnectionString))
            {
                conn.Open();

                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM DetalleNotaCreditoCompra WHERE NotaCreditoId = @NotaCreditoId";
                cmd.Parameters.AddWithValue("@NotaCreditoId", notaCreditoId);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        detalles.Add(new DetalleNotaCreditoCompra
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            NotaCreditoId = Convert.ToInt32(reader["NotaCreditoId"]),
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
