using System;

namespace CafeteriaV2.Models
{
    public class Proveedor
    {
        public int Id { get; set; } // ID único del proveedor
        public string Nombre { get; set; } // Nombre o razón social
        public string RUT { get; set; } // RUT o identificación fiscal
        public string Telefono { get; set; } // Teléfono de contacto
        public string Email { get; set; } // Correo electrónico
        public string Direccion { get; set; } // Dirección física
        public DateTime FechaAlta { get; set; } // Fecha de alta en el sistema
        public DateTime FechaModificacion { get; set; } // Última modificación
    }
}