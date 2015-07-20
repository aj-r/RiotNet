using System.ComponentModel.DataAnnotations;

namespace RiotNet.Models
{
    /// <summary>
    /// Represents a summoner spell.
    /// </summary>
    public class StaticSummonerSpell : StaticSpell
    {
        /// <summary>
        /// Creates a new <see cref="StaticSummonerSpell"/> instance.
        /// </summary>
        public StaticSummonerSpell()
        {
            Modes = new ListOfString();
        }

        /// <summary>
        /// Gets or sets the summoner spell ID.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the list of game modes in which the current summoner spell is allowed.
        /// </summary>
        public ListOfString Modes { get; set; }

        /// <summary>
        /// Gets or sets the summoner level required to use this spell.
        /// </summary>
        public int SummonerLevel { get; set; }
    }
}
