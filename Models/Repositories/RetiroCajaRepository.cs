using CafeteriaV2.Models.Entities;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;

namespace CafeteriaV2.Data
{
    public static class RetiroCajaRepository
    {
        public static void AgregarRetiro(RetiroCaja retiro)
        {
            using (var conn = new SqliteConnection(BaseDatos.ConnectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = @"
                    INSERT INTO RetirosCaja (ArqueoId, UsuarioId, Turno, Fecha, Monto, Motivo)
                    VALUES (@ArqueoId, @UsuarioId, @Turno, @Fecha, @Monto, @Motivo)";
                cmd.Parameters.AddWithValue("@ArqueoId", (object)retiro.ArqueoId ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@UsuarioId", retiro.UsuarioId);
                cmd.Parameters.AddWithValue("@Turno", retiro.Turno);
                cmd.Parameters.AddWithValue("@Fecha", retiro.Fecha.ToString("yyyy-MM-dd HH:mm:ss"));
                cmd.Parameters.AddWithValue("@Monto", retiro.Monto);
                cmd.Parameters.AddWithValue("@Motivo", retiro.Motivo ?? (object)DBNull.Value);
                cmd.ExecuteNonQuery();
            }
        }

        public static List<RetiroCaja> ObtenerRetiros()
        {
            var lista = new List<RetiroCaja>();
            using (var conn = new SqliteConnection(BaseDatos.ConnectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM RetirosCaja";
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lista.Add(new RetiroCaja
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            ArqueoId = reader["ArqueoId"] != DBNull.Value ? Convert.ToInt32(reader["ArqueoId"]) : (int?)null,
                            UsuarioId = Convert.ToInt32(reader["UsuarioId"]),
                            Turno = reader["Turno"].ToString(),
                            Fecha = DateTime.Parse(reader["Fecha"].ToString()),
                            Monto = Convert.ToDecimal(reader["Monto"]),
                            Motivo = reader["Motivo"]?.ToString()
                        });
                    }
                }
            }
            return lista;
        }
    }
}
