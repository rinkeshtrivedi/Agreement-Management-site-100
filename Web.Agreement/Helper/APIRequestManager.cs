using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;

namespace Web.Agreement.Helper
{
    public class APIRequestManager
    {
        public static HttpClient webAPiClient=new HttpClient();

        static APIRequestManager()
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;

            webAPiClient.BaseAddress = new Uri("https://localhost:44311/api/");
            webAPiClient.DefaultRequestHeaders.Clear();
            webAPiClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }


    }
}