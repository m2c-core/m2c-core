using System;
using System.Collections.Generic;
using System.Text;

namespace M2C.Data.Abstractions
{
    public interface IResponseFactory
    {
        DataResponse<T> Create<T>() where T : class, new();
    }
}
