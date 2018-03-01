using M2C.Core.Abstractions;
using M2C.Data.Abstractions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace M2C.Data.SqlServer
{

    public abstract class SqlServerDataService<T> : IDataService<T> where T : class, new()
    {
        private const string _ErrorMessage = "SqlServer Data Error";

        public IConnectionStringProvider ConnectionStringProvider { get; set; }

        public ILogger Logger { get; set; }

        public IResponseFactory ResponseFactory { get; set; }

        protected string ErrorMessage { get { return GetGeneralErorMessage(); } }

        protected virtual string GetGeneralErorMessage()
        {
            return _ErrorMessage;
        }



        public SqlServerDataService(
            IConnectionStringProvider connectionStringProvider,
            IResponseFactory responseFactory)
        {
            ConnectionStringProvider = connectionStringProvider;
            ResponseFactory = responseFactory;
        }

        public SqlServerDataService()
        {

        }


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
            return GetAsync(parameters);
        }

        IResponse<T> IDataService<T>.Post(T model)
        {
            return Post(model);
        }

        Task<IResponse<T>> IDataService<T>.PostAsync(T model)
        {
            return PostAsync(model);
        }

        IResponse<T> IDataService<T>.Put(T model, IParameters parameters)
        {
            return Put(model, parameters);
        }

        Task<IResponse<T>> IDataService<T>.PutAsync(T model, IParameters parameters)
        {
            return PutAsync(model, parameters);
        }



        protected virtual IResponse<T> Delete(IParameters parameters)
        {
            var response = CreateResponse();
            try
            {
                using (SqlConnection cn = GetConnection())
                {
                    cn.Open();
                    using (SqlCommand cmd = cn.CreateCommand())
                    {
                        InitializeDeleteCommand(cmd, parameters);
                        try
                        {
                            int i = cmd.ExecuteNonQuery();
                            if (i == 0)
                            {
                                response.SetStatus(i, false);
                            }
                            else
                            {
                                response.SetStatus(i, true);
                            }
                        }
                        catch (Exception ex)
                        {
                            response.SetStatus(ex, 500);
                            LogError(ex, parameters);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                response.SetStatus(ex, 500);
                LogError(ex, parameters);
            }
            return response;
        }

        protected virtual async Task<IResponse<T>> DeleteAsync(IParameters parameters)
        {
            var response = CreateResponse();
            try
            {
                using (SqlConnection cn = GetConnection())
                {
                    await cn.OpenAsync().ConfigureAwait(false);
                    using (SqlCommand cmd = cn.CreateCommand())
                    {
                        InitializeGetCommand(cmd, parameters);
                        try
                        {
                            var o = await cmd.ExecuteNonQueryAsync();
                            bool b = o > 0;
                            response.SetStatus(o, b);
                        }
                        catch (Exception ex)
                        {
                            response.SetStatus(ex, 500);
                            LogError(ex, parameters);
                        }
                    }
                }
                response.TrySetPage<T>(parameters);
            }
            catch (Exception ex)
            {
                response.SetStatus(ex, 500);
                LogError(ex, parameters);
            }
            return response;
        }

        protected virtual IResponse<T> Get(IParameters parameters)
        {
            var response = CreateResponse();
            response.SetStatus(true);
            try
            {
                using (SqlConnection cn = GetConnection())
                {
                    cn.Open();
                    using (SqlCommand cmd = cn.CreateCommand())
                    {
                        InitializeGetCommand(cmd, parameters);
                        try
                        {
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                Borrow(reader, response.Items);
                            }
                        }
                        catch (Exception ex)
                        {
                            response.SetStatus(ex, 500);
                            LogError(ex, parameters);
                        }
                    }
                }
                response.TrySetPage<T>(parameters);
            }
            catch (Exception ex)
            {
                response.SetStatus(ex, 500);
                LogError(ex, parameters);
            }
            return response;
        }

        protected virtual async Task<IResponse<T>> GetAsync(IParameters parameters)
        {
            var response = CreateResponse();
            response.SetStatus(true);
            try
            {
                using (SqlConnection cn = GetConnection())
                {
                    await cn.OpenAsync().ConfigureAwait(false);
                    using (SqlCommand cmd = cn.CreateCommand())
                    {
                        InitializeGetCommand(cmd, parameters);
                        try
                        {
                            SqlDataReader reader = await cmd.ExecuteReaderAsync(System.Data.CommandBehavior.Default);
                            Borrow(reader, response.Items);
                        }
                        catch (Exception ex)
                        {
                            response.SetStatus(ex, 500);
                            LogError(ex, parameters);
                        }
                    }
                }
                response.TrySetPage<T>(parameters);
            }
            catch (Exception ex)
            {
                response.SetStatus(ex, 500);
                LogError(ex, parameters);
            }
            return response;
        }

        protected virtual IResponse<T> Post(T model)
        {
            var response = CreateResponse();
            response.SetStatus(true);
            try
            {
                using (SqlConnection cn = GetConnection())
                {
                    cn.Open();
                    using (SqlCommand cmd = cn.CreateCommand())
                    {
                        InitializePostCommand(cmd, model);
                        try
                        {
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                Borrow(reader, response.Items);
                            }
                        }
                        catch (Exception ex)
                        {
                            response.SetStatus(ex, 500);
                            LogError(ex, model);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                response.SetStatus(ex, 500);
                LogError(ex, model);
            }
            return response;
        }

        protected virtual async Task<IResponse<T>> PostAsync(T model)
        {
            var response = CreateResponse();
            response.SetStatus(true);
            try
            {
                using (SqlConnection cn = GetConnection())
                {
                    await cn.OpenAsync().ConfigureAwait(false);
                    using (SqlCommand cmd = cn.CreateCommand())
                    {
                        InitializePostCommand(cmd, model);
                        try
                        {
                            SqlDataReader reader = await cmd.ExecuteReaderAsync(System.Data.CommandBehavior.Default);
                            Borrow(reader, response.Items);
                        }
                        catch (Exception ex)
                        {
                            response.SetStatus(ex, 500);
                            LogError(ex, model);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                response.SetStatus(ex, 500);
                LogError(ex, model);
            }
            return response;
        }

        protected virtual IResponse<T> Put(T model, IParameters parameters)
        {
            var response = CreateResponse();
            response.SetStatus(true);
            try
            {
                using (SqlConnection cn = GetConnection())
                {
                    cn.Open();
                    using (SqlCommand cmd = cn.CreateCommand())
                    {
                        InitializePutCommand(cmd, model, parameters);
                        try
                        {
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                Borrow(reader, response.Items);
                            }
                        }
                        catch (Exception ex)
                        {
                            response.SetStatus(ex, 500);
                            LogError(ex, parameters);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                response.SetStatus(ex, 500);
                LogError(ex, parameters);
            }
            return response;
        }

        protected virtual async Task<IResponse<T>> PutAsync(T model, IParameters parameters)
        {
            var response = CreateResponse();
            response.SetStatus(true);
            try
            {
                using (SqlConnection cn = GetConnection())
                {
                    await cn.OpenAsync().ConfigureAwait(false);
                    using (SqlCommand cmd = cn.CreateCommand())
                    {
                        InitializePutCommand(cmd, model, parameters);
                        try
                        {
                            SqlDataReader reader = await cmd.ExecuteReaderAsync(System.Data.CommandBehavior.Default);
                            Borrow(reader, response.Items);
                        }
                        catch (Exception ex)
                        {
                            response.SetStatus(ex, 500);
                            LogError(ex, parameters, model);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                response.SetStatus(ex, 500);
                LogError(ex, parameters, model);
            }
            return response;
        }



        protected virtual void InitializeDeleteCommand(SqlCommand cmd, IParameters parameters)
        {
            throw new NotImplementedException(nameof(InitializeDeleteCommand));
        }

        protected virtual void InitializeGetCommand(SqlCommand cmd, IParameters parameters)
        {
            throw new NotImplementedException(nameof(InitializeGetCommand));
        }

        protected virtual void InitializePostCommand(SqlCommand cmd, T model)
        {
            throw new NotImplementedException(nameof(InitializePostCommand));
        }

        protected virtual void InitializePutCommand(SqlCommand cmd, T model, IParameters parameters)
        {
            throw new NotImplementedException(nameof(InitializePutCommand));
        }

        protected virtual void Borrow(SqlDataReader reader, List<T> list)
        {
            throw new NotImplementedException(nameof(Borrow));
        }

        protected virtual SqlConnection GetConnection()
        {
            SqlConnection connection = null;

            if (ConnectionStringProvider == null)
            {
                return new SqlConnection("Data Source=(local);Initial Catalog=demo;Integrated Security=True");
                //throw new NullReferenceException(nameof(ConnectionStringProvider));
            }

            string connectionString = ConnectionStringProvider.Get<T>();
            if (String.IsNullOrWhiteSpace(connectionString))
            {
                throw new NullReferenceException(nameof(connectionString));
            }

            connection = new SqlConnection(connectionString);
            if (connection == null)
            {
                throw new NullReferenceException(nameof(connection));
            }

            return connection;
        }



        protected virtual DataResponse<T> CreateResponse()
        {
            if (ResponseFactory != null)
            {
                return ResponseFactory.Create<T>();
            }
            else
            {
                return new DataResponse<T>();

            }

        }

        private void LogError(Exception ex, IParameters parameters = null)
        {
            if (parameters != null)
            {
                Logger.LogError(ex, ErrorMessage, parameters.ToList());
            }
            else
            {
                Logger.LogError(ex, ErrorMessage, ErrorMessage);
            }


        }
        private void LogError(Exception ex, T model = null)
        {
            if (model != null)
            {
                Logger.LogError(ex, ErrorMessage, model);
            }
            else
            {
                Logger.LogError(ex, ErrorMessage, ErrorMessage);
            }

        }
        private void LogError(Exception ex, IParameters parameters = null, T model = null)
        {
            if (parameters != null)
            {
                Logger.LogError(ex, ErrorMessage, parameters.ToList());
            }
            else if (model != null)
            {
                Logger.LogError(ex, ErrorMessage, model);
            }
            else
            {
                Logger.LogError(ex, ErrorMessage, ErrorMessage);
            }

        }

    }
}
