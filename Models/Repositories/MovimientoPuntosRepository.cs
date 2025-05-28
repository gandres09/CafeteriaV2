using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CafeteriaV2.Models.Entities;
using Microsoft.Data.Sqlite;

public class MovimientoPuntosRepository
{
    private string connectionString = "Data Source=miCafeteria.db";
    public List<MovimientoPuntos> ObtenerTodos()
    {
        var movimientos = new List<MovimientoPuntos>();
        try
        {
            using (var conn = new SqliteConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM MovimientoPuntos";
                using (var cmd = new SqliteCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        movimientos.Add(new MovimientoPuntos
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            ClienteId = Convert.ToInt32(reader["ClienteId"]),
                            Fecha = Convert.ToDateTime(reader["Fecha"]),
                            Puntos = Convert.ToInt32(reader["Puntos"]),
                            Motivo = reader["TipoMovimiento"].ToString(),
                            Cliente = null // Aquí podrías cargar el cliente si es necesario
                        });
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al obtener movimientos de puntos: " + ex.Message);
        }
        return movimientos;
    }
}