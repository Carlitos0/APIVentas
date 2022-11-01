using System.ComponentModel.DataAnnotations;

namespace APIVentas.Entities
{
    public class Proveedor
    {
        public int Id { get; set; }
        public string Direccion { get; set; }
        [Phone]
        [StringLength(9)]
        public int Telefono { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public bool Estado { get; set; }

        public List<Pedido> Pedidos { get; set; }
    }
}
