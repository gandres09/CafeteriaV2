using System;
using System.Collections.Generic;

namespace CafeteriaV2.Modelos
{
    public class NotaCreditoCompra
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int ProveedorId { get; set; }
        public double Total { get; set; }
        public int UsuarioId { get; set; }
        public string Motivo { get; set; }

        public List<DetalleNotaCreditoCompra> Detalles { get; set; } = new List<DetalleNotaCreditoCompra>();
    }
}
