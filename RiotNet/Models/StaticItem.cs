using System.Collections.Generic;

namespace RiotNet.Models
{
    /// <summary>
    /// Represents an item that a player can use during a match.
    /// </summary>
    public class StaticItem : BasicData
    {
        /// <summary>
        /// Creates a new <see cref="StaticItem"/> instance.
        /// </summary>
        public StaticItem()
        {
            // Note: default values are defined in the "basic" property of an ItemList or RuneList.
            Depth = 1;
            From = new ListOfInt();
            Gold = new Gold();
            InStore = true;
            Into = new ListOfInt();
        }

        /// <summary>
        /// Gets or sets whether the item should automatically be consumed upon purchase if the player's item slots are full.
        /// </summary>
        public bool ConsumeOnFull { get; set; }

        /// <summary>
        /// Gets or sets whether the item is consumable.
        /// </summary>
        public bool Consumed { get; set; }

        /// <summary>
        /// Gets or sets the depth of the recipe for this item.
        /// </summary>
        /// <remarks>
        /// An item's depth is equal to the maximum depth of the items that it builds out of, plus one.
        /// </remarks>
        public int Depth { get; set; }

        /// <summary>
        /// Gets or sets the effect of the item.
        /// </summary>
        public StringDictionary Effect { get; set; }

        /// <summary>
        /// Gets or sets the list of items that this item builds out of.
        /// </summary>
        public ListOfInt From { get; set; }

        /// <summary>
        /// Gold cost information for the item. Does not apply to runes.
        /// </summary>
        public Gold Gold { get; set; }

        /// <summary>
        /// Gets or sets whether the item is hidden when searching. This is usually used for enchantments (such as homeguard).
        /// </summary>
        public bool HideFromAll { get; set; }

        /// <summary>
        /// Gets or sets whether the item exists in the store.
        /// </summary>
        public bool InStore { get; set; }

        /// <summary>
        /// Gets or sets the list of items that this item can build into.
        /// </summary>
        public ListOfInt Into { get; set; }

        /// <summary>
        /// Gets or sets the ID of the item that this item builds from using a special rule (e.g. Archangel's Staff into Seraph's Embrace).
        /// </summary>
        public int SpecialRecipe { get; set; }

    }
}
