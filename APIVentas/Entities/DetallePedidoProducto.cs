namespace APIVentas.Entities
{
    public class DetallePedidoProducto
    {
        public int Id { get; set; }
        public int PedidoId { get; set; }
        public int ProductoId { get; set; }

        public Pedido Pedido { get; set; }
        public Producto Producto { get; set; }
    }
}
