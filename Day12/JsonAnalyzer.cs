using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Day12
{
    public class JsonAnalyzer
    {
        private List<long> values = new List<long>();

        public List<long> CountIntegers(string input, bool ignoreRed = false)
        {
            values.Clear();

            values = new List<long>();

            IEnumerable<JToken> data = FetchJsonObject(input);

            ParseChildren(data, ignoreRed);

            return values;
        }

        private IEnumerable<JToken> FetchJsonObject(string input)
        {
            try
            {
                return JArray.Parse(input).ToList<JToken>();
            }
            catch(JsonReaderException)
            {
                try
                {
                    return JObject.Parse(input).ToList<JToken>();
                }
                catch(JsonReaderException)
                {
                    throw new NotSupportedException("Invalid data");
                }
            }
        }

        private void ParseChildren(IEnumerable<JToken> data, bool ignoreRed)
        {
            if(ignoreRed)
            {
                // Yea, I know... This is just ridiculous!
                // However that seems to be the appropiate way to extract strings
                // from JSON when working with anonymously types in Json.NET
                if(data.First().Parent.Type == JTokenType.Object)
                    foreach(var objectProperties in data)
                        if(objectProperties.Type == JTokenType.Property)
                            foreach(var propertyElement in objectProperties.Value<JProperty>())
                                if(propertyElement.Type == JTokenType.String)
                                    if(propertyElement.Value<string>() == "red")
                                        return;
            }

            foreach(JToken item in data)
            {
                if(item.Type == JTokenType.Integer)
                {
                    values.Add(item.Value<long>());
                }

                if(item.HasValues)
                {
                    ParseChildren(item.Children(), ignoreRed);
                }
            }
        }
    }
}