namespace CafeteriaV2.Modelos
{
    public class DetalleNotaCreditoCompra
    {
        public int Id { get; set; }
        public int NotaCreditoId { get; set; }
        public int ProductoId { get; set; }
        public double Cantidad { get; set; }
        public double PrecioUnitario { get; set; }
        public double Subtotal { get; set; }
    }
}
