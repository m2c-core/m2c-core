using M2C.Content.Model;
using M2C.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace M2C.Content.Data.Api
{
    public class ContentItemDataService : ApiDataService<ContentItem>
    {


        protected override void InitializeRequest<T>(ApiRequest<T> request)
        {
            base.InitializeRequest(request);
        }

        protected override Protocol ResolveProtocol<T>(HttpVerb httpVerb)
        {
            return Protocol.Http;
        }

        protected override string ResolveRootUrl<T>(HttpVerb httpVerb)
        {
            return "localhost:65123";
        }

        protected override string ResolveUrl<T>(HttpVerb httpVerb)
        {
            return "api/content";
        }
    }
}
