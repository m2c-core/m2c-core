using M2C.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace M2C.Data.Abstractions
{
    public class DataRequestService : IDataRequestService
    {
        private IDataService _Service = null;
        public DataRequestService(IDataService service)
        {
            if (service == null)
            {
                throw new NotImplementedException(nameof(IDataService));
            }
            _Service = service;
        }
        IResponse<T> IDataRequestService.Delete<T>(IRequest<T> request)
        {
            throw new NotImplementedException();
        }

        Task<IResponse<T>> IDataRequestService.DeleteAsync<T>(IRequest<T> request)
        {
            throw new NotImplementedException();
        }

        IResponse<T> IDataRequestService.Get<T>(IRequest<T> request)
        {
            if (request == null)
            {
                throw new NullReferenceException(nameof(IRequest<T>));
            }

            throw new NotImplementedException();
        }

        Task<IResponse<T>> IDataRequestService.GetAsync<T>(IRequest<T> request)
        {
            throw new NotImplementedException();
        }

        IResponse<T> IDataRequestService.Post<T>(IRequest<T> request)
        {
            throw new NotImplementedException();
        }

        Task<IResponse<T>> IDataRequestService.PostAsync<T>(IRequest<T> request)
        {
            throw new NotImplementedException();
        }

        IResponse<T> IDataRequestService.Put<T>(IRequest<T> request)
        {
            throw new NotImplementedException();
        }

        Task<IResponse<T>> IDataRequestService.PutAsync<T>(IResponse<T> request)
        {
            throw new NotImplementedException();
        }
    }
}
