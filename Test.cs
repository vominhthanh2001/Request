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
            //Init 1
            HttpRequest request = new HttpRequest();

            request.SetCookie("cookie", "/", ".facebook");

            List<KeyValuePair<string, string>> headers_pair = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("accept","*/*"),
                new KeyValuePair<string, string>("accept-encoding","gzip, deflate, br"),
                new KeyValuePair<string, string>("accept-language","vi,en-US;q=0.9,en;q=0.8"),
            };

            //Init 2
            HttpRequest request_1 = new HttpRequest(headers_pair);

            Dictionary<string, string> headers_dic = new Dictionary<string, string>()
            {
                { "accept", "*/*" },
                { "accept-encoding", "gzip, deflate, br" },
                { "accept-language", "vi,en-US;q=0.9,en;q=0.8" }
            };

            //Init 3
            HttpRequest request_2 = new HttpRequest(headers_dic);
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
