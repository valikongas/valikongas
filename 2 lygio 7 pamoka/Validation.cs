using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_lygio_7_pamoka
{
    internal static class Validation <T>
    {
public static void ValidationMetod(T name)
        {
            if (name == null)
                throw new ArgumentNullException("name");
            else
                Console.WriteLine("Viskas pavyko");

        }
    }
}
