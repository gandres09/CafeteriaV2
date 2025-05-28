using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CafeteriaV2.Models.Entities;
using Microsoft.Data.Sqlite;

public class ClienteRepository
{
    private string connectionString = "Data Source=miCafeteria.db";
    public List<Cliente> ObtenerTodos()
    {
        var clientes = new List<Cliente>();
        try
        {
            using (var conn = new SqliteConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Clientes";
                using (var cmd = new SqliteCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        clientes.Add(new Cliente
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Nombre = reader["Nombre"].ToString(),
                            Telefono = reader["Telefono"].ToString(),
                            Email = reader["Email"].ToString(),
                            FechaAlta = Convert.ToDateTime(reader["FechaAlta"]),
                            PuntosAcumulados = Convert.ToInt32(reader["PuntosAcumulados"]),
                            Estado = reader["Estado"].ToString()
                        });
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al obtener clientes: " + ex.Message);
        }
        return clientes;
    }
}