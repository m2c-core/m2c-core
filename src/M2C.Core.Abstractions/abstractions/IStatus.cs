using System;
using System.Collections.Generic;
using System.Text;

namespace M2C.Core.Abstractions
{
    public interface IStatus
    {
        int HttpCode { get; }

        string ReturnCode { get; }

        string Message { get; }

        string SystemMessage { get; }

        int Affected { get; }

    }
}
