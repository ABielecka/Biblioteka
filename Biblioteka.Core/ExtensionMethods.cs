using System;

namespace Biblioteka.Core
{
    public static class ExtensionMethods
    {
        public static string Replace(this string str, string oldValue, string newValue)
        {
            var temp = str.Split(oldValue, StringSplitOptions.RemoveEmptyEntries);
            var result = String.Join(newValue, temp).Trim();
            return result.Trim();
        }
    }
}
