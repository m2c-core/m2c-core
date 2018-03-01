using M2C.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace M2C.Core
{
    public class Parameter : IParameter
    {
        public string Key { get; set; }

        public object Value { get; set; }


    }
}
