using System.Text.Json.Serialization;

namespace API_Nr._4
{
    public class Astro
    {
       
            public string Sunrise { get; set; }
            public string Sunset { get; set; }
            public string Moonrise { get; set; }
            public string Moonset { get; set; }

            public string moon_phase { get; set; }

            public int moon_illumination { get; set; }

        public Astro()
        {
            
        }

    }
}
