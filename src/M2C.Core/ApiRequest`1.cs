﻿using System;
using System.Collections.Generic;

namespace M2C.Core
{
    public class ApiRequest<T>  where T : class, new()
    {

        public Protocol Protocol { get; set; }

        public HttpVerb HttpVerb { get; set; }

        public string RootUrl { get; set; }

        public string Url { get; set; }

        public Dictionary<string,object> QueryString { get; set; }

        public object RouteParameter { get; set; }

        public bool IsHttps { get { return Protocol == Protocol.Https; } }

        public string Body { get; set; }

        public List<Tuple<string, string>> Headers { get; set; }

        public T Model { get; set; }

    }
}
