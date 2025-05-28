using System;

namespace CafeteriaV2.Models.Entities
{
    public class ArqueoDiario
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public decimal SaldoInicial { get; set; }
        public decimal? SaldoFinal { get; set; }
        public decimal? TotalVentas { get; set; }
        public decimal? Diferencia { get; set; }
        public string Observaciones { get; set; }
        public string Usuario { get; set; }
        public string Turno { get; set; } // Turno1, Turno 2, etc.
    }
}