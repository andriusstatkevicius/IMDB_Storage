using IMDB_Storage.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace IMDB_Storage.Utilities
{
    public static class Regexes
    {
        public static RegexOptions regexOptions = RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.Multiline;
        public static Regex Title = new Regex(@"div\s*class=\s*\u0022\s*title_wrapper\s*\u0022\s*>[^>]*>([^<]*)\s*<", regexOptions);
        public static Regex GenresArea = new Regex(@">Genres(?:[^\n]*\n){1,20}\s*</div>", regexOptions);
        public static Regex Rate = new Regex(@"strong\s*title\s*=\u0022\s*(\d{1,2}[.,]{1}\d{1})\s*based\s*on", regexOptions);
        private static List<Genre> result = Enum.GetValues(typeof(Genre)).Cast<Genre>().ToList();
        public static Regex Genres = new Regex(@$">\s*({string.Join("|", result)})\s*<", regexOptions);

        public static string TryGetString(this MatchCollection input, int index, int groupIndex)
        {
            string result;
            try
            {
                result = input[index].Groups[groupIndex].Value.Trim();
            }
            catch (ArgumentOutOfRangeException)
            {
                return null;
            }

            return result;
        }

        public static string[] TryGetArray(this MatchCollection input, int index, int groupIndex, bool isSingleArray = true)
        {
            string[] result;

            try
            {
                result = input.Select(c => c.Groups[groupIndex].Value.Trim()).ToArray();
            } catch (ArgumentOutOfRangeException)
            {
                return null;
            }

            return result;
        }
    }
}
