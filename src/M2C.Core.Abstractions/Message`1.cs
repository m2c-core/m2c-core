using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using M2C.Core.Abstractions;

namespace M2C.Core
{
    public class Message<T> : IMessage<T> where T : class, new()
    {
        IRequest<T> IMessage<T>.Request { get;set; }
        IResponse<T> IMessage<T>.Response { get;set; }
        IEnumerable<IProperty> IMessage<T>.Context { get; set; }

    }
}
