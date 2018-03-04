using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace M2C.Search.Abstractions
{
    public interface ISearchService<T> where T : class, new()
    {
        IQueryContext<T> Execute(IQueryContext<T> queryContext);

        Task<IQueryContext<T>> ExecuteAsync(IQueryContext<T> queryContext);
    }
}
