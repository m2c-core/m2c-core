using System;
using System.Collections.Generic;
using System.Text;

namespace M2C.Core.Abstractions
{
    public interface IProjection
    {
        IEnumerable<string> Data { get; set; }
    }
}
