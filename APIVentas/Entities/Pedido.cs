using System.ComponentModel.DataAnnotations;

namespace APIVentas.Entities
{
    public class Pedido
    {
        public int Id { get; set; }
        public double CantidadPedido { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaPedido { get; set; }
        [DataType(DataType.Date)]
        public DateTime FechaEntrega { get; set; }
        
        public int ProveedorId { get; set; }
        public int FacturaId { get; set; }

        public Proveedor Proveedor { get; set; }
        public Factura Factura { get; set; }
    }
}
