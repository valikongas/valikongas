using Microsoft.OpenApi.Services;

namespace API_Nr._4
{
    public class WheatherData 
    {
        public Request Request { get; set; }
        public Location Location{ get; set; }
        public Current Current { get; set; }
        public WheatherData()
        {
            
        }

        public WheatherData(Request request, Location location, Current curent)
        {
            Request = request;
            Location = location;
            Current = curent;
        }
    }

    
}
