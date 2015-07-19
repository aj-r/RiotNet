using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RiotNet.Models
{
    /// <summary>
    /// This object contains game timeline information.
    /// </summary>
    public class Timeline
    {
        /// <summary>
        /// Gets or sets time between each returned frame in milliseconds.
        /// </summary>
        public long FrameInterval { get; set; }

        /// <summary>
        /// Gets or sets list of timeline frames for the game.
        /// </summary>
        public List<Frame> Frames { get; set; }
    }
}
