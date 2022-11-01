using System.ComponentModel.DataAnnotations;

namespace APIVentas.Entities
{
    public class Factura
    {
        public int Id { get; set; }
        public double Subtotal { get; set; }
        public double Igv { get; set; }
        public double TotalFactura { get; set; }
        public double FechaEmision { get; set; }

        public List<Pedido> Pedidos { get; set; }
    }
}
