using System;
using System.Collections.Generic;
using System.Text;

namespace M2C.Search.Abstractions
{
    public interface IQueryResponse<T> : IEnumerable<T> where T : class, new()
    {
        int PageSize { get; set; }
        int PageIndex { get; set; }
        int PageCount { get; }
        int Total { get; set; }
    }
}
