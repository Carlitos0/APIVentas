using System.ComponentModel.DataAnnotations;

namespace APIVentas.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string ApellidoUsuario { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
