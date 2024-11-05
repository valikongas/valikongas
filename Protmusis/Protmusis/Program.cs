using System;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Runtime.InteropServices;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            Dictionary<string, int> playerList = new Dictionary<string, int>();

            string currentUser = "";
            while (!PlayerConnect(playerList, out currentUser)) ;


            GameMeniu(playerList, currentUser);




        }

        private static void GameMeniu(Dictionary<string, int> playerList, string currentUser)
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
                Console.WriteLine("R - Zaidimo rezultatu ir dalyviu perziura");
                Console.WriteLine("Z - Zaisti");
                Console.WriteLine("Q - Iseiti is zaidimo");

                char x = ' ';
                bool isChar = false;
                while (!isChar)
                {

                    x = Console.ReadKey().KeyChar;
                    Console.WriteLine("");
                    if (char.ToUpper(x) != 'A' && char.ToUpper(x) != 'T' &&
                        char.ToUpper(x) != 'R' && char.ToUpper(x) != 'Z' && char.ToUpper(x) != 'Q')
                    {
                        isChar = false;
                        Console.WriteLine("Ivedei neteisinga simboli !!!");
                    }
                    else
                        isChar = true;
                }

                x = char.ToUpper(x);

                switch (x)
                {
                    case ('A'):
                        while (!PlayerConnect(playerList, out currentUser)) ;
                        break;
                    case ('T'):
                        GameRules();
                        break;
                    case ('R'):
                        GameResult(playerList);
                        break;
                    case ('Z'):
                        PlayGame(currentUser, playerList);
                        break;
                    case ('Q'):
                        Console.WriteLine("Viso gero !");
                        Environment.Exit(0);
                        break;

                }


            }
        }

        private static bool PlayerConnect(Dictionary<string, int> playerList, out string nameSurname)
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

            nameSurname = name[0].ToString().ToUpper() + name.Substring(1) + " " + surname[0].ToString().ToUpper() + surname.Substring(1);


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


        private static void GameRules()
        {
            do
            {

                Console.Clear();
                Console.WriteLine("              ZAIDIMO TAISYKLES");
                Console.WriteLine();
                Console.WriteLine("Sveikiname prisijungus prie Protmūšio programos. Zaidimo  metu jums reiks atsakyti i 10 klausimu." +
                    " Atsizvelgiant i tai kiek klausimu atsakysite teisingai, tiek balu ir surinksite. Pries zadima galesite pasirinkti klausimu tema." +
                    " Kiekvienas klausimas turi po 4 variantus atsakymu, bet tik viena teisinga.");
                Console.WriteLine();
                Console.WriteLine("Spausk Q kad griztum atgal i meniu");
            }
            while (Console.ReadKey().Key != ConsoleKey.Q);

        }

        private static void GameResult(Dictionary<string, int> playerList)
        {
            bool isGoodAnsver = false;
            do
            {
                Console.Clear();
                Console.WriteLine("    ZAIDIMU REZULTATU MENIU");
                Console.WriteLine();
                Console.WriteLine("P perziureti kas zaidzia");
                Console.WriteLine("R perziureti rezultatus");
                Console.WriteLine("Q grizti i pagrindini meniu");
                ConsoleKey x = Console.ReadKey().Key;
                switch (x)
                {
                    case (ConsoleKey.P):
                        PlayerView(playerList);
                        break;
                    case (ConsoleKey.R):
                        PlayerRating(playerList);
                        break;
                    case (ConsoleKey.Q):
                        isGoodAnsver = true;
                        break;
                    default:
                        isGoodAnsver = false;
                        break;
                }
            }
            while (!isGoodAnsver);

        }

        private static void PlayerView(Dictionary<string, int> playerList)
        {
            Console.Clear();
            Console.WriteLine("SIUO METU ZAIDZIA:");
            Console.WriteLine();
            foreach (string j in playerList.Keys)
            {
                Console.WriteLine("     " + j);
            }
            Console.WriteLine();
            Console.WriteLine("Spausk bet kuri mygtuka ir grizk i meniu");
            Console.ReadKey();
        }

        private static void PlayerRating(Dictionary<string, int> playerList)
        {
            Console.Clear();
            Console.WriteLine("REITINGAS:");
            Console.WriteLine();
            var rating = playerList.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            int i = 1;
            string text = "";
            foreach ((string k, int l) in rating)
            {
                if (i < 4)
                    text = $"   {i}.*\t {k}\t";
                else if (i < 11)
                    text = $"   {i}.\t {k}\t";
                else
                    text = $"      \t {k}\t";
                if (k.Length < 7)
                    text = text + $"\t\t {l} tasku.";
                else if (k.Length < 15)
                    text = text + $"\t {l} tasku.";
                else
                    text = text + $" {l} tasku.";
                Console.WriteLine(text);
                i++;
            }
            Console.WriteLine();
            Console.WriteLine("Spausk bet kuri mygtuka ir grizk i meniu");
            Console.ReadKey();
        }

        private static void PlayGame(string currentUser, Dictionary<string, int> playerList)
        {
            
          
            var question= QuestionsCreate();
          

        }

        private static string[,] QuestionsCreate()
        {
            string[,] question =
            { { "1","Koks yra didžiausias planetas mūsų saulės sistemoje?", "Žemė", "Jupiteris", "Saturnas", "Marsas","false", "true","false","false"},
            { "2", "Koks yra didžiausias sausumos gyvūnas pasaulyje?", "Afrikos dramblys", "Baltasis lokys", "Juodasis raganosis", "Afrikinis hipopotamas", "true","false","false", "false" },
            {"3", "Kuris iš šių mokslininkų pirmasis pasiūlė heliocentrinę Visatos modelį, kuriame teigiama, kad Žemė ir kitos planetos sukasi aplink Saulę?", "Galileo Galilei", "Nikola Tesla", "Johannes Kepler", "Mikalaus Kopernikas","false","false", "false", "true"},
            {"4", "Kuriame 20 amžiaus dešimtmetyje buvo sukurta pirmoji kompiuterinė programa, ir kas buvo jos autorė?", "1930-aisiais, Ada Lovelace", "1940-aisiais, Grace Hopper", "1950-aisiais, Margaret Hamilton", "1960-aisiais, Jean E. Sammet", "true","false","false", "false"  },
            {"5", "Koks buvo pirmasis žmogus, kuris žengė ant Mėnulio?","Neil Armstrong", "Buzz Aldrin", "Yuri Gagarin","John Glenn","true","false","false", "false" },
            {"6","Koks garsus kūrinys, parašytas L. van Beethoveno, yra žinomas kaip 'Mėnesiena'?", "Simfonija Nr. 5", "Sonatina Nr. 2", "Sonata Nr. 14", "Simfonija Nr. 9", "false", "false", "true","false"},


    };
         

            return question;

        }

        
    }


}
