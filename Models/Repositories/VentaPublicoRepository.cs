using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CafeteriaV2.Models.Entities;
using Microsoft.Data.Sqlite;

public class VentaPublicoRepository
{
    private string connectionString = "Data Source=miCafeteria.db";
    public List<VentaPublico> ObtenerTodas()
    {
        var ventas = new List<VentaPublico>();
        try
        {
            using (var conn = new SqliteConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM VentasPublico";
                using (var cmd = new SqliteCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ventas.Add(new VentaPublico
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Fecha = Convert.ToDateTime(reader["FechaVenta"]),
                            Total = Convert.ToDecimal(reader["Total"]),
                            MetodoPago = (VentaPublico.TiposDeMetodoPago)Enum.Parse(typeof(VentaPublico.TiposDeMetodoPago), reader["MetodoPago"].ToString()),
                            ClienteId = reader["ClienteId"] as int? // Puede ser nulo
                        });
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al obtener ventas: " + ex.Message);
        }
        return ventas;
    }
}