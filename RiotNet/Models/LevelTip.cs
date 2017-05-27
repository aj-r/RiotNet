using System.ComponentModel.DataAnnotations.Schema;

namespace RiotNet.Models
{
    /// <summary>
    /// Explains what happens when levelling up an ability.
    /// </summary>
    [ComplexType]
    public class LevelTip
    {
        /// <summary>
        /// Gets or sets the effects that change for each rank of the ability.
        /// </summary>
        public ListOfString Effect { get; set; } = new ListOfString();

        /// <summary>
        /// Gets or sets the labels for the corresponding effects that change at each rank of the ability.
        /// </summary>
        public ListOfString Label { get; set; } = new ListOfString();
    }
}
