using CafeteriaV2.Models;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;

public class ProductoRepository
{
    private string connectionString = "Data Source=miCafeteria.db";

    public List<Producto> ObtenerTodos()
    {
        var productos = new List<Producto>();

        try
        {
            using (var conn = new SqliteConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Productos";
                using (var cmd = new SqliteCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        productos.Add(new Producto
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Nombre = reader["Nombre"].ToString(),
                            Descripcion = reader["Descripcion"].ToString(),
                            Precio = Convert.ToDecimal(reader["Precio"]),
                            Costo = Convert.ToDecimal(reader["Costo"]),
                            Stock = Convert.ToDecimal(reader["Stock"]), // Mejor int si no usás fracciones
                            UnidadMedida = reader["UnidadMedida"].ToString(),
                            Categoria = reader["Categoria"].ToString(),
                            Estado = (Producto.EstadoProducto)Enum.Parse(typeof(Producto.EstadoProducto), reader["Estado"].ToString()),
                            FechaAlta = Convert.ToDateTime(reader["FechaAlta"]),
                            FechaModificacion = Convert.ToDateTime(reader["FechaModificacion"]),
                            Vencimiento = reader["Vencimiento"] != DBNull.Value ? Convert.ToDateTime(reader["Vencimiento"]) : (DateTime?)null,
                            Proveedor = null, // Implementar si querés traer el proveedor
                            CodigoInterno = Convert.ToInt32(reader["CodigoInterno"]),
                            ProveedorId = Convert.ToInt32(reader["ProveedorId"])
                        });
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al obtener productos: " + ex.Message);
        }

        return productos;
    }

    public bool AgregarProducto(Producto producto)
    {
        if (producto == null) return false;
        try
        {
            using (var conn = new SqliteConnection(connectionString))
            {
                conn.Open();
                string query = @"
                INSERT INTO Productos 
                (Nombre, Descripcion, Precio, Costo, Stock, UnidadMedida, Categoria, Estado, FechaAlta, FechaModificacion, Vencimiento, CodigoInterno, ProveedorId)
                VALUES 
                (@Nombre, @Descripcion, @Precio, @Costo, @Stock, @UnidadMedida, @Categoria, @Estado, @FechaAlta, @FechaModificacion, @Vencimiento, @CodigoInterno, @ProveedorId)";

                using (var cmd = new SqliteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Nombre", producto.Nombre);
                    cmd.Parameters.AddWithValue("@Descripcion", producto.Descripcion ?? "");
                    cmd.Parameters.AddWithValue("@Precio", producto.Precio);
                    cmd.Parameters.AddWithValue("@Costo", producto.Costo);
                    cmd.Parameters.AddWithValue("@Stock", producto.Stock);
                    cmd.Parameters.AddWithValue("@UnidadMedida", producto.UnidadMedida ?? "Unidad");
                    cmd.Parameters.AddWithValue("@Categoria", producto.Categoria ?? "General");
                    cmd.Parameters.AddWithValue("@Estado", producto.Estado.ToString());
                    cmd.Parameters.AddWithValue("@FechaAlta", producto.FechaAlta);
                    cmd.Parameters.AddWithValue("@FechaModificacion", producto.FechaModificacion);
                    cmd.Parameters.AddWithValue("@Vencimiento", producto.Vencimiento.HasValue ? (object)producto.Vencimiento.Value : DBNull.Value);
                    cmd.Parameters.AddWithValue("@CodigoInterno", producto.CodigoInterno);
                    cmd.Parameters.AddWithValue("@ProveedorId", producto.ProveedorId);

                    cmd.ExecuteNonQuery();
                }
            }
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al agregar producto: " + ex.Message);
            return false;
        }
    }

    public bool ExisteCodigoInterno(int codigo)
    {
        try
        {
            using (var conn = new SqliteConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM Productos WHERE CodigoInterno = @CodigoInterno";
                using (var cmd = new SqliteCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CodigoInterno", codigo);
                    long count = (long)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al verificar código interno: " + ex.Message);
            return true; // Si hay error asumimos que el código puede estar duplicado para evitar conflictos
        }
    }
}
