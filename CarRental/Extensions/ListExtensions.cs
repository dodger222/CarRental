using CarRental.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CarRental.Extensions
{
    public static class ListExtensions
    {
        public static List<T> ApplyOrdering<T>(this List<T> query, IQueryObject queryObj, Dictionary<string, Expression<Func<T, object>>> columnsMap)
        {
            if (String.IsNullOrWhiteSpace(queryObj.SortBy) || !columnsMap.ContainsKey(queryObj.SortBy))
                return query;

            if (queryObj.IsSortAscending)
            {
                return query.AsQueryable().OrderBy(columnsMap[queryObj.SortBy]).ToList();
            }
            else
            {
                return query.AsQueryable().OrderByDescending(columnsMap[queryObj.SortBy]).ToList();
            }
        }
    }
}
