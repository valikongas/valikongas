using System.Text.Json.Serialization;

namespace API_Nr._4
{
    public class Location
    {

        public string Name { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public string Lat { get; set; }
        public string Lon { get; set; }

        [JsonPropertyName("timezone_id")]
        public string TimezoneId { get; set; }

        public string Localtime { get; set; }

        [JsonPropertyName("localtime_epoch")]
        public long LocaltimeEpoch { get; set; }

        [JsonPropertyName("utc_offset")]
        public string UtcOffset { get; set; }

    }
}
