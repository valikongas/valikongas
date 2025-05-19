using System.Text.Json.Serialization;

namespace API_Nr._4
{
    public class Current
    {

        public string observation_time { get; set; }

        public int Temperature { get; set; }

        public int weather_code { get; set; }

        public List<string> weather_icons { get; set; }

        public List<string> Wweather_descriptions { get; set; }

        public Astro Astro { get; set; }


        public AirQuality air_quality { get; set; }


        public int wind_speed { get; set; }


        public int wind_degree { get; set; }

        public string wind_dir { get; set; }

        public int Pressure { get; set; }
        public double precip { get; set; }
        public int Humidity { get; set; }
        public int Cloudcover { get; set; }
        public int Feelslike { get; set; }


        public int uv_index { get; set; }

        public int Visibility { get; set; }
        public Current()
        {
            
        }
    }
}
