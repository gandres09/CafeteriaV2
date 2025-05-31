using System;

namespace CafeteriaV2.Models
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public decimal Costo { get; set; }
        public decimal Stock { get; set; }  // Cambiado de int a decimal
        public string UnidadMedida { get; set; }  // "Unidad" o "Peso"
        public string Categoria { get; set; }

        public enum EstadoProducto
        {
            Activo,
            Congelado
        }

        public EstadoProducto Estado { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime FechaModificacion { get; set; }
        public DateTime? Vencimiento { get; set; }
        public Proveedor Proveedor { get; set; }
        public int CodigoInterno { get; set; }
        public int ProveedorId { get; set; }
    }
}
