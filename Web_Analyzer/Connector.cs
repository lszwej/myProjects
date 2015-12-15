using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace Łukasz_Szwej_Projekt
{
    class Connector
    {
        public string get_websitesrc(string addr)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(addr);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader sr = new StreamReader(response.GetResponseStream());
            string src = sr.ReadToEnd();
            sr.Close();
            return src;
        }
    }
}
