using MovieAPI.Entities;
using System.Collections.Generic;
using System.Linq;

namespace MovieAPI.Repositories
{
    public interface IInMemoryRepository
    {
        List<Genre> getAll();
        bool Exists(string name);
        Genre GetById(int id);
        Genre Create(Genre genre);
    }

    public class InMemoryRepository : IInMemoryRepository
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

        public Genre GetById(int id)
        {
            return _genres.FirstOrDefault(x => x.Id == id);
        }

        public Genre Create(Genre genre)
        {
            this._genres.Add(genre);
            return genre;
        }
    }
}
