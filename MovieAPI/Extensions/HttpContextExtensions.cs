using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPI.Extensions
{
    public static class HttpContextExtensions
    {
        public static async Task InsertPaginationParametersInTheHeaders<T>(
            this HttpContext httpContext, 
            IQueryable<T> queryable)
        {
            if(httpContext is null)
                throw new ArgumentNullException(nameof(httpContext));

            double total = await queryable.CountAsync();
            httpContext.Response.Headers.Append(
                key: "x-total-records", 
                value: total.ToString()
                );
        }
    }
}
