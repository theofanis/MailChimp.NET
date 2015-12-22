using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailChimp
{
    class SingleArrayValueConverter<T> : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            object retVal = new Object();
            if (reader.TokenType == JsonToken.StartObject)
            {
                retVal = (T)serializer.Deserialize(reader, typeof(T));
            }
            else if (reader.TokenType == JsonToken.StartArray)
            {
                // Let the reader deserialize to go past the empty array
                // And return null since we are expecting an object
                // But the response is malformed and contained and empty array
                var res = serializer.Deserialize(reader, typeof(T[]));
                retVal = null;
            }
            return retVal;
        }

        public override bool CanConvert(Type objectType)
        {
            return false;
        }
    }
}
