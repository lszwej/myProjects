using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Łukasz_Szwej_Projekt
{
    class Analyzer_API
    {
        private Seeker seeker;
        private Selector selector;
        private Connector connector;

        public Analyzer_API()
        {
            selector = new Selector();
            seeker = new Seeker();
            connector = new Connector();
        }

        private string choose_pattern(string elem)
        {
            string pattern = selector.choose_pattern(elem);
            return pattern;
        }

        public string find_value(string elem, string src)
        {
            string pattern = selector.choose_pattern(elem);
            string value = seeker.find_value(pattern, src, elem);
            return value;
        }

        public string get_websitesrc(string address)
        {
            string source = connector.get_websitesrc(address);
            return source;
        }
    }
}
