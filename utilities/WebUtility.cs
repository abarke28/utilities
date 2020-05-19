using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace utilities
{
    public static class WebUtility
    {
        public static async Task<string> DownloadStringAsync(Uri address)
        {
            // Summary
            //
            // Performas basic error handling and then downloads string for URI

            if (!IsValidUri(address)) throw new ArgumentException("Invalid URI");

            using HttpClient httpClient = new HttpClient();
            string response = await httpClient.GetStringAsync(address.ToString());

            return response;
        }

        public static void DownloadFileAsync(Uri address, string fileName)
        {
            // Summary
            //
            // Perfroms basic error handling, and then downloads file from URI

            if (!IsValidUri(address)) throw new ArgumentException("Invalid URI");

            if (!address.IsFile) throw new ArgumentException("Supplied URI is not a file");

            using WebClient webClient = new WebClient();
            webClient.DownloadFileAsync(address, fileName);
        }

        public static bool IsValidUri(Uri address)
        {
            // Summary
            //
            // Validates supplied Web Address is valid

            // Validate not null
            if (string.IsNullOrEmpty(address.ToString())) return false;

            // Is well formed
            if (!address.IsWellFormedOriginalString()) return false;

            return true;
        }

        public static Task<HttpResponseMessage> PostAsync(this HttpClient http, string requestUri, object content)
        {
            /// <summary>
            /// Extension: Send a POST request to the specified Uri as an asynchronous operation.
            /// Content is serialized as Json with UTF8 encoding.
            /// </summary>
            /// <param name="requestUri">The Uri the request is sent to.</param>

            var objectJson = JsonConvert.SerializeObject(content);
            var contentStr = new StringContent(objectJson, Encoding.UTF8, "application/json");

            return http.PostAsync(requestUri, contentStr);
        }

        public static Task<HttpResponseMessage> PutAsync(this HttpClient http, string requestUri, object content)
        {
            /// <summary>
            /// Extension: Send a PUT request to teh specified Uri as an asynchronous operation.
            /// Content is serialized as Json with UTF8 encoding.
            /// </summary>
            /// <param name="http"></param>
            /// <param name="requestUri"></param>
            /// <param name="content"></param>
            /// <returns></returns>

            var objectJson = JsonConvert.SerializeObject(content);
            var contentStr = new StringContent(objectJson, Encoding.UTF8, "application/json");

            return http.PutAsync(requestUri, contentStr);
        }
    }
}