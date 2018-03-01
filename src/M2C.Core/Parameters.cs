using M2C.Core.Abstractions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace M2C.Core
{
    public class Parameters : IParameters
    {
        private const string StrategyKey = "919C4AC2";

        private ParameterCollection _Parameters = new ParameterCollection();

        #region ctor

        public Parameters(string key, object paramValue)
        {
            AddParam(key, paramValue);
        }

        public Parameters(string key, string paramValue)
        {
            AddParam(key, paramValue);
        }
        public Parameters(string key, int paramValue)
        {
            AddParam(key, paramValue);
        }
        public Parameters(string key, decimal paramValue)
        {
            AddParam(key, paramValue);
        }
        public Parameters(string key, DateTime paramValue)
        {
            AddParam(key, paramValue);
        }
        public Parameters()
        {

        }

        #endregion



        public void Add(string key, object parameterValue)
        {
            AddParam(key, parameterValue);
        }

        #region Add overrides
        public void Add(string key, string value)
        {
            _Parameters.Add(new Parameter() { Key = key, Value = value });
        }
        public void Add(string key, int value)
        {
            _Parameters.Add(new Parameter() { Key = key, Value = value });
        }
        public void Add(string key, decimal value)
        {
            _Parameters.Add(new Parameter() { Key = key, Value = value });
        }
        public void Add(string key, DateTime value)
        {
            _Parameters.Add(new Parameter() { Key = key, Value = value });
        }

        #endregion

        public bool ContainsKey(string key)
        {
            if (String.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentNullException(nameof(key));
            }
            return _Parameters.Contains(key);
        }

        public IEnumerator<IParameter> GetEnumerator()
        {
            return ((IEnumerable<Parameter>)_Parameters).GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<Parameter>)_Parameters).GetEnumerator();
        }

        public string GetStrategyKey()
        {
            string s = String.Empty;
            if (HasStrategy())
            {
                s = (string)_Parameters[StrategyKey].Value;
            }
            return s;
        }

        public T GetValue<T>(string key)
        {
            T t = default(T);
            if (_Parameters.Contains(key))
            {
                Parameter p = _Parameters[key];
                if (p.Value is T)
                {
                    t = (T)p.Value;
                }
            }
            return t;
        }

        public bool HasStrategy()
        {
            return _Parameters.Contains(StrategyKey);
        }

        public bool TryGetValue<T>(string key, out T t)
        {
            bool b = false;
            t = default(T);
            if (_Parameters.Contains(key) && _Parameters[key].Value is T)
            {
                t = (T)_Parameters[key].Value;
                b = true;
            }
            return b;
        }

        private void AddParam(string key, object paramValue)
        {
            if (!_Parameters.Contains(key))
            {
                _Parameters.Add(new Parameter() { Key = key, Value = paramValue });
            }
        }



    }
}
