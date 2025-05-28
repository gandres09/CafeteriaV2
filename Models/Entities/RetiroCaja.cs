using System;

namespace CafeteriaV2.Models.Entities
{
    public class RetiroCaja
    {
        public int Id { get; set; }
        public int? ArqueoId { get; set; }
        public int UsuarioId { get; set; }
        public string Turno { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Monto { get; set; }
        public string Motivo { get; set; }
    }
}
