using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MoviesLibraryExercise.ServiceLibrary
{
    internal static class LinqExtensions
    {
        internal static bool CheckObjectPropertiesContains<TEntity, TProperty>(this TEntity entity, TProperty value)
        {
            var t = typeof(TEntity);

            foreach (var info in t.GetProperties())
            {
                var val = info.GetValue(entity, null);

                if (val != null)
                {
                    if (info.PropertyType.Name == "String[]")
                    {
                        val = string.Join(" ", (string[])val);
                    }

                    var propValue = val.ToString().ToLower();

                    if (propValue.Contains(value.ToString().ToLower()))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}