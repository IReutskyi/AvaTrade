using System.Text.RegularExpressions;

namespace Musala.Tools
{
    public class Utilities
    {
        public static string ReplaceQuotesInFilePath(string filePath)
        {
            string pattern = @"(""(.*?)"")";
            string replacement = "$2";
            string result = Regex.Replace(filePath, pattern, replacement);
            return result;
        }
    }
}
