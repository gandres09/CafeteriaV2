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
        using (var conn = new SqliteConnection(connectionString)) // Esto requiere System.Data.SQLite
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
                        Precio = Convert.ToDecimal(reader["Precio"]),
                        Stock = Convert.ToInt32(reader["Stock"])
                    });
                }
            }
        }
        return productos;
    }
}
