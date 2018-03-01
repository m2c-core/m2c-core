using System;
using System.Collections.Generic;
using System.Text;

namespace M2C.Core.Abstractions
{
    public interface IMessage<T> where T : class, new()
    {
        IEnumerable<IProperty> Context { get; set; }
        IRequest<T> Request { get; set; }
        IResponse<T> Response { get; set; }
    }
}
