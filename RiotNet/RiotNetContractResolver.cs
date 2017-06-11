using System;
using Newtonsoft.Json.Serialization;

namespace RiotNet
{
    /// <summary>
    /// The default Json.Net contract resolver used by the <see cref="RiotClient"/>.
    /// </summary>
    public class RiotNetContractResolver : CamelCasePropertyNamesContractResolver
    {
        /// <summary>
        /// Creates a <see cref="JsonDynamicContract"/> for the given type.
        /// </summary>
        /// <param name="objectType">The type of the object.</param>
        /// <returns>A <see cref="JsonDynamicContract"/>.</returns>
        protected override JsonDictionaryContract CreateDictionaryContract(Type objectType)
        {
            var contract = base.CreateDictionaryContract(objectType);
            // The default behaviour of the CamelCasePropertyNamesContractResolver is to also convert dictionary keys to uppercase.
            // However, this is bad because the reverse operation is not applied during serialization.
            // It's also just not what we want.
            contract.DictionaryKeyResolver = s => s;
            return contract;
        }
    }
}
