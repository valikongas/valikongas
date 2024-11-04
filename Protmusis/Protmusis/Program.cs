using System;
using System.ComponentModel.Design;
using System.Net.NetworkInformation;

namespace Protmusis
{
    internal class Program
    {
        static void Main(string[] args)
        {
     
            Protmusis();
        }
        private static void Protmusis()
        {
           Dictionary < string,int> playerList = new Dictionary<string,int> ();
           
            string currentUser = "";
            while (!PlayerConnect(playerList, out currentUser));
           
          
           GameMeniu(playerList, currentUser);




        }

        private static void GameMeniu(Dictionary<string,int> playerList,  string currentUser)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"       Zaidejas: {currentUser}");
                Console.WriteLine();
                Console.WriteLine("       MENIU");
                Console.WriteLine();
                Console.WriteLine("A - Atsijungti");
                Console.WriteLine("T - Zaidimo taisykles");
                Console.WriteLine("R - Zaidimo rezultattu ir daliuviu perziura");
                Console.WriteLine("Z - Zaisti");
                Console.WriteLine("Q - Iseiti is zaidimo");
                char x = ' ';
                bool isChar = false;
                while (!isChar)
                {
                    x = (char)Console.Read();
                    if (char.ToUpper(x) != 'A' && char.ToUpper(x) != 'T' &&
                        char.ToUpper(x) != 'R' && char.ToUpper(x) != 'Z' && char.ToUpper(x) != 'Q')
                        isChar = false;
                    else
                        isChar = true;
                }

                x = char.ToUpper(x);

                switch (x)
                {
                    case ('A'):

                        break;
                    case ('T'):

                        break;
                    case ('R'):

                        break;
                    case ('Z'):

                        break;
                    case ('Q'):
                        Console.WriteLine("Viso gero !");
                        Environment.Exit(0);
                        break;

                }


            }
        }

        private static bool PlayerConnect(Dictionary<string,int> playerList,out string nameSurname)
        {
            Console.Clear();
            Console.WriteLine("PRISIJUNGIMAS");
            Console.WriteLine();

            nameSurname = "";
            string name = "";
            string surname = "";
            
          


            do
            {
                Console.Write("Ivesk varda: ");
                name = Console.ReadLine().Trim();
                if (string.IsNullOrEmpty(name) || name.Length <= 1)
                    Console.WriteLine("Blogai ivedei varda. Ivesk is naujo.");
            }
            while (string.IsNullOrEmpty(name) || name.Length <= 1);

            do
            {
                Console.Write("Ivesk pavarde: ");
                surname = Console.ReadLine().Trim();
                if (string.IsNullOrEmpty(surname) || surname.Length <= 1)
                    Console.WriteLine("Blogai ivedei pavarde. Ivesk is naujo.");
            }
            while (string.IsNullOrEmpty(surname) || surname.Length <= 1);

            nameSurname = name[0].ToString().ToUpper() + name.Substring(1)+" "+ surname[0].ToString().ToUpper() + surname.Substring(1);
           
          
            if (playerList.ContainsKey(nameSurname))
            {
                Console.WriteLine("Toks zaidejas jau yra. Pakviesk drauga");
                Console.WriteLine("Spauskit bet koki kalvisa ir tavo draugas gales pradeti zaidima");
                Console.ReadKey();
                return false;
            }
        
            

           playerList.Add(nameSurname, 0);
            Console.WriteLine($"Sveiki {nameSurname} prisijungus. ");
            Console.WriteLine("Spauskit betkoki klavisa ir pradekite zaidima !");
            Console.ReadKey();
            return true;


            
        }












    }
}
