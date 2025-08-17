using MovieAPI.Validations;
using System.ComponentModel.DataAnnotations;

namespace MovieAPI.DTOs
{
    public class GenreRequestDto
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El campo {0} debe tener entre {2} y {1} caracteres!")]
        [FirstCapitalLetter(ErrorMessage = "El campo {0} debe iniciar con una letra mayuscula!")]
        public string Name { get; set; }
    }
}
