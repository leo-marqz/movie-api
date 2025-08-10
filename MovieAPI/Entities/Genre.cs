using MovieAPI.Validations;

namespace MovieAPI.Entities
{
    public class Genre
    {
        public int Id { get; set; }

        [FirstCapitalLetter]
        public string Name { get; set; }
    }
}
