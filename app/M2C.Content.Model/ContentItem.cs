using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace M2C.Content.Model
{
    public class ContentItem
    {
        public string Id { get; set; }

        public string Display { get; set; }

        public string Mime { get; set; }

        public string Body { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; }

        public List<Tag> Tags { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
