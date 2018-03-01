using M2C.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace M2C.Data.Abstractions
{
    public static class DataResponseExtensions
    {
        public static void SetStatus<T>(this IResponse<T> response, bool isOkay, int httpCode = 200, string message = "Okay") where T : class, new()
        {
            response.Status = new DataStatus() { HttpCode = httpCode, Message = message };
            response.IsOkay = isOkay;
        }

        public static void SetStatus<T>(this IResponse<T> response, int modelsAffected, bool isOkay, int httpCode = 200) where T : class, new()
        {
            string modelName = typeof(T).Name;
            string message = String.Format("{0} {1}s affected", modelsAffected, modelName);
            response.Status = new DataStatus() { HttpCode = httpCode, Message = message, Affected = modelsAffected };
            response.IsOkay = isOkay;

        }

        public static void SetStatus<T>(this IResponse<T> response, Exception ex, int httpCode = 500, string message = "Internal Server Error") where T : class, new()
        {
            string systemMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
            response.Status = new DataStatus() { HttpCode = httpCode, SystemMessage = systemMessage, Message = message };
            response.IsOkay = false;

        }

        public static void TrySetPage<T>(this IResponse<T> response, IParameters parameters) where T : class, new()
        {
            if (parameters != null && parameters.IsPage())
            {
                response.Page = parameters.GetPage();
            }
        }

        public static bool IsPage(this IParameters parameters)
        {
            bool b = false;

            return b;
        }

        internal static IPage GetPage(this IParameters parameters)
        {
            DataPage page = new DataPage() { };

            return page;
        }



    }
}
