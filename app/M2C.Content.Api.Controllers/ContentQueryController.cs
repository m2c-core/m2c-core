using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using M2C.Content.Model;
using M2C.Content.Search;
using M2C.Search.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace M2C.Content.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/query/{*tokens}")]
    public class ContentQueryController : Controller
    {
        public IQuery<ContentItem> Query { get; set; }
        [HttpGet]
        public IActionResult Get(string tokens = "")
        {
            IQueryResponse<ContentItem> response = null;

            var qs = Request.QueryString;
            if (qs.HasValue)
            {
                IQueryRequest request = new ContentQueryRequest().Parse(qs.Value);
                response = Query.Execute(request);
            }

            if (response == null)
            {
                return Json(new { Message = "unable to execute query" });
            }
            else
            {
                return Json(response);
            }

        }

        private List<KeyValuePair<string,object>> ParseQuery(string queryString)
        {
            List<KeyValuePair<string, object>> list = new List<KeyValuePair<string, object>>();

            string[] t = queryString.TrimStart('?').Split(new char[] { '&' });
            foreach (var s in t)
            {
                string key = s.Substring(0, s.IndexOf('='));
                string val = s.Substring(s.IndexOf('=')+1);
                list.Add(new KeyValuePair<string, object>(key, val));

            }
            return list;
        }


    }
}
