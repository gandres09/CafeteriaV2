using System;
public enum TipoPromocion
{
    PorcentajeDescuento,
    DosPorUno,
    ProductoConPuntos,
    DescuentoMontoFijo,
    Ninguna
}

public class Promocion
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Descripcion { get; set; }

    public bool Activa { get; set; }
    public TipoPromocion Tipo { get; set; }

    public decimal DescuentoPorcentaje { get; set; }
    public decimal DescuentoFijo { get; set; }
    public decimal MontoMinimo { get; set; }

    public int ProductoId { get; set; } // Para promociones específicas
    public int PuntosOtorgados { get; set; }

    public DateTime FechaInicio { get; set; }
    public DateTime FechaFin { get; set; }

    public bool Aplica(decimal total, DateTime fecha, int productoId = 0)
    {
        if (!Activa || fecha < FechaInicio || fecha > FechaFin)
            return false;

        switch (Tipo)
        {
            case TipoPromocion.PorcentajeDescuento:
            case TipoPromocion.DescuentoMontoFijo:
                return total >= MontoMinimo;

            case TipoPromocion.DosPorUno:
            case TipoPromocion.ProductoConPuntos:
                return productoId == ProductoId;

            default:
                return false;
        }
    }

    public decimal Aplicar(decimal total, int cantidad = 1)
    {
        switch (Tipo)
        {
            case TipoPromocion.PorcentajeDescuento:
                return total - (total * DescuentoPorcentaje / 100m);

            case TipoPromocion.DescuentoMontoFijo:
                return total - DescuentoFijo;

            case TipoPromocion.DosPorUno:
                int cantidadCobrar = (cantidad / 2) + (cantidad % 2);
                decimal precioUnitario = total / cantidad;
                return cantidadCobrar * precioUnitario;

            default:
                return total;
        }
    }
}
