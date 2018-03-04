using M2C.Core.Abstractions;
using M2C.Web.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace M2C.Web.Middleware
{
    public class ContextHandler
    {
        private readonly RequestDelegate _Next;
        private IDataService<Tenant> _DataService;

        public ContextHandler(RequestDelegate next, IDataService<Tenant> dataService)
        {
            _Next = next;
            _DataService = dataService ?? throw new NullReferenceException(nameof(dataService));
        }

        public async Task Invoke(HttpContext context)
        {
            string rootUrl = String.Empty;
            string subdomain = String.Empty;
            var host = context.Request.Host;
            if (host.Host.StartsWith("localhost", StringComparison.OrdinalIgnoreCase))
            {
                rootUrl = "styx";
            }
            else
            {
                string[] t = host.Host.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
                if (t.Length.Equals(2))
                {
                    subdomain = t[0];
                    rootUrl = t[1];
                }
            }
            var response = _DataService.Get(null);
            if (response.IsOkay)
            {
                var found = response.First();
                found.RootUrl = rootUrl;
                found.TopLevelDomain = subdomain;
                if (found != null && !context.Items.ContainsKey("tenant"))
                {
                    context.Items.Add("tenant", found);
                }
            }
            //var request = context.Request;
            //var host = request.Host;
            //var path = request.Path;

            await _Next.Invoke(context);
        }




    }
}