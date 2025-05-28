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
                            Stock = Convert.ToInt32(reader["Stock"]),
                            Categoria = reader["Categoria"].ToString(),
                            Estado = (Producto.EstadoProducto)Enum.Parse(typeof(Producto.EstadoProducto), reader["Estado"].ToString()),
                            FechaAlta = Convert.ToDateTime(reader["FechaAlta"]),
                            FechaModificacion = Convert.ToDateTime(reader["FechaModificacion"]),
                            Vencimiento = Convert.ToDateTime(reader["Vencimiento"]),
                            Proveedor = null, // Aquí podrías cargar el proveedor si es necesario
                            CodigoInterno = Convert.ToInt32(reader["CodigoInterno"]),
                            ProveedorId = Convert.ToInt32(reader["ProveedorId"])
                        });
                    }
                }
            }
        }
        catch (Exception ex)
        {
            // Acá podés registrar el error o mostrar un mensaje
            Console.WriteLine("Error al obtener productos: " + ex.Message);
        }


        return productos;
    }
}
