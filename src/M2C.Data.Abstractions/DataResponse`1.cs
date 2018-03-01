using M2C.Core.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace M2C.Data.Abstractions
{
    public class DataResponse<T> : IResponse<T> where T : class, new()
    {
        private List<T> _Items = new List<T>();
        public List<T> Items
        {
            get { return _Items; }
            set { _Items = value; }
        }

        public T Model
        {
            get { return _Items.Count > 0 ? _Items[0] : default(T); }
        }

        private bool _IsOkay = false;
        bool IResponse<T>.IsOkay { get { return _IsOkay; } set { _IsOkay = value; } }

        private IStatus _Status = null;
        IStatus IResponse<T>.Status { get { return _Status; } set { _Status = value; } }

        int IResponse<T>.Count { get { return Items.Count; } }

        private int _Elapsed = 0;
        long IResponse<T>.Elapsed { get { return _Elapsed; } }
        T IResponse<T>.Model
        {
            get { return _Items.Count > 0 ? _Items[0] : default(T); }
        }

        private IPage _Page = null;
        public IPage Page
        {
            get
            {
                if (_Page == null)
                {
                    int total = Items.Count;
                    _Page = new DataPage(total);
                }
                else if (_Page.Total == 0)
                {
                    _Page.Total = _Items.Count;
                }
                return _Page;
            }
            set { _Page = value; }
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return ((IEnumerable<T>)_Items).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<T>)_Items).GetEnumerator();
        }
    }
}
