using CafeteriaV2.Models;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;

public class ProveedorRepository
{
    private string connectionString = "Data Source=miCafeteria.db";

    public List<Proveedor> ObtenerTodos()
    {
        var proveedores = new List<Proveedor>();
        try
        {
            using (var conn = new SqliteConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Proveedores";
                using (var cmd = new SqliteCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        proveedores.Add(new Proveedor
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Nombre = reader["Nombre"].ToString(),
                            RUT = reader["RUT"].ToString(),
                            Telefono = reader["Telefono"].ToString(),
                            Email = reader["Email"].ToString(),
                            Direccion = reader["Direccion"].ToString(),
                            FechaAlta = Convert.ToDateTime(reader["FechaAlta"]),
                            FechaModificacion = Convert.ToDateTime(reader["FechaModificacion"])
                        });
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al obtener proveedores: " + ex.Message);
        }

        return proveedores;
    }
}
