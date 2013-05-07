using System;

namespace PaySimple.Api
{
    public abstract class ContentEndPoint<T> : EndPoint<T> where T : class
    {
        public T Content
        {
            get { return GetValue<T>("content"); }
            set { SetValue("content", value); }
        }
    }
}
