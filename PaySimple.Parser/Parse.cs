using System;
using System.Linq;
using System.Collections.Generic;

namespace PaySimple.Parser
{
    public static class Parse
    {
        public static IDictionary<string, object> ToDict(object item)
        {
            return (IDictionary<string, object>)item;
        }

        public static string NativeType(object type)
        {
            var psType = type as string;
            var csType = default(string);
            if (psType != null)
                switch (psType.ToLower())
                {
                    case "boolean":
                        csType = "bool";
                        break;
                    
                    case "integer":
                        csType = "int";
                        break;

                    case "number":
                        csType = "decimal";
                        break;

                    default:
                        csType = psType;
                        break;
                }
            return csType;
        }

        public static bool IsRequired(object required)
        {
            return required == null ? false : (bool)required;
        }

        public static bool As<T>(
            IDictionary<string, object> items, string key, out T item)
        {
            object temp;
            item = default(T);
            var gotten = items.TryGetValue(key, out temp);
            if (gotten)
            {
                if (temp is T)
                    item = (T)temp;
                else
                    gotten = false;
            }
            return gotten;
        }

        // This is a list of types that exist for the API but are not
        // specifically listed by the schema documentation.
        static string[] _additionalTypes = new[]
        {
            "Accounts"
        };

        public static string MatchClosestTypeName(
            string type, out bool isPlural)
        {
            // This LINQ selects the best match by finding all
            // types that start with the same typename string but
            // then only grabbing the best match which is defined
            // as a match string with the greatest length.
            // Without the length check then LineItem would be
            // selected over LineItemTax.
            
            var available = SchemaReader
                .Current
                .Items
                .Values
                .Select(x => x.Type)
                .Concat(_additionalTypes);

            var closest = available
                .Where(x => type.StartsWith(
                    x,
                    StringComparison.CurrentCultureIgnoreCase))
                .Aggregate(
                    "",
                    (m, i) => m.Length > i.Length ? m : i);
            
            isPlural = type.IsPlural();
            
            return closest;
        }
    }
}
