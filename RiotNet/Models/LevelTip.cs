using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace RiotNet.Models
{
    /// <summary>
    /// Explains what happens when levelling up an ability.
    /// </summary>
    [ComplexType]
    public class LevelTip
    {
        /// <summary>
        /// Creates a new <see cref="LevelTip"/> instance.
        /// </summary>
        public LevelTip()
        {
            Effect = new ListOfString();
            Label = new ListOfString();
        }

        /// <summary>
        /// Gets or sets the effects that change for each rank of the ability.
        /// </summary>
        public ListOfString Effect { get; set; }

        /// <summary>
        /// Gets or sets the labels for the corresponding effects that change at each rank of the ability.
        /// </summary>
        public ListOfString Label { get; set; }
    }
}
