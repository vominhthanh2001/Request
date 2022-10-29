using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Request
{
    class Test
    {
        static void Main(string[] args)
        {
            //using HttpRequest
            HttpRequest request = new HttpRequest();
        }

        static void HeaderDemo_ListKeyValuePair()
        {
            //1
            List<KeyValuePair<string, string>> dataPost_1 = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("accept","*/*"),
                new KeyValuePair<string, string>("accept-encoding","gzip, deflate, br"),
                new KeyValuePair<string, string>("accept-language","vi,en-US;q=0.9,en;q=0.8"),
            };

            //2
            List<KeyValuePair<string, string>> dataPost_2 = new List<KeyValuePair<string, string>>();
            dataPost_2.Add(new KeyValuePair<string, string>("accept", "*/*"));
            dataPost_2.Add(new KeyValuePair<string, string>("accept-encoding", "gzip, deflate, br"));
            dataPost_2.Add(new KeyValuePair<string, string>("accept-language", "vi,en-US;q=0.9,en;q=0.8"));
        }

        static void HeaderDemo_Dictionary()
        {
            //1
            Dictionary<string, string> dataPost_1 = new Dictionary<string, string>()
            {
                { "accept", "*/*" },
                { "accept-encoding", "gzip, deflate, br" },
                { "accept-language", "vi,en-US;q=0.9,en;q=0.8" }
            };

            //2
            Dictionary<string, string> dataPost_2 = new Dictionary<string, string>();
            dataPost_2.Add("accept", "*/*");
            dataPost_2.Add("accept-encoding", "gzip, deflate, br");
            dataPost_2.Add("accept-language", "vi,en-US;q=0.9,en;q=0.8");
        }
    }
}
