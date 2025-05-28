using System;

namespace CafeteriaV2.Models.Entities
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public DateTime FechaAlta { get; set; }
        public int PuntosAcumulados { get; set; }
        public string Estado { get; set; } // Por ejemplo: "Activo", "Inactivo"
    }
}