using M2C.Search.Abstractions;

namespace M2C.Content.Search
{
    public class ContentQueryFacet : IQueryFacet
    {
        public QueryOperator Operator { get ; set; }
        public string Token { get; set; }
        public string Display { get; set; }
        public string ValueToken { get; set; }
        public object Value { get; set; }
    }
}
