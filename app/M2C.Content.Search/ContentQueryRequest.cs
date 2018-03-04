using M2C.Search.Abstractions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace M2C.Content.Search
{
    public class ContentQueryRequest : IQueryRequest
    {
        public List<ContentQueryFacet> Facets { get; set; }

        IEnumerator<IQueryFacet> IEnumerable<IQueryFacet>.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
