using System;
using System.Collections.Generic;
using Newtonsoft.Json.Converters;

namespace RiotNet.Converters
{
    /// <summary>
    /// Creates dictionaries with a case-insensitive key comparer for dictionaries with string keys and te specified type of values.
    /// </summary>
    /// <typeparam name="TValue">The type of values for the dictionary type that should have case-insensitive keys.</typeparam>
    public class CaseInsensitiveDictionaryCreationConverter<TValue> : CustomCreationConverter<Dictionary<string, TValue>>
    {
        /// <summary>
        /// Creates a new <see cref="CaseInsensitiveDictionaryCreationConverter{TValue}"/> instance.
        /// </summary>
        public CaseInsensitiveDictionaryCreationConverter()
        { }

        /// <summary>
        /// Determines whether this instance can convert the specified object type.
        /// </summary>
        /// <param name="objectType">The type to convert.</param>
        /// <returns><value>true</value> if this converter can convert the specified type; otherwise <value>false</value>.</returns>
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Dictionary<string, TValue>);
        }

        /// <summary>
        /// Creates a new instance of the object.
        /// </summary>
        /// <param name="objectType">The type to create.</param>
        /// <returns>The dictionary that was created.</returns>
        public override Dictionary<string, TValue> Create(Type objectType)
        {
            return new Dictionary<string, TValue>(StringComparer.OrdinalIgnoreCase);
        }
    }
}
