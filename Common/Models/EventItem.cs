using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AADx.Common.Models
{
    public class EventItem
    {
        public long Id { get; set; }

        public string Description { get; set; }

        public string Owner { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public TeamType Team { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public FactionType Faction { get; set; }
    }
}
