using System;
using System.Collections.Generic;
using System.Text;

namespace M2C.Search.Abstractions
{
    [Flags]
    public enum QueryOperator
    {
        EqualTo = 1,
        Not = 2,
        GreaterThan = 4,
        LessThan = 8,
    }
}
