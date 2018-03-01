﻿using System.Collections;
using System.Collections.Generic;
using System.Net;

namespace M2C.Core
{
    public class ApiResponse<T> : IEnumerable<T> where T : class, new()
    {
        public List<T> Items { get; set; }
        public ApiRequest<T> Request { get; set; }

        public HttpStatusCode StatusCode { get; set; }

        public string Message { get; set; }

        public string Body { get; set; }

        public bool IsOkay { get; set; }

        public T Model
        {
            get
            {
                if (Items != null && Items.Count >= 1)
                {
                    return Items[0];
                }
                else
                {
                    return default(T);
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)Items).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)Items).GetEnumerator();
        }
    }
}
