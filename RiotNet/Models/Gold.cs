using System.ComponentModel.DataAnnotations.Schema;

namespace RiotNet.Models
{
    /// <summary>
    /// Contains purchase information for an item.
    /// </summary>
    [ComplexType]
    public class Gold
    {
        /// <summary>
        /// Gets or sets the cost of the item excluding the cost of its recipe.
        /// </summary>
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
        /// Gets or sets the total cost of the item including the cost of its recipe.
        /// </summary>
        public int Total { get; set; }
    }
}
