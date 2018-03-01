
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M2C.Core
{
    public static class ApiRequestFactory
    {

        
        public static ApiRequest Create(string rootUrl, string url,string httpVerb, string protocol = "http")
        {
            ApiRequest request = new ApiRequest() { RootUrl = rootUrl,Url = url, HttpVerb = httpVerb, Protocol = protocol };

            return request;
        }



    }
}
