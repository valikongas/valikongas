using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_lygio_8_pamoka_Generic
{
    internal class Soccer:Comand
    {

        public Soccer()
        {
            
        }
        public Soccer(string name, int stadionCapacity, int playerCount, string sportType)
        {
            Name = name;
            StadionCapacity = stadionCapacity;
            PlayerCount = playerCount;
            SportType = sportType;
        }

        public void SoccerPrint(List<Soccer> list)
        {
            foreach (Soccer s in list)
            {
                Console.WriteLine(s.Name);
            }
        }


    }
}
