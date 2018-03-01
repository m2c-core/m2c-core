using System;
using System.Collections.Generic;
using System.Text;
using M2C.Core;

namespace M2C.Data.Abstractions
{
    public interface IApiResolver
    {
        Protocol Protocol<T>(HttpVerb httpVerb);
        string BaseUrl<T>(HttpVerb httpVerb);
        string Url<T>(HttpVerb httpVerb);
    }
}
