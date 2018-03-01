using System;
using System.Collections.Generic;
using System.Text;

namespace M2C.Core.Abstractions
{
    public interface IParameter
    {
        string Key { get; set; }

        object Value { get; set; }
    }
}
