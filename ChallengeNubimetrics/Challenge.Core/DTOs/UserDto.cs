using System.ComponentModel.DataAnnotations;

namespace Challenge.Core.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        [MinLength(2, ErrorMessage = "La cantidad mínima de caracteres para el nombre es de 2")]
        public string Nombre { get; set; } = null!;
        [MinLength(2, ErrorMessage = "La cantidad mínima de caracteres para el apellido es de 2")]
        public string Apellido { get; set; } = null!;

        [MinLength(8,ErrorMessage ="La cantidad mínima de caracteres para el Email es de 8")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; } = null!;
        [MinLength(5, ErrorMessage = "La cantidad mínima de caracteres para el Password es de 5")]
        public string Password { get; set; } = null!;
    }
}
