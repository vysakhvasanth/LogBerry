using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Logberry
{
    public class RegexLibrary
    {

        public static string readInfoRgx(string input)
        {
            Match match = Regex.Match(input, @"@@INFO*", RegexOptions.IgnoreCase);
            if (match.Success)
                return match.Groups[1].Value;
            return "";
        }

    }
}
