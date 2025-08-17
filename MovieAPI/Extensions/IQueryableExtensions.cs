using MovieAPI.DTOs;
using System.Linq;

namespace MovieAPI.Extensions
{
    public static class IQueryableExtensions
    {
        public static IQueryable<T> Paginate<T>(
            this IQueryable<T> queryable, PaginationDto pagination
            )
        {
            //Skip: registros a saltarse.
            //Take: registros a tomar luego del salto con skip.
            return queryable 
                .Skip((pagination.Page - 1) * pagination.RecordsPerPage)
                .Take(pagination.RecordsPerPage);
        }
    }
}
