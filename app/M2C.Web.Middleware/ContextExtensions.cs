using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Text;

namespace M2C.Web.Middleware
{
    public static class ContextExtensions
    {
        public static IApplicationBuilder UseContext(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ContextHandler>();
        }


    }
}
