using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace M2C.Core.Abstractions
{
    public interface IDataRequestService
    {
        IResponse<T> Get<T>(IRequest<T> request) where T : class, new();

        IResponse<T> Delete<T>(IRequest<T> request) where T : class, new();

        IResponse<T> Post<T>(IRequest<T> request) where T : class, new();

        IResponse<T> Put<T>(IRequest<T> request) where T : class, new();


        Task<IResponse<T>> GetAsync<T>(IRequest<T> request) where T : class, new();

        Task<IResponse<T>> DeleteAsync<T>(IRequest<T> request) where T : class, new();

        Task<IResponse<T>> PostAsync<T>(IRequest<T> request) where T : class, new();

        Task<IResponse<T>> PutAsync<T>(IResponse<T> request) where T : class, new();

    }
}
