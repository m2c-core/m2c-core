using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace M2C.Core
{
    public class ApiResponse
    {
        public ApiRequest Request { get; set; }

        public HttpStatusCode StatusCode { get; set; }
        public string Message { get; set; }

        public string Body { get; set; }

    }
}
