using M2C.Web.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace M2C.Web.Controllers
{
    public class ContextActionFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Controller c = context.Controller as Controller;
            if (c != null)
            {
                bool extant = false;
                HttpContext ctx = c.HttpContext;
                if (ctx.Items.ContainsKey("tenant"))
                {
                    var tenant = ctx.Items["tenant"] as Tenant;
                    if (tenant != null)
                    {
                        c.ViewBag.Tenant = tenant;
                        extant = true;
                    }
                }
                if (!extant)
                {
                    c.ViewBag.Tenant = new Tenant() { Display = "No Tenant", Title = "no-tenant", Status = "inactive", Subdomain = "none", GlobalId = Guid.NewGuid().ToString(), MetaTags = new List<MetaTag>() };
                }
            }
            base.OnActionExecuting(context);
        }
    }
}
