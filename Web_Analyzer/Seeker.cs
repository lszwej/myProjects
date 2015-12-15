using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Łukasz_Szwej_Projekt
{
    class Seeker
    {
        public string find_value(string pattern, string source, string elem)
        {
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            MatchCollection match_col = regex.Matches(source);

            if (elem.Equals("doctype") || elem.Equals("language") || elem.Equals("charset") || elem.Equals("keyword") || elem.Equals("title"))
            {
                if (match_col.Count != 0)
                    return  match_col[0].Groups[elem].Value;
                return "Not found";
            }
 
            return match_col.Count.ToString();
        }
    }
}
