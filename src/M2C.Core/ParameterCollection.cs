using System.Collections.ObjectModel;

namespace M2C.Core
{
    public class ParameterCollection : KeyedCollection<string, Parameter>
    {
        protected override string GetKeyForItem(Parameter item)
        {
            return item.Key;
        }
    }
}
