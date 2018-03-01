using System;
using System.Collections.Generic;
using System.Text;

namespace M2C.Core.Abstractions
{
    public interface ITypeMap
    {
        Type ModelType { get; }

        Type DataProviderType { get; }
    }
}
