using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIVentas.Entities
{
    public class Producto
    {
        public int Id { get; set; }
        public string NombreProducto { get; set; }
        public double Precio { get; set; }
        public int Stock { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Fecha_Entrada { get; set; } = DateTime.Now;
        public bool Estado { get; set; }

        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
    }
}
