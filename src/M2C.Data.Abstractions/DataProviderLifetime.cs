using System;
using System.Collections.Generic;
using System.Text;

namespace M2C.Data.Abstractions
{
    public enum DataProviderLifetime
    {
        Transient,
        Scoped,
        Singleton,
    }
}
