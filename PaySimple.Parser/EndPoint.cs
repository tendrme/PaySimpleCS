using System;
using System.Net;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace PaySimple.Parser
{
    // IMPORTANT
    // It's assumed that the URI for the endpoints look like:
    // /vX/objectType/stuff
    // where an example might be /v4/customer/{customerId}
    // If the URI format changes then this class must change.

    public class EndPoint
    {
        public class Param
        {
            public string Name { get; set; }
            public string Type { get; set; }
        }

        static readonly Regex ParamRegex = new Regex(@"\{[^{}]+\}");
        static readonly Regex QStringParamRegex = new Regex(@"[a-zA-Z0-9]+\=");

        readonly string[] _slugs;
        readonly string _path;
        readonly string _qstring;

        public EndPoint(EndPointDesc desc)
        {
            Descriptor = desc;

            int i;
            IEnumerable<string> qstringParams;
            if ((i = Descriptor.Uri.IndexOf('?')) > -1)
            {
                _path = desc.Uri.Substring(0, i);
                _qstring = desc.Uri.Substring(i + 1);
                qstringParams = QStringParamRegex
                    .Matches(_qstring)
                    .OfType<Match>()
                    .Select(x => x.Value.Substring(0, x.Value.Length - 1));
            }
            else
            {
                _path = desc.Uri;
                qstringParams = new string[0];
            }

            _slugs = _path.Split('/');

            Parameters = ParamRegex
                .Matches(_path)
                .OfType<Match>()
                .Select(x => TrimBrackets(x.Value))
                .Concat(qstringParams)
                .Select(x => new Param { Name = x, Type = "string" })
                .ToList();

            SubmitsContent =
                Parameters.Count == 0 &&
                (desc.Method == WebRequestMethods.Http.Post ||
                desc.Method == WebRequestMethods.Http.Put);
        }

        public bool SubmitsContent { get; private set; }

        public EndPointDesc Descriptor
        {
            get;
            private set;
        }

        public List<Param> Parameters
        {
            get;
            private set;
        }

        bool IsParam(string item)
        {
            return Parameters.Any(x =>
                item.StartsWith("{") &&
                item.EndsWith("}") &&
                x.Name == TrimBrackets(item));
        }

        public string TypeName
        {
            get { return UppercaseFirst(_slugs[2]); }
        }

        public string ReturnTypeName
        {
            get
            {
                var type = default(string);
                switch (Descriptor.Method)
                {
                    case WebRequestMethods.Http.Get:
                    case WebRequestMethods.Http.Post:
                    case WebRequestMethods.Http.Put:
                        type = ReturnTypeForEdit();
                        break;

                    case "DELETE":
                        type = "GenericResponse";
                        break;
                }

                return type ?? "";
            }
        }

        string ReturnTypeForEdit()
        {
            var type = _slugs
                .Reverse()
                .Where(x => !IsParam(x))
                .FirstOrDefault();

            var isArray = false;
            if (!string.IsNullOrEmpty(type))
            {
                var overRide = new EndPointTypeOverrides().GetOverride(
                    type, Descriptor.Uri);
                if (overRide != null)
                {
                    isArray = type.IsPlural();
                    type = overRide;
                }
                else
                {
                    bool isPlural;
                    var existing =
                        Parse.MatchClosestTypeName(type, out isPlural);
                    if (existing != "")
                    {
                        type = existing;
                        if (isPlural)
                            isArray = true;
                    }
                }
            }

            if (isArray || FriendlyName.StartsWith("GetAll"))
                type += "[]";

            return type;
        }

        public string FriendlyName
        {
            get
            {
                var prefix = MethodPrefix(Descriptor.Method);

                var totalKept = 0;
                var postfix = new StringBuilder();
                if (_slugs.Length > 2)
                    foreach (var s in _slugs.Skip(2).Where(x => !IsParam(x)))
                    {
                        bool isPlural;
                        var added = false;
                        var existing =
                            Parse.MatchClosestTypeName(s, out isPlural);
                        if (existing != null)
                        {
                            if (existing.Length == s.Length ||
                                (isPlural && existing.Length + 1 == s.Length))
                            {
                                postfix.Append(existing);
                                if (isPlural)
                                    postfix.Append("s");
                                added = true;
                            }
                        }

                        if (!added)
                            postfix.Append(UppercaseFirst(s));

                        ++totalKept;
                    }

                var isGetAll =
                    Descriptor.Method == WebRequestMethods.Http.Get &&
                    totalKept == 1 &&
                    !Parameters.Any();

                // Pluralize when it's a "GetAll".
                if (isGetAll)
                {
                    postfix.Append("s");
                    prefix += "All";
                }

                var friendly = prefix + postfix.ToString();

                // String off querystring stuff.
                int i;
                if ((i = friendly.IndexOf('?')) > -1)
                    friendly = friendly.Substring(0, i);

                return friendly;
            }
        }

        static string UppercaseFirst(string s)
        {
            var chars = s.ToCharArray();
            chars[0] = char.ToUpper(chars[0]);
            return new string(chars);
        }

        static string TrimBrackets(string param)
        {
            return param.Replace("{", "").Replace("}", "");
        }

        static string MethodPrefix(string verb)
        {
            var prefix = default(string);
            switch (verb)
            {
                case WebRequestMethods.Http.Get:
                    prefix = "Get";
                    break;

                case WebRequestMethods.Http.Post:
                    prefix = "New";
                    break;

                case WebRequestMethods.Http.Put:
                    prefix = "Update";
                    break;

                case "DELETE":
                    prefix = "Delete";
                    break;
            }
            return prefix;
        }
    }
}
