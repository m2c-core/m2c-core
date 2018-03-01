using System;
using System.Collections.Generic;
using System.Text;
using M2C.Core.Abstractions;
using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.Configuration;

namespace M2C.Data.Abstractions
{
    public class ConnectionStringProvider : IConnectionStringProvider
    {
        private IConfiguration _Configuration;
        private Func<string> _GetConnectionString = null;
        public ConnectionStringProvider(Func<string> getConnectionString)
        {
            _GetConnectionString = getConnectionString;
        }

        public ConnectionStringProvider(IConfiguration configuration)
        {
            _Configuration = configuration;
        }

        public ConnectionStringProvider()
        {

        }

        string IConnectionStringProvider.Get()
        {
            return _Configuration.GetConnectionString("storage");
        }

        string IConnectionStringProvider.Get<T>()
        {
            return _Configuration.GetConnectionString("storage");
        }

        string IConnectionStringProvider.Get<T>(IParameters parameters)
        {
            return _Configuration.GetConnectionString("storage");
        }

        string IConnectionStringProvider.Get<T>(T model)
        {
            if (_GetConnectionString == null)
            {
                string typeName = typeof(T).Name.ToLower();
                string key = String.Format("{0}.storage", typeName);
                //return _Configuration.GetConnectionString(key);
                return _Configuration.GetConnectionString("storage"); ;
            }
            else
            {
                return _GetConnectionString();
            }
        }

        string IConnectionStringProvider.Get<T>(T model, IParameters parameters)
        {
            return _Configuration.GetConnectionString("storage");
        }
    }
}
