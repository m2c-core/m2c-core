using System;
using System.Collections.Generic;
using System.Text;

namespace M2C.Core.Abstractions
{
    public interface IResponse<T> : IEnumerable<T> where T : class, new()
    {

        int Count { get; }

        long Elapsed { get; }

        T Model { get; }

        bool IsOkay { get; set; }

        IStatus Status { get; set; }

        IPage Page { get; set; }

        List<T> Items { get; set; }

    }
}
