using System;
using System.Collections.Generic;
using System.Text;

namespace M2C.Core.Abstractions
{
    public interface IParameters : IEnumerable<IParameter>
    {
        void Add(string key, object parameterValue);

        bool ContainsKey(string key);

        string GetStrategyKey();

        bool HasStrategy();

        T GetValue<T>(string key);

        bool TryGetValue<T>(string key, out T t);
        
    }
}
