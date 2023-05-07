using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Framework.Tools
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
