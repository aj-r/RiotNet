namespace RiotNet.Models
{
    /// <summary>
    /// Contains summoner spell data.
    /// </summary>
    public class StaticSummonerSpellList : StaticDataList<StaticSummonerSpell>
    {
        /// <summary>
        /// Creates a new <see cref="StaticRuneList"/> instance.
        /// </summary>
        public StaticSummonerSpellList()
        {
            Type = "summoner";
        }
    }
}
