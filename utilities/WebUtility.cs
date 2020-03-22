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

            if (string.IsNullOrEmpty(address.ToString())) throw new NullReferenceException("Supplied Uri is empty");

            if (!address.IsWellFormedOriginalString()) throw new ArgumentException("Uri is not well formed");

            string response;

            using HttpClient httpClient = new HttpClient();
            response = await httpClient.GetStringAsync(address.ToString());

            return response;
        }
        public static void DownloadFileAsync(Uri address, string fileName)
        {
            // Summary
            //
            // Perfroms basic error handling, and then downloads file from URI

            if (string.IsNullOrEmpty(address.ToString())) throw new NullReferenceException("Supplied Uri is null");

            if (!address.IsWellFormedOriginalString()) throw new ArgumentException("Uri is not well formed");

            using WebClient httpClient = new WebClient();
            httpClient.DownloadFileAsync(address, fileName);
        }
    }
}
