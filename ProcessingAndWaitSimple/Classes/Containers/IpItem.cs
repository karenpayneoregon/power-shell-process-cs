using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ProcessingAndWait.Classes.Containers
{
    public class IpItem
    {
        [JsonProperty("ip")]
        public string Ip { get; set; }
        [JsonProperty("city")]
        public string City { get; set; }
        [JsonProperty("country")]
        public string Country { get; set; }
        [JsonProperty("loc")]
        public string Location { get; set; }
        [JsonProperty("org")]
        public string Org { get; set; }
        [JsonProperty("region")]
        public string Region { get; set; }
        [JsonProperty("postal")]
        public string Postal { get; set; }
        [JsonProperty("timezone")]
        public string Timezone { get; set; }
        [JsonProperty("readme")]
        public string Readme { get; set; }

        public string Details => $"IP:{Ip}\nRegion: {Region}\nCountry: {Country}";
    }
}
