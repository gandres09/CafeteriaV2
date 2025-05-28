using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;

public static class PromocionRepository
{
    private const string connectionString = "Data Source=miCafeteria.db";

    public static void Agregar(Promocion promo)
    {
        using (var conn = new SqliteConnection(connectionString))
        {
            conn.Open();
            var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                INSERT INTO Promociones 
                (Nombre, Descripcion, Activa, Tipo, DescuentoPorcentaje, DescuentoFijo, MontoMinimo, ProductoId, PuntosOtorgados, FechaInicio, FechaFin)
                VALUES (@Nombre, @Descripcion, @Activa, @Tipo, @DescuentoPorcentaje, @DescuentoFijo, @MontoMinimo, @ProductoId, @PuntosOtorgados, @FechaInicio, @FechaFin)";

            cmd.Parameters.AddWithValue("@Nombre", promo.Nombre);
            cmd.Parameters.AddWithValue("@Descripcion", promo.Descripcion ?? "");
            cmd.Parameters.AddWithValue("@Activa", promo.Activa ? 1 : 0);
            cmd.Parameters.AddWithValue("@Tipo", (int)promo.Tipo);
            cmd.Parameters.AddWithValue("@DescuentoPorcentaje", promo.DescuentoPorcentaje);
            cmd.Parameters.AddWithValue("@DescuentoFijo", promo.DescuentoFijo);
            cmd.Parameters.AddWithValue("@MontoMinimo", promo.MontoMinimo);
            cmd.Parameters.AddWithValue("@ProductoId", promo.ProductoId);
            cmd.Parameters.AddWithValue("@PuntosOtorgados", promo.PuntosOtorgados);
            cmd.Parameters.AddWithValue("@FechaInicio", promo.FechaInicio.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@FechaFin", promo.FechaFin.ToString("yyyy-MM-dd"));

            cmd.ExecuteNonQuery();
        }
    }

    public static List<Promocion> ObtenerTodas()
    {
        var lista = new List<Promocion>();
        using (var conn = new SqliteConnection(connectionString))
        {
            conn.Open();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM Promociones";

            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    lista.Add(new Promocion
                    {
                        Id = reader.GetInt32(0),
                        Nombre = reader.GetString(1),
                        Descripcion = reader.IsDBNull(2) ? "" : reader.GetString(2),
                        Activa = reader.GetInt32(3) == 1,
                        Tipo = (TipoPromocion)reader.GetInt32(4),
                        DescuentoPorcentaje = reader.IsDBNull(5) ? 0 : reader.GetDecimal(5),
                        DescuentoFijo = reader.IsDBNull(6) ? 0 : reader.GetDecimal(6),
                        MontoMinimo = reader.IsDBNull(7) ? 0 : reader.GetDecimal(7),
                        ProductoId = reader.IsDBNull(8) ? 0 : reader.GetInt32(8),
                        PuntosOtorgados = reader.IsDBNull(9) ? 0 : reader.GetInt32(9),
                        FechaInicio = DateTime.Parse(reader.GetString(10)),
                        FechaFin = DateTime.Parse(reader.GetString(11))
                    });
                }
            }
        }
        return lista;
    }

    public static void Actualizar(Promocion promo)
    {
        using (var conn = new SqliteConnection(connectionString))
        {
            conn.Open();
            var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                UPDATE Promociones SET 
                    Nombre = @Nombre,
                    Descripcion = @Descripcion,
                    Activa = @Activa,
                    Tipo = @Tipo,
                    DescuentoPorcentaje = @DescuentoPorcentaje,
                    DescuentoFijo = @DescuentoFijo,
                    MontoMinimo = @MontoMinimo,
                    ProductoId = @ProductoId,
                    PuntosOtorgados = @PuntosOtorgados,
                    FechaInicio = @FechaInicio,
                    FechaFin = @FechaFin
                WHERE Id = @Id";

            cmd.Parameters.AddWithValue("@Nombre", promo.Nombre);
            cmd.Parameters.AddWithValue("@Descripcion", promo.Descripcion ?? "");
            cmd.Parameters.AddWithValue("@Activa", promo.Activa ? 1 : 0);
            cmd.Parameters.AddWithValue("@Tipo", (int)promo.Tipo);
            cmd.Parameters.AddWithValue("@DescuentoPorcentaje", promo.DescuentoPorcentaje);
            cmd.Parameters.AddWithValue("@DescuentoFijo", promo.DescuentoFijo);
            cmd.Parameters.AddWithValue("@MontoMinimo", promo.MontoMinimo);
            cmd.Parameters.AddWithValue("@ProductoId", promo.ProductoId);
            cmd.Parameters.AddWithValue("@PuntosOtorgados", promo.PuntosOtorgados);
            cmd.Parameters.AddWithValue("@FechaInicio", promo.FechaInicio.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@FechaFin", promo.FechaFin.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@Id", promo.Id);

            cmd.ExecuteNonQuery();
        }
    }

    public static void Eliminar(int id)
    {
        using (var conn = new SqliteConnection(connectionString))
        {
            conn.Open();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE FROM Promociones WHERE Id = @Id";
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.ExecuteNonQuery();
        }
    }
}
