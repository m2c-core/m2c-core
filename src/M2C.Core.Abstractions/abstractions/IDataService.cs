using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace M2C.Core.Abstractions
{
    public interface IDataService
    {
        IResponse<T> Get<T>(IParameters parameters) where T : class, new();

        IResponse<T> Delete<T>(IParameters parameters) where T : class, new();

        IResponse<T> Post<T>(T model) where T : class, new();

        IResponse<T> Put<T>(T model, IParameters parameters) where T : class, new();

        Task<IResponse<T>> GetAsync<T>(IParameters parameters) where T : class, new();

        Task<IResponse<T>> DeleteAsync<T>(IParameters parameters) where T : class, new();

        Task<IResponse<T>> PostAsync<T>(T model) where T : class, new();

        Task<IResponse<T>> PutAsync<T>(T model, IParameters parameters) where T : class, new();

    }
}
