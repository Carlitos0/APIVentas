using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIVentas.Entities
{
    public class Categoria
    {
        public int Id { get; set; }
        public string CategoriaName { get; set; }
    }
}
