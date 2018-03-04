using M2C.Search.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace M2C.Content.Search
{
    public static class QueryExtensions
    {
        public static IQueryContext<T> Parse<T>(this IQueryContext<T> queryContext, string input) where T : class, new()
        {
            if (!String.IsNullOrWhiteSpace(input))
            {
                queryContext.Request = new ContentQueryRequest().Parse(input);
            }

            return queryContext;
        }

        public static IQueryRequest Parse(this ContentQueryRequest queryRequest, string input)
        {
            queryRequest.Facets = new List<ContentQueryFacet>().Parse(input);
            return queryRequest;
        }

        public static List<ContentQueryFacet> Parse(this List<ContentQueryFacet> queryFacets, string input)
        {
            if (!String.IsNullOrWhiteSpace(input))
            {
                HashSet<string> hs = new HashSet<string>();
                
                if (input.StartsWith("?"))
                {
                    string[] kvps = input.TrimStart('?').Split(new char[] { '&' });
                    foreach (var kvp in kvps)
                    {
                        string[] t = kvp.Split(new char[] { '=' });
                        if (hs.Add(t[0]))
                        {
                            queryFacets.Add(new ContentQueryFacet()
                            {
                                Operator = QueryOperator.EqualTo,
                                Token = t[0],
                                Value = t[1],
                            });
                        }
                    }
                }
                else
                {
                    string[] kvps = input.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (var kvp in kvps)
                    {
                        string key = kvp.Substring(0, kvp.IndexOf('-'));
                        string val = kvp.Substring(kvp.IndexOf('-') + 1);
                        if (hs.Add(key))
                        {
                            queryFacets.Add(new ContentQueryFacet()
                            {
                                Operator = QueryOperator.EqualTo,
                                Token = key,
                                Value = val,
                            });
                        }
                    }
                }
            }
            return queryFacets;
        }
    }
}
