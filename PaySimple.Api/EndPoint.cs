using System;
using System.Linq;
using System.Collections.Generic;

using PaySimple.Api.Types;

namespace PaySimple.Api
{
    public abstract class EndPoint<T> where T : class
    {
        public abstract string RawUri { get; }
        public abstract string Method { get; }

        Dictionary<string, object> _params = new Dictionary<string, object>();

        protected void SetValue(string name, object value)
        {
            _params[name] = value;
        }

        protected T GetValue<T>(string name)
        {
            T value;
            object objVal;
            if (_params.TryGetValue(name, out objVal))
                value = (T)objVal;
            else
                value = default(T);
            return value;
        }

        public void Validate()
        {
            // Nothing here yet.
        }

        static string TrimBrackets(string param)
        {
            return param.Replace("{", "").Replace("}", "");
        }

        public string FinalUri()
        {
            object val;
            var slugs = RawUri.Split('/');
            for (var i = 0; i < slugs.Length; ++i)
            {
                var paramLabel = TrimBrackets(slugs[i]);
                if (_params.TryGetValue(paramLabel, out val))
                    slugs[i] = string.Format("{0}", val);
            }
            return slugs.Aggregate((x, y) => x + "/" + y);
        }
    }
}
