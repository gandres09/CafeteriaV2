using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using CafeteriaV2.Models;
using Microsoft.Data.Sqlite;


public class ProductoRepository
{
    private string connectionString = "Data Source=miCafeteria.db";

    public List<Producto> ObtenerTodos()
    {
        var productos = new List<Producto>();
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
                        Estado = Convert.ToBoolean(reader["Estado"]),
                        FechaAlta = Convert.ToDateTime(reader["FechaAlta"]),
                        FechaModificacion = Convert.ToDateTime(reader["FechaModificacion"]),
                        Vencimiento = Convert.ToDateTime(reader["Vencimiento"]),
                        CodigoInterno = Convert.ToInt32(reader["CodigoInterno"])
                    });
                }
            }
        }
        return productos;
    }
}
