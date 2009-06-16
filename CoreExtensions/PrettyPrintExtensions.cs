using System.Collections;
using System.Linq;

namespace CoreExtensions
{
    public static class PrettyPrintExtensions
    {
        private const string NullText = "<NULL>";

        public static string PrettyPrint(this object value)
        {
            if (value == null)
                return NullText;

            var stringValue = value as string;
            if (stringValue != null)
                return PrettyPrint(stringValue);

            var dictionaryValue = value as IDictionary;
            if (dictionaryValue != null)
                return PrettyPrint(dictionaryValue);

            var collectionValue = value as ICollection;
            if (collectionValue != null)
                return PrettyPrint(collectionValue);

            return value.ToString();
        }

        public static string PrettyPrint(this string value)
        {
            if (value == null)
                return NullText;

            return string.Format("\"{0}\"", value);
        }

        public static string PrettyPrint(this ICollection value)
        {
            var data = value.Map(item => item.PrettyPrint()).ToArray();
            return "[" + string.Join(", ", data) + "]";
        }
        
        public static string PrettyPrint(this IDictionary value)
        {
            var data = value.Keys.Map(key => string.Format("{0} => {1}", key.PrettyPrint(), value[key].PrettyPrint()));
            return "{" + string.Join(", ", data.ToArray()) + "}";
        }
    }
}