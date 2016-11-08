using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RiotNet.Models;

namespace RiotNet.Converters
{
    /// <summary>
    /// Converts a <see cref="GameSubType"/> in JSON to a consistent CLR format.
    /// </summary>
    public class GameSubTypeConverter : JsonConverter
    {
        /// <summary>
        /// Determines whether this instance can convert the specified object type.
        /// </summary>
        /// <param name="objectType">The type to convert.</param>
        /// <returns><value>true</value> if this converter can convert the specified type; otherwise <value>false</value>.</returns>
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(GameSubType) || objectType == typeof(GameSubType?);
        }

        /// <summary>
        /// Reads the JSON representation of the GameSubType.
        /// </summary>
        /// <param name="reader">The <see cref="JsonReader"/> to read from.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <param name="existingValue">The existing value of object being read.</param>
        /// <param name="serializer">The calling serializer.</param>
        /// <returns>The object value.</returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.Null:
                    return null;
                case JsonToken.String:
                    GameSubType t;
                    var stringValue = (string)reader.Value;
                    if (Enum.TryParse(stringValue, true, out t))
                        return t;
                    // The stats API uses the same values for this enum but with slightly different names. Map those names here.
                    switch (stringValue)
                    {
                        case "AramUnranked5x5":
                            return GameSubType.ARAM_UNRANKED_5x5;
                        case "Ascension":
                            return GameSubType.ASCENSION;
                        case "CAP5x5":
                            return GameSubType.CAP_5x5;
                        case "CoopVsAI":
                            return GameSubType.BOT;
                        case "CoopVsAI3x3":
                            return GameSubType.BOT_3x3;
                        case "CounterPick":
                            return GameSubType.COUNTER_PICK;
                        case "FirstBlood1x1":
                            return GameSubType.FIRSTBLOOD_1x1;
                        case "FirstBlood2x2":
                            return GameSubType.FIRSTBLOOD_2x2;
                        case "Hexakill":
                            return GameSubType.HEXAKILL;
                        case "KingPoro":
                            return GameSubType.KING_PORO;
                        case "NightmareBot":
                            return GameSubType.NIGHTMARE_BOT;
                        case "OdinUnranked":
                            return GameSubType.ODIN_UNRANKED;
                        case "OneForAll5x5":
                            return GameSubType.ONEFORALL_5x5;
                        case "RankedPremade3x3":
                            return GameSubType.RANKED_PREMADE_3x3;
                        case "RankedPremade5x5":
                            return GameSubType.RANKED_PREMADE_5x5;
                        case "RankedSolo5x5":
                            return GameSubType.RANKED_SOLO_5x5;
                        case "RankedTeam3x3":
                            return GameSubType.RANKED_TEAM_3x3;
                        case "RankedTeam5x5":
                            return GameSubType.RANKED_TEAM_5x5;
                        case "SummonersRift6x6":
                            return GameSubType.SR_6x6;
                        case "Unranked":
                            return GameSubType.NORMAL;
                        case "Unranked3x3":
                            return GameSubType.NORMAL_3x3;
                        case "URF":
                            return GameSubType.URF;
                        case "URFBots":
                            return GameSubType.URF_BOT;
                        case "Bilgewater":
                            return GameSubType.BILGEWATER;
                        case "Siege":
                            return GameSubType.SIEGE;
                        default:
                            return -1;
                    }
                default:
                    throw new JsonException($"Unexpected token reading GameSubType. Expected String, but got {reader.TokenType}. Path: {reader.Path}");
            }
        }

        /// <summary>
        /// Writes the JSON representation of the GameSubType.
        /// </summary>
        /// <param name="writer">The <see cref="JsonWriter"/> to write to.</param>
        /// <param name="value">The date to write.</param>
        /// <param name="serializer">The calling serializer.</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var playerPosition = value as GameSubType?;
            if (playerPosition == null)
            {
                writer.WriteNull();
            }
            else
            {
                writer.WriteValue(playerPosition.Value.ToString());
            }
        }
    }
}
