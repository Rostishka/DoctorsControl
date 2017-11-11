using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace DAL.Utils
{
    public static class Extentions
    {
        public static IQueryable<T> OptionalInclude<T>(this IQueryable<T> query, string include) where T : class
        {
            return query = include != null ? query.Include(include) : query;
        }
    }
}
