using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace M2C.Search.Abstractions
{
    public interface IQuery<T> where T : class, new()
    {
        IQueryResponse<T> Execute(IQueryRequest queryRequest);

        IQueryResponse<T> Execute(NameValueCollection nvc);
    }
}
