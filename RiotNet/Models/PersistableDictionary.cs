using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using Newtonsoft.Json;

namespace RiotNet.Models
{
    /// <summary>
    /// Allows persisting of scalar values in a dictionary.
    /// </summary>
    /// <typeparam name="TKey">The type of keys in the dictionary.</typeparam>
    /// <typeparam name="TValue">The type of values in the dictionary.</typeparam>
    [ComplexType]
    public class PersistableDictionary<TKey, TValue> : Dictionary<TKey, TValue>
    {
        /// <summary>
        /// Gets or sets the serialized form of the dictionary. This is used for saving the dictionary into a database. This property is not intended to be used by your code.
        /// </summary>      
        [JsonIgnore]   
        public string Value
        {
            get
            {
                using (var writer = new StringWriter())
                using (var jsonWriter = new JsonTextWriter(writer))
                {
                    var serializer = JsonSerializer.Create();
                    serializer.Serialize(jsonWriter, this);
                    return writer.ToString();
                }
            }
            set
            {
                Clear();
                if (string.IsNullOrEmpty(value))
                    return;
                using (var reader = new StringReader(value))
                using (var jsonReader = new JsonTextReader(reader))
                {
                    var serializer = JsonSerializer.Create();
                    var dictionary = serializer.Deserialize<Dictionary<TKey, TValue>>(jsonReader);
                    foreach (var kvp in dictionary)
                        Add(kvp.Key, kvp.Value);
                }
            }
        }
    }

    /// <summary>
    /// A dictionary with string keys and boolean values that can be stored in a database.
    /// </summary>
    public class DictionaryOfBoolean : PersistableDictionary<string, bool>
    { }

    /// <summary>
    /// A dictionary with string keys and string values that can be stored in a database.
    /// </summary>
    public class DictionaryOfString : PersistableDictionary<string, string>
    { }
}
