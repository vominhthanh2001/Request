using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Request
{
    public class HttpRequest
    {
        public HttpRequest()
        {
            _cookieContainer = new CookieContainer();

            _handler = new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,
                CookieContainer = _cookieContainer
            };

            _client = new HttpClient(_handler);
        }

        public HttpRequest(Dictionary<string, string> headers)
        {
            _cookieContainer = new CookieContainer();

            _handler = new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,
                CookieContainer = _cookieContainer
            };

            _client = new HttpClient(_handler);

            SetHeader(headers);
        }

        public HttpRequest(List<KeyValuePair<string, string>> headers)
        {
            _cookieContainer = new CookieContainer();

            _handler = new HttpClientHandler
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate,
                CookieContainer = _cookieContainer
            };

            _client = new HttpClient(_handler);

            SetHeader(headers);
        }

        private HttpClientHandler _handler { get; set; }
        private HttpClient _client { get; set; }
        private CookieContainer _cookieContainer { get; set; }

        public void SetHeader(Dictionary<string, string> headers)
        {
            foreach (var item in headers)
            {
                _client.DefaultRequestHeaders.TryAddWithoutValidation(item.Key, item.Value);
            }
        }

        public void SetHeader(List<KeyValuePair<string, string>> headers)
        {
            foreach (var item in headers)
            {
                _client.DefaultRequestHeaders.TryAddWithoutValidation(item.Key, item.Value);
            }
        }

        public void SetCookie(string cookieInput, string path, string domain)
        {
            string[] cookieArgs = cookieInput.Split(';');

            foreach (var cookie in cookieArgs)
            {
                string[] ckSplit = cookie.Split('=');

                if (string.IsNullOrEmpty(cookie))
                {
                    continue;
                }

                if (ckSplit.Length != 2)
                {
                    continue;
                }

                try
                {
                    string name = ckSplit[0].Trim();
                    string value = ckSplit[1].Trim();
                    Cookie ck = new Cookie(name, value, path, domain);

                    _cookieContainer.Add(ck);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public void SetCookie(List<Cookie> cookies)
        {
            foreach (var cookie in cookies)
            {
                try
                {
                    _cookieContainer.Add(cookie);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public string GetCookie(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new Exception("Url Is Null");
            }

            if (_cookieContainer == null)
            {
                return null;
            }

            string cookie = null;
            Uri uri = new Uri(url);
            List<Cookie> cookies = _cookieContainer.GetCookies(uri).Cast<Cookie>().ToList();

            int length = cookies.Count;
            for (int i = 0; i < length; i++)
            {
                if ((i + 1) == length)
                {
                    cookie += $"{cookies[i].Name}={cookies[i].Value}";
                    break;
                }

                cookie += $"{cookies[i].Name}={cookies[i].Value};";
            }

            return cookie;
        }

        public string Get(string url)
        {
            var response = _client.GetAsync(url).Result;
            byte[] buffer = response.Content.ReadAsByteArrayAsync().Result;
            string result = Encoding.UTF8.GetString(buffer, 0, buffer.Length);

            return result;
        }

        public string Post(string url, string dataPost)
        {
            var content = new StringContent(dataPost, Encoding.UTF8, "application/json");
            var response = _client.PostAsync(url, content).Result;
            byte[] buffer = response.Content.ReadAsByteArrayAsync().Result;
            string result = Encoding.UTF8.GetString(buffer, 0, buffer.Length);

            return result;
        }

        public string Post(string url, object dataPostObject)
        {
            string dataPost = JsonConvert.SerializeObject(dataPostObject);
            var content = new StringContent(dataPost, Encoding.UTF8, "application/json");
            var response = _client.PostAsync(url, content).Result;
            byte[] buffer = response.Content.ReadAsByteArrayAsync().Result;
            string result = Encoding.UTF8.GetString(buffer, 0, buffer.Length);

            return result;
        }

        public string Post(string url, StringContent content)
        {
            var response = _client.PostAsync(url, content).Result;
            byte[] buffer = response.Content.ReadAsByteArrayAsync().Result;
            string result = Encoding.UTF8.GetString(buffer, 0, buffer.Length);

            return result;
        }
        public string Post(string url, Dictionary<string, string> dataPost)
        {
            var response = _client.PostAsync(url, new FormUrlEncodedContent(dataPost)).Result;
            byte[] buffer = response.Content.ReadAsByteArrayAsync().Result;
            string result = Encoding.UTF8.GetString(buffer, 0, buffer.Length);

            return result;
        }

        public string Post(string url, List<KeyValuePair<string, string>> dataPost)
        {
            var response = _client.PostAsync(url, new FormUrlEncodedContent(dataPost)).Result;
            byte[] buffer = response.Content.ReadAsByteArrayAsync().Result;
            string result = Encoding.UTF8.GetString(buffer, 0, buffer.Length);

            return result;
        }

        public string Post(string url, MultipartFormDataContent content)
        {
            var response = _client.PostAsync(url, content).Result;
            byte[] buffer = response.Content.ReadAsByteArrayAsync().Result;
            string result = Encoding.UTF8.GetString(buffer, 0, buffer.Length);

            return result;
        }
    }
}
