using System;

namespace CafeteriaV2.Models.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string ContrasenaHash { get; set; }
        public string Rol { get; set; } // Admin, Cajero, etc.
        public string Estado { get; set; } // Activo, Inactivo
        public DateTime FechaAlta { get; set; }
    }
}
