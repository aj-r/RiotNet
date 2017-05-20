namespace RiotNet.Models
{
    /// <summary>
    /// Contains observer information (for spectator).
    /// </summary>
    public class Observer
    {
        /// <summary>
        ///  Gets or sets the key used to decrypt the spectator grid game data for playback.
        /// </summary>
        public string EncryptionKey { get; set; }
    }
}
