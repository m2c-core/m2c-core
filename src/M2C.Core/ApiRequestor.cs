using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;

namespace M2C.Core
{
    public static class ApiRequestor
    {
        public static ApiResponse Execute(ApiRequest request, IEnumerable<Tuple<string,string>> headers)
        {
            ApiResponse response = new ApiResponse();
            response.Request = request;
            HttpStatusCode code = HttpStatusCode.InternalServerError;
            string body = String.Empty;
            string message = string.Empty;
            if (ExecuteCall(request.RootUrl,request.Url,request.IsHttps,headers, out code,out body, out message))
            {

                response.Body = body;
                
            }
            response.StatusCode = code;
            response.Message = message;


            return response;
        }

        private static bool  ExecuteCall(string rootUrl, string url, bool isHttps,IEnumerable<Tuple<string,string>> headers, out HttpStatusCode statusCode, out string responseBody, out string message)
        {
            statusCode = HttpStatusCode.InternalServerError;
            bool b = false;
            message = String.Empty;
            responseBody = String.Empty;
            string protocol = isHttps ? "https":"http";

            if (!String.IsNullOrWhiteSpace(rootUrl) && !String.IsNullOrWhiteSpace(url))
            {
                
                using (var client = new HttpClient())
                {
                    HttpResponseMessage response = null;

                    client.BaseAddress = new Uri(String.Format("{0}://{1}",protocol,rootUrl));
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    if (headers != null && headers.Count() > 0)
                    {
                        foreach (var header in headers)
                        {
                            client.DefaultRequestHeaders.Add(header.Item1, header.Item2);
                        }
                    }

                    try
                    {
                        response = client.GetAsync(url, HttpCompletionOption.ResponseContentRead).Result;
                    }
                    catch (Exception ex)
                    {
                        message = ex.InnerException != null ? ex.InnerException.Message : ex.Message;                        
                    }
                    if (response != null)
                    {
                        statusCode = response.StatusCode;
                        if (!response.IsSuccessStatusCode)
                        {
                            
                        }
                        else
                        {
                            b = true;
                            var t = response.Content.ReadAsStringAsync();
                            responseBody = t.Result;
                        }
                    }
                }
            }

            return b;
        }

        private static bool Execute(string rootUrl, string url,bool isHttps, out string responseBody, out HttpStatusCode statusCode)
        {
            bool b = false;
            statusCode = HttpStatusCode.InternalServerError;
            responseBody = String.Empty;
            return b;
        }
    }
}
