using System.Collections.ObjectModel;
using System.Globalization;

namespace RiotNet.Models
{
    /// <summary>
    /// A collection of <see cref="MatchParticipantFrame"/>, mapped by participant ID.
    /// </summary>
    public class MatchParticipantFrameCollection : KeyedCollection<string, MatchParticipantFrame>
    {
        /// <summary>
        /// Gets the key for an item.
        /// </summary>
        /// <param name="item">The item to get the key from.</param>
        /// <returns>The key.</returns>
        protected override string GetKeyForItem(MatchParticipantFrame item)
        {
            return item.ParticipantId.ToString(CultureInfo.InvariantCulture);
        }
    }
}
