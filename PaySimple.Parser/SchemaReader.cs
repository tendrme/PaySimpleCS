using System;
using System.Linq;
using System.Collections.Generic;

using NUnit.Framework;

using CsQuery;
using CsQuery.Implementation;

namespace PaySimple.Parser
{
    public class Schema
    {
        public string Description;
        public string Name;
        public string Type;
        public string InheritedType;
        public bool IsEnum;
        public bool IsRequired;
        public List<Schema> Properties;
    }

    public class SchemaReader : ReaderBase<Schema>
    {
        const string Request = "Request";
        const string Response = "Response";

        public static SchemaReader _this;
        public static SchemaReader Current
        {
            get
            {
                if (_this == null)
                {
                    _this = new SchemaReader();
                    _this.Read();
                }
                return _this;
            }
        }

        public SchemaReader() : base("Schemas", "#body ul a")
        {
        }

        protected override void LoadItem(HtmlAnchorElement link, CQ document)
        {
            var schemaJson = document["#schema textarea"].Html();
            var schemaObj =
                (object)SimpleJson.DeserializeObject<dynamic>(schemaJson);
            var schema = Parse.ToDict(schemaObj);
            LoadTypes((string)schema["name"], schema, null);
        }

        static readonly string[] _pluralEnds = new[] { "es", "s" };
        static string TrimPlural(string value)
        {
            var end = _pluralEnds.FirstOrDefault(x => value.EndsWith(x));
            if (end != null)
                value = value.Substring(0, value.Length - end.Length);
            return value;
        }

        void LoadTypes(string name, IDictionary<string, object> properties, Schema parent)
        {
            var required = false;
            Parse.As(properties, "required", out required);

            JsonArray enumItems;
            var isEnum = Parse.As(properties, "options", out enumItems);

            string desc;
            Parse.As(properties, "description", out desc);

            string type;
            if (Parse.As<string>(properties, "type", out type))
            {
                var isArray = type == "array";
                if (type == "object" || isArray || isEnum)
                {
                    Schema schema;
                    var apiType = name;
                    var inheritedType = default(string);
                    if (apiType.EndsWith(Request))
                        apiType = apiType.Substring(
                            0, apiType.Length - Request.Length);
                    else if (apiType.EndsWith(Response))
                        inheritedType = apiType.Substring(
                            0, apiType.Length - Response.Length);
                    
                    if (isArray)
                        apiType = TrimPlural(apiType);

                    if (!Items.TryGetValue(apiType, out schema))
                    {
                        schema = new Schema
                        {
                            Description = desc,
                            InheritedType = inheritedType,
                            IsEnum = isEnum,
                            IsRequired = Parse.IsRequired(required),
                            Name = name,
                            Type = apiType + (isArray ? "[]" : ""),
                            Properties = new List<Schema>()
                        };
                        Items.Add(apiType, schema);

                        if (isArray)
                            properties = Parse.ToDict(properties["items"]);

                        if (isEnum)
                            foreach (JsonObject i in enumItems)
                            {
                                object desc2;
                                i.TryGetValue("description", out desc2);
                                schema.Properties.Add(new Schema
                                {
                                    Description = desc2 as string,
                                    Name = (string)i["label"],
                                    Type = i["value"].ToString()
                                });
                            }

                        if (!isEnum)
                        {
                            var props = Parse.ToDict(properties["properties"]);

                            List<string> inheritedProps;
                            Schema inheritedSchema;
                            if (schema.InheritedType != null &&
                                Items.TryGetValue(
                                    schema.InheritedType, out inheritedSchema))
                                inheritedProps = inheritedSchema
                                    .Properties.Select(x => x.Name).ToList();
                            else
                                inheritedProps = new List<string>();

                            foreach (var p in props)
                            {
                                if (inheritedProps.Contains(p.Key))
                                    continue;
                                LoadTypes(p.Key, Parse.ToDict(p.Value), schema);
                            }
                        }
                    }
                    else
                    {
                        schema = new Schema
                        {
                            IsRequired = Parse.IsRequired(required),
                            Name = name,
                            Properties = schema.Properties,
                            Type = schema.Type
                        };
                    }

                    if (parent != null)
                        parent.Properties.Add(schema);
                }
                else
                {
                    var schema = new Schema
                    {
                        IsRequired = Parse.IsRequired(required),
                        Name = name,
                        Type = Parse.NativeType(type)
                    };
                    parent.Properties.Add(schema);
                }
            }
        }
    }
}
