using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CoreExtensions
{
    public static class PrettyPrintExtensions
    {
        public static string NullText = "<NULL>";

        private static readonly IDictionary<Type, Func<object, string>> typeMap = new Dictionary<Type, Func<object, string>>();

        static PrettyPrintExtensions()
        {
            Set<string>(value => string.Format("\"{0}\"", value));
            
            Set<ICollection>(value =>
            {
                var data = value.Map(item => item.PrettyPrint()).ToArray();
                return string.Format("[{0}]", string.Join(", ", data));
            });

            Set<IDictionary>(value =>
            {
                var data = value.Keys.Map(key => string.Format("{0} => {1}", key.PrettyPrint(), value[key].PrettyPrint()));
                return "{" + string.Join(", ", data.ToArray()) + "}";
            });
        }

        public static void Set<T>(Func<T, string> prettyPrinter)
        {
            typeMap[typeof(T)] = new Func<object, string>(obj => prettyPrinter((T)obj));
        }

        public static string PrettyPrint(this object value)
        {
            if (value == null)
                return NullText;

            // Look for exact match first
            if (typeMap.ContainsKey(value.GetType()))
                return typeMap[value.GetType()](value);

            // Look for subclass
            var baseTypes = GetAllBaseTypes(value.GetType());
            var matchingType = baseTypes.Find(type => typeMap.ContainsKey(type));
            if (matchingType != null)
            {
                // Save for next time
                typeMap[value.GetType()] = typeMap[matchingType];
                return typeMap[matchingType](value);
            }

            return value.ToString();
        }

        private static List<Type> GetAllBaseTypes(Type type)
        {
            var result = new List<Type>(type.GetInterfaces());
            var superclass = type.BaseType;
            while (superclass != null)
            {
                result.Add(superclass);
                superclass = superclass.BaseType;
            }
            return result;
        }
    }
}