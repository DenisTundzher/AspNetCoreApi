using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using DAL.Entity;

namespace DAL.Repository
{
    public static class Extensions
    {
        public static IQueryable<T> Sort<T>(this IQueryable<T> query,
            string sortField,
            SortDirection direction)
        {

            sortField = sortField.FirstCharToUpper();
            PropertyInfo property = query.GetType().GetGenericArguments()[0].GetProperty(sortField);

            if (direction == SortDirection.Ascending)
                return query.OrderBy(s => property.GetValue(s, null));
            return query.OrderByDescending(s => property.GetValue(s, null));
            }
        public static string FirstCharToUpper(this string input)
        {
            switch (input)
            {
                case null: throw new ArgumentNullException(nameof(input));
                case "": throw new ArgumentException($"{nameof(input)} cannot be empty", nameof(input));
                default: return input.First().ToString().ToUpper() + input.Substring(1);
            }
        }
    }

    public enum SortDirection
    {
        Ascending,
        Descending
    }
}
