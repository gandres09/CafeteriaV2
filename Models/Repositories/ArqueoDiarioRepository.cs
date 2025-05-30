using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CafeteriaV2.Data;
using CafeteriaV2.Models.Entities;
using Microsoft.Data.Sqlite;

public static class ArqueoDiarioRepository
{
    private static List<ArqueoDiario> arqueos = new List<ArqueoDiario>();
    public static void AgregarArqueo(ArqueoDiario arqueo)
    {
        arqueos.Add(arqueo);
    }
    public static List<ArqueoDiario> ObtenerArqueos()
    {
        return arqueos;
    }
    public static ArqueoDiario ObtenerArqueoPorId(int id)
    {
        return arqueos.FirstOrDefault(a => a.Id == id);
    }
    public static void ActualizarArqueo(ArqueoDiario arqueoActualizado)
    {
        var arqueo = ObtenerArqueoPorId(arqueoActualizado.Id);
        if (arqueo != null)
        {
            arqueo.Fecha = arqueoActualizado.Fecha;
            arqueo.SaldoInicial = arqueoActualizado.SaldoInicial;
            arqueo.SaldoFinal = arqueoActualizado.SaldoFinal;
            arqueo.TotalVentas = arqueoActualizado.TotalVentas;
            arqueo.Diferencia = arqueoActualizado.Diferencia;
            arqueo.Observaciones = arqueoActualizado.Observaciones;
            arqueo.Usuario = arqueoActualizado.Usuario;
        }
    }
    public static bool HayDiaIniciadoSinCerrar()
    {
        using (var connection = new SqliteConnection(BaseDatos.ConnectionString))
        {
            connection.Open();
            string query = "SELECT COUNT(*) FROM ArqueoDiario WHERE SaldoFinal IS NULL";
            using (var command = new SqliteCommand(query, connection))
            {
                long count = (long)command.ExecuteScalar();
                return count > 0;
            }
        }
    }
}