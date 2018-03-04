using System;
using System.Collections.Generic;
using System.Text;

namespace M2C.Web.Model
{
    public class Tenant
    {
        public string Id { get; set; }
        public string GlobalId { get; set; }
        public string Subdomain { get; set; }

        public string Title { get; set; }

        public List<MetaTag> MetaTags { get; set; }

        public string Display { get; set; }

        public List<Image> Images { get; set; }

        public string Status { get; set; }

        public string RootUrl { get; set; }

        public string TopLevelDomain { get; set; }
    }
}
