using System;

namespace CafeteriaV2.Models.Entities
{
    public class VentaPublico
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public string MetodoPago { get; set; }

        public int? ClienteId { get; set; } // Puede ser null si la venta fue sin cliente
        public Cliente Cliente { get; set; } // Relación de navegación
    }
}
