using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace MVC_Final
{
    public static class Global_Class
    {
        public static HttpClient userClient = new HttpClient();
        static Global_Class()
        {
            userClient.BaseAddress = new Uri("https://localhost:44362/api/");
            userClient.DefaultRequestHeaders.Clear();
            userClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}