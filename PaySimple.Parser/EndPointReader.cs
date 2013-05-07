using System;
using System.Linq;
using System.Collections.Generic;

using CsQuery;
using CsQuery.Implementation;

namespace PaySimple.Parser
{
    public class EndPointDesc
    {
        public string Description;
        public string Method;
        public string Uri;
    }

    public class EndPointReader : ReaderBase<List<EndPointDesc>>
    {
        static readonly string Description = "description";
        static readonly string Method = "method";
        static readonly string Uri = "uri";

        public static EndPointReader _this;
        public static EndPointReader Current
        {
            get
            {
                if (_this == null)
                {
                    _this = new EndPointReader();
                    _this.Read();
                }
                return _this;
            }
        }

        public EndPointReader() : base(
            "Reference",
            "#dash-wrapper section h2 a:not([href*=#]), " +
                "#dash-wrapper section h3 a:not([href*=#])")
        {
        }

        protected override void LoadItem(HtmlAnchorElement link, CsQuery.CQ document)
        {
            var routeTable = document["#routeTable"];

            // Create the route attribute lookup and validate.
            var header = routeTable["th"];
            var atts = new[] { Description, Method, Uri };
            var indices = header
                .Select((x, i) =>
                {
                    var attr = x.InnerHTML.Trim().ToLower();
                    return new
                    {
                        Idx = i,
                        Name = atts.SingleOrDefault(y => y == attr)
                    };
                })
                .ToDictionary(x => x.Name, x => x.Idx);
            if (indices.Count != atts.Length)
                throw new Exception("Not all route attributes were found.");

            var routes = routeTable["tbody tr"];

            var endpoints = routes
                .Select(x =>
                {
                    var tds = x.ChildElements;
                    return new EndPointDesc
                    {
                        Description = GetRouteAttr(tds, indices[Description]),
                        Method = GetRouteAttr(tds, indices[Method]),
                        Uri = GetRouteAttr(tds, indices[Uri])
                    };
                })
                .ToList();

            Items.Add(link.InnerText, endpoints);
        }

        static string GetRouteAttr(
            IEnumerable<IDomElement> routeRow, int column)
        {
            var td = routeRow.ElementAt(column);
            var dom = InnerMost(td);
            return dom.InnerText.Trim();
        }

        static IDomObject InnerMost(IDomObject domObj)
        {
            IDomObject child;
            var last = domObj.Cq();
            while ((child = last.Children().FirstElement()) != null)
                last = child.Cq();
            return last[0];
        }
    }
}
