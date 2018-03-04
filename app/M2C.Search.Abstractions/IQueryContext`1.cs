using System;
using System.Collections.Generic;
using System.Text;

namespace M2C.Search.Abstractions
{
    public interface IQueryContext<T> where T : class, new()
    {
        IQueryRequest Request { get; set; }
        IQueryResponse<T> Response { get; set; }
    }
}
