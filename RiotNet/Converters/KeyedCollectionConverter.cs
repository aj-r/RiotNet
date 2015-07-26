using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RiotNet.Converters
{
    /// <summary>
    /// Reads and writes KeyedCollections as JSON objects instead of arrays.
    /// Any KeyedCollection deserialized by this converter must have a parameterless constructor.
    /// </summary>
    public class KeyedCollectionConverter : JsonConverter
    {
        /// <summary>
        /// Determines whether this instance can convert the specified object type.
        /// </summary>
        /// <param name="objectType">The type to convert.</param>
        /// <returns><value>true</value> if this converter can convert the specified type; otherwise <value>false</value>.</returns>
        public override bool CanConvert(Type objectType)
        {
            return ReflectionUtils.IsSubclassOfGenericTypeDefinition(objectType, typeof(KeyedCollection<,>));
        }

        /// <summary>
        /// Reads the KeyedCollection as a JSON object.
        /// </summary>
        /// <param name="reader">The <see cref="JsonReader"/> to read from.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="existingValue">The existing value of object being read.</param>
        /// <param name="serializer">The calling serializer.</param>
        /// <returns>The object value.</returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var obj = JObject.Load(reader);
            var collection = (IList)Activator.CreateInstance(objectType);
            var collectionType = ReflectionUtils.GetListInterface(objectType);
            var itemType = collectionType.GetGenericArguments().First();
            foreach (var property in obj.Properties())
            {
                var item = property.Value.ToObject(itemType);
                collection.Add(item);
            }
            return collection;
        }

        /// <summary>
        /// Writes the KeyedCollection as a JSON object.
        /// </summary>
        /// <param name="writer">The <see cref="JsonWriter"/> to write to.</param>
        /// <param name="value">The date to write.</param>
        /// <param name="serializer">The calling serializer.</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var collection = value as IList;
            writer.WriteStartObject();
            var objectType = value.GetType();
            var collectionType = ReflectionUtils.GetListInterface(objectType);
            var itemType = collectionType.GetGenericArguments().First();
            var getKeyMethod = objectType.GetMethod("GetKeyForItem", BindingFlags.NonPublic | BindingFlags.Instance, null, new[] { itemType }, null);
            foreach (var item in collection)
            {
                var key = getKeyMethod.Invoke(value, new object[] { item });
                if (key == null)
                    continue;
                writer.WritePropertyName(key.ToString());
                serializer.Serialize(writer, item);
            }
            writer.WriteEndObject();
        }
    }
}
