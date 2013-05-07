using System;

namespace PaySimple.Parser
{
    public static class StringEx
    {
        public static bool IsPlural(this string value)
        {
            return value.EndsWith("s");
        }
    }
}
