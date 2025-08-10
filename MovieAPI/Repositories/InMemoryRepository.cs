using MovieAPI.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MovieAPI.Repositories
{
    public class InMemoryRepository
    {
        private List<Genre> _genres;

        public InMemoryRepository()
        {
            _genres = new List<Genre>()
            {
                new Genre{Id=1, Name="Comedia"},
                new Genre {Id=2, Name="Accion"}
            };
        }

        public List<Genre> getAll()
        {
            return _genres;
        }

        public bool Exists(string name)
        {
            return _genres.Any(x => x.Name == name);
        }
    }
}
