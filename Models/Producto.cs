using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public bool Estado { get; set; } // "Activo" o "Congelado"
        public DateTime FechaAlta { get; set; }  // Fecha de alta del producto en el sistema
        public DateTime FechaModificacion { get; set; }  // Fecha de la última modificación del producto
        public DateTime Vencimiento { get; set; } // Fecha de vencimiento para productos perecederos
        public int CodigoInterno { get; set; }  // Código interno del producto, puede ser un código de barras o un SKU  
    }
}
