using System;
using System.Collections.Generic;
using System.Text;

namespace M2C.Search.Abstractions
{
    public interface IQueryFacet
    {
        QueryOperator Operator { get; set; }
        string Token { get; set; }
        string Display { get; set; }
        string ValueToken { get; set; }
        object Value { get; set; }
    }
}
