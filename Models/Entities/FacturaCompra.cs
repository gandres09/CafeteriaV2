using System;
using System.Collections.Generic;

namespace CafeteriaV2.Modelos
{
    public class FacturaCompra
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int ProveedorId { get; set; }
        public double Total { get; set; }
        public int UsuarioId { get; set; }

        public List<DetalleFacturaCompra> Detalles { get; set; } = new List<DetalleFacturaCompra>();
    }
}
