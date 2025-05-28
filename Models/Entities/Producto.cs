using System;

namespace CafeteriaV2.Models
{
    public class Producto
    {
        public int Id { get; set; } // Identificador único del producto
        public string Nombre { get; set; } // Nombre del producto
        public string Descripcion { get; set; } // Descripción del producto
        public decimal Precio { get; set; }  // Precio de venta del producto
        public decimal Costo { get; set; }  // Costo de adquisición del producto
        public int Stock { get; set; }  // Cantidad disponible en inventario
        public string Categoria { get; set; }  // Categoría del producto (por ejemplo, Bebidas, Comidas, Postres, etc.)
        public enum EstadoProducto
        {
            Activo,
            Congelado
        }
        public EstadoProducto Estado { get; set; }  // Estado del producto (Activo o Congelado)
        public DateTime FechaAlta { get; set; }  // Fecha de alta del producto en el sistema
        public DateTime FechaModificacion { get; set; }  // Fecha de la última modificación del producto
        public DateTime? Vencimiento { get; set; } // Fecha de vencimiento para productos perecederos
        public Proveedor Proveedor { get; set; }  // Proveedor asociado al producto, puede ser nulo si no hay proveedor asignado
        public int CodigoInterno { get; set; }  // Código interno del producto, puede ser un código de barras o un SKU  
        public int ProveedorId { get; set; }  // Identificador del proveedor asociado al producto
    }
}
