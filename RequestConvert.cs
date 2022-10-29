using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Request
{
    public class RequestConvert
    {
        public static List<KeyValuePair<string, string>> DictionaryToListKeyValuePair(Dictionary<string, string> dic)
        {
            List<KeyValuePair<string, string>> keyValuePairs = new List<KeyValuePair<string, string>>();

            foreach (var d in dic)
            {
                keyValuePairs.Add(new KeyValuePair<string, string>(d.Key, d.Value));
            }

            return keyValuePairs;
        }

        public static Dictionary<string, string> ListKeyValuePairToDictionary(List<KeyValuePair<string, string>> keyValuePairs)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();

            foreach (var pair in keyValuePairs)
            {
                dic.Add(pair.Key, pair.Value);
            }

            return dic;
        }
    }
}
