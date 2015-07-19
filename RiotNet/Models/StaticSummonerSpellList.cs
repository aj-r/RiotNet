using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RiotNet.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class StaticSummonerSpellList : StaticDataList
    {
        /// <summary>
        /// Gets or sets the summoner spells, indexed by name.
        /// </summary>
        public Dictionary<string, StaticSummonerSpell> Data { get; set; }
    }
}
