using System;

namespace CafeteriaV2.Models.Entities
{
    public class VentaPublico
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public enum TiposDeMetodoPago {
            Tarjeta,
            Efectivo,
            Otros
        }
        public TiposDeMetodoPago MetodoPago { get; set; } // Método de pago utilizado
        public int? ClienteId { get; set; } // Puede ser null si la venta fue sin cliente
        public Cliente Cliente { get; set; } // Relación de navegación
    }
}

