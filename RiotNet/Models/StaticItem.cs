namespace RiotNet.Models
{
    /// <summary>
    /// Represents an item that a player can use during a match.
    /// </summary>
    public class StaticItem : BasicData
    {
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
        public int Depth { get; set; } = 1;

        /// <summary>
        /// Gets or sets the effect of the item.
        /// </summary>
        public DictionaryOfString Effect { get; set; } = new DictionaryOfString();

        /// <summary>
        /// Gets or sets the list of items that this item builds out of.
        /// </summary>
        public ListOfInt From { get; set; } = new ListOfInt();

        /// <summary>
        /// Gold cost information for the item. Does not apply to runes.
        /// </summary>
        public Gold Gold { get; set; } = new Gold();

        /// <summary>
        /// Gets or sets whether the item is hidden when searching. This is usually used for enchantments (such as homeguard).
        /// </summary>
        public bool HideFromAll { get; set; }

        /// <summary>
        /// Gets or sets whether the item exists in the store.
        /// </summary>
        public bool InStore { get; set; } = true;

        /// <summary>
        /// Gets or sets the list of items that this item can build into.
        /// </summary>
        public ListOfInt Into { get; set; } = new ListOfInt();

        /// <summary>
        /// Gets or sets the ID of the item that this item builds from using a special rule (e.g. Archangel's Staff into Seraph's Embrace).
        /// </summary>
        public int SpecialRecipe { get; set; }

        /// <summary>
        /// Gets or sets the stats that the item applies.
        /// </summary>
        public BasicDataStats Stats { get; set; } = new BasicDataStats();
    }
}
