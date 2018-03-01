using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace M2C.Core.Abstractions
{
    public interface IDataService<T> where T : class, new()
    {
        IResponse<T> Get(IParameters parameters);

        IResponse<T> Delete(IParameters parameters);

        IResponse<T> Post(T model);

        IResponse<T> Put(T model, IParameters parameters);

        Task<IResponse<T>> GetAsync(IParameters parameters);

        Task<IResponse<T>> DeleteAsync(IParameters parameters);

        Task<IResponse<T>> PostAsync(T model);

        Task<IResponse<T>> PutAsync(T model, IParameters parameters);

    }
}
