using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_lygio_8_pamoka_Generic
{
    internal class Comand
    {
        public string Name { get; set; }
        public  int StadionCapacity { get; set; }
        public int PlayerCount { get; set; }

        public string SportType { get; set; }

        public Comand()
        {
            
        }

        public Comand(string name, int stadionCapacity, int playerCount, string sportType)
        {
            Name = name;
            StadionCapacity = stadionCapacity;
            PlayerCount = playerCount;
            SportType = sportType;
        }
        
    }
}
