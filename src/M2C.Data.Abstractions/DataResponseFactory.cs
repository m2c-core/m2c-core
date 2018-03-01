using System;
using System.Collections.Generic;
using System.Text;

namespace M2C.Data.Abstractions
{
    public class DataResponseFactory : IResponseFactory
    {
        DataResponse<T> IResponseFactory.Create<T>()
        {
            return new DataResponse<T>() { };
        }
    }
}
