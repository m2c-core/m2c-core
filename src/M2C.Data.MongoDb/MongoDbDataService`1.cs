using M2C.Core.Abstractions;
using M2C.Data.Abstractions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace M2C.Data.MongoDb
{
    public abstract class MongoDbDataService<T> : IDataService<T> where T : class, new()
    {
        public IConnectionStringProvider ConnectionStringProvider { get; set; }

        public ILogger Logger { get; set; }

        public IResponseFactory ResponseFactory { get; set; }


        IResponse<T> IDataService<T>.Delete(IParameters parameters)
        {
            return Delete(parameters);
        }

        Task<IResponse<T>> IDataService<T>.DeleteAsync(IParameters parameters)
        {
            return DeleteAsync(parameters);
        }

        IResponse<T> IDataService<T>.Get(IParameters parameters)
        {
            return Get(parameters);
        }


        Task<IResponse<T>> IDataService<T>.GetAsync(IParameters parameters)
        {
            throw new NotImplementedException();
        }

        IResponse<T> IDataService<T>.Post(T model)
        {
            return Post(model);
        }

        Task<IResponse<T>> IDataService<T>.PostAsync(T model)
        {
            throw new NotImplementedException();
        }

        IResponse<T> IDataService<T>.Put(T model, IParameters parameters)
        {
            return Put(model, parameters);
        }

        Task<IResponse<T>> IDataService<T>.PutAsync(T model, IParameters parameters)
        {
            throw new NotImplementedException();
        }


        protected virtual IResponse<T> Delete(IParameters parameters)
        {
            throw new NotImplementedException(nameof(Delete));
        }

        protected virtual Task<IResponse<T>> DeleteAsync(IParameters parameters)
        {
            throw new NotImplementedException(nameof(DeleteAsync));
        }

        protected virtual IResponse<T> Get(IParameters parameters)
        {
            throw new NotImplementedException(nameof(Get));
        }

        protected virtual Task<IResponse<T>> GetAsync(IParameters parameters)
        {
            throw new NotImplementedException(nameof(GetAsync));
        }

        protected virtual IResponse<T> Post(T model)
        {
            throw new NotImplementedException(nameof(Post));
        }

        protected virtual Task<IResponse<T>> PostAsync(T model)
        {
            throw new NotImplementedException(nameof(PostAsync));
        }

        protected virtual IResponse<T> Put(T model, IParameters parameters)
        {
            throw new NotImplementedException(nameof(Put));
        }

        protected virtual Task<IResponse<T>> PutAsync(T model, IParameters parameters)
        {
            throw new NotImplementedException(nameof(PutAsync));
        }



    }
}
