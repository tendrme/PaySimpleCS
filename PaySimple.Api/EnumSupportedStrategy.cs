using System;

namespace PaySimple.Api
{
    public class EnumSupportedStrategy : PocoJsonSerializerStrategy
    {
        public override object DeserializeObject(object value, Type type)
        {
            object obj;
            if (type.IsEnum && value is string)
                obj = Enum.Parse(type, (string)value);
            else
                obj = base.DeserializeObject(value, type);
            return obj;
        }
    }
}
