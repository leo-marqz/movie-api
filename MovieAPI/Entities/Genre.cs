using MovieAPI.Validations;
using System.ComponentModel.DataAnnotations;

namespace MovieAPI.Entities
{
    public class Genre
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        [FirstCapitalLetter]
        public string Name { get; set; }
    }
}
