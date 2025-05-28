using System;

namespace CafeteriaV2.Models.Entities
{
    public class MovimientoPuntos
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public DateTime Fecha { get; set; }
        public int Puntos { get; set; } // Deben ser positivos
        public string Motivo { get; set; }
        public Cliente Cliente { get; set; } // Relación opcional para navegación
    }
}