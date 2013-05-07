using System;
using System.Collections.Generic;

using CsQuery;
using CsQuery.Implementation;

namespace PaySimple.Parser
{
    public abstract class ReaderBase<T>
    {
        static readonly string ApiUrl = "https://api.paysimple.com";
        static readonly string HelpSlug = "/v4/Help/";

        readonly string _tocSlug;
        readonly string _tocItems;

        protected abstract void LoadItem(HtmlAnchorElement link, CQ document);

        public ReaderBase(string tocSlug, string tocItemSelector)
        {
            _tocSlug = tocSlug;
            _tocItems = tocItemSelector;
        }

        public Dictionary<string, T> Items
        {
            get;
            private set;
        }

        public void Read()
        {
            var seed = ApiUrl + HelpSlug + _tocSlug;
            var toc = CQ.CreateFromUrl(seed);
            var links = toc[_tocItems];

            Items = new Dictionary<string, T>();
            foreach (HtmlAnchorElement l in links)
            {
                var doc = CQ.CreateFromUrl(ApiUrl + l.Href);
                LoadItem(l, doc);
            }
        }
    }
}
