using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;

namespace AADx.Common.Models
{
    public class UserProfile
    {
        public long Id { get; set; }
        
        public Guid OID { get; set; }
        
        public string UPN { get; set; }
        
        public string Name { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public TeamType Team { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public FactionType Faction { get; set; }
    }
}
