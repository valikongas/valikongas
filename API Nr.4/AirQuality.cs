using System.Text.Json.Serialization;

namespace API_Nr._4
{
    public class AirQuality
    {

        public string co { get; set; }

        public string no2 { get; set; }


        public string o3 { get; set; }

        public string so2 { get; set; }


        public string pm2_5 { get; set; }


        public string pm10 { get; set; }

        [JsonPropertyName("us-epa-index")]
        public string UsEpaIndex { get; set; }

        [JsonPropertyName("gb-defra-index")]
        public string GbDefraIndex { get; set; }

    }
}
