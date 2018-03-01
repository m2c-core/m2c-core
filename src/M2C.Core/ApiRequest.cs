using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Net;

namespace M2C.Core
{
    [Serializable]
    public class ApiRequest
    {
        [XmlAttribute("scope")]
        public string Scope { get; set; }
        [XmlAttribute("zone")]
        public string Zone { get; set; }
        [XmlAttribute("name")]
        public string Name { get; set; }
        [XmlAttribute("protocol")]
        public string Protocol { get; set; }
        [XmlAttribute("verb")]
        public string HttpVerb { get; set; }
        [XmlAttribute("rootUrl")]
        public string RootUrl { get; set; }
        [XmlAttribute("url")]
        public string Url { get; set; }
        [XmlAttribute("queryString")]
        public string QueryString { get; set; }
        [IgnoreDataMember]
        [XmlIgnore]
        public bool IsHttps { get { return !String.IsNullOrWhiteSpace(Protocol) && Protocol.Equals("https", StringComparison.OrdinalIgnoreCase) ? true : false; } }

        [XmlElement("body")]
        public string Body { get; set; }

        [XmlIgnore]
        public List<Tuple<string,string>> Headers { get; set; }
    }


}
