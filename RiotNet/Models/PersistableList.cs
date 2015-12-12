using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using Newtonsoft.Json;

namespace RiotNet.Models
{
    /// <summary>
    /// Allows persisting of scalar values as a collection.
    /// </summary>
    /// <typeparam name="T">The type of elements in the list.</typeparam>
    [ComplexType]
    public class PersistableList<T> : List<T>
    {
        /// <summary>
        /// Gets or sets the serialized form of the list. This is used for saving the list into a database. This property is not intended to be used by your code.
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
                    AddRange(serializer.Deserialize<List<T>>(jsonReader));
                }
            }
        }

        /// <summary>
        /// Gets or sets the total number of elements the internal data structure can hold without resizing.
        /// </summary>
        [NotMapped]
        public new int Capacity
        {
            get { return base.Capacity; }
            set { base.Capacity = value; }
        }
    }

    /// <summary>
    /// A list of strings that can be stored in a database.
    /// </summary>
    public class ListOfString : PersistableList<string>
    { }

    /// <summary>
    /// A list of integers that can be stored in a database.
    /// </summary>
    public class ListOfInt : PersistableList<int>
    { }

    /// <summary>
    /// A list of long integers that can be stored in a database.
    /// </summary>
    public class ListOfLong : PersistableList<long>
    { }

    /// <summary>
    /// A list of doubles that can be stored in a database.
    /// </summary>
    public class ListOfDouble : PersistableList<double>
    { }

    /// <summary>
    /// A 2-dimensional list of doubles that can be stored in a database.
    /// </summary>
    public class ListOfListOfDouble : PersistableList<List<double>>
    { }
}
