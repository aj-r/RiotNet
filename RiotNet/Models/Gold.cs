namespace RiotNet.Models
{
    /// <summary>
    /// Contains purchase information for an item.
    /// </summary>
    public class Gold
    {
        public int Base { get; set; }

        /// <summary>
        /// Gets or sets whether the item can be purchased.
        /// </summary>
        public bool Purchasable { get; set; }

        /// <summary>
        /// Gets or sets the sell price of the item.
        /// </summary>
        public int Sell { get; set; }

        /// <summary>
        /// Gets or sets the total cost of the item.
        /// </summary>
        public int Total { get; set; }
    }
}
