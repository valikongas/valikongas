using System;









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
                Console.WriteLine();
                Console.WriteLine("Spauskit bet koki kalvisa ir tavo draugas gales pradeti zaidima");
                Console.ReadKey();
                return false;
            }



            playerList.Add(nameSurname, 0);
            Console.WriteLine($"Sveiki {nameSurname} prisijungus. ");
            Console.WriteLine();
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
            var rating = playerList.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
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

            // masyvas yra [53,10], 
            string[,] question = QuestionsCreate();
            Random number = new Random();
            Dictionary<int,int> questionNumber = new Dictionary<int,int>();
            for (int i = 0; i < 10; i++)
            {
                bool isNumberGood = false;
              
                do
                {
                    int j = number.Next(1,54);
                    if (!questionNumber.ContainsKey(j))
                    {
                        questionNumber.Add(j,0);
                        isNumberGood = true;
                    }   
                }
                while (!isNumberGood);
            }
            int point = 0;
            int viewerAssistance = 0;
            int viewerAssistance1 = 0; 
            bool isQuitOutOfGame = false;
            for (int i = 0;i<10;i++)
            {
              bool isGoodAnsver=false;
                do
                {   
                Console.Clear();
                Console.WriteLine("ZAIDIMAS");
                Console.WriteLine();
                Console.WriteLine($"Zaidejas :{currentUser}     Surinktas tasku: {point}");
                Console.WriteLine();
                Console.WriteLine($"Klausimas Nr.{i+1}. is 10.");
                Console.WriteLine();
                Console.WriteLine(question[questionNumber.ElementAt(i).Key-1,1]);
                Console.WriteLine();
                Console.WriteLine("A. "+ question[questionNumber.ElementAt(i).Key - 1, 2]);
                Console.WriteLine("B. "+ question[questionNumber.ElementAt(i).Key - 1, 3]);
                Console.WriteLine("C. "+ question[questionNumber.ElementAt(i).Key - 1, 4]);
                Console.WriteLine("D. "+ question[questionNumber.ElementAt(i).Key - 1, 5]);
                Console.WriteLine();
                    Console.WriteLine("Rinkis teisinga atsakyma: A, B, C, D");
                    Console.WriteLine("arba spausk S jei reikia sales pagalvos, spausk H jei nori kad atmestu du neteisingus variantus arba spausk Q ir grizk i pradini meniu");
                
              
                    ConsoleKey x = Console.ReadKey().Key;
                    switch (x)
                    {
                        case (ConsoleKey.A):
                            IsAnswerTrue(6, question, questionNumber, ref point, i);
                            isGoodAnsver = true;
                            break;
                        case (ConsoleKey.B):
                            IsAnswerTrue(7, question, questionNumber, ref point, i);
                            isGoodAnsver = true;
                            break;
                        case (ConsoleKey.C):
                            IsAnswerTrue(8, question, questionNumber, ref point, i);
                            isGoodAnsver = true;
                            break;
                        case (ConsoleKey.D):
                            IsAnswerTrue(9, question, questionNumber, ref point, i);
                            isGoodAnsver = true;
                            break;
                        case (ConsoleKey.Q):
                            isGoodAnsver = true;
                            isQuitOutOfGame = true;
                            break;
                        case (ConsoleKey.S):
                            if (viewerAssistance == 0)
                            {
                                int trueAnswer = 0;
                                for (int k = 6; k < 10; k++)
                                {
                                    if (Convert.ToBoolean(question[questionNumber.ElementAt(i).Key - 1, k]))
                                        trueAnswer = k;
                                }    
                                ViewerAssistance(trueAnswer);
                                viewerAssistance++;
                            }
                            
                            else
                                Console.WriteLine("Tu sales pagalba jau isnaudojai");
                                isGoodAnsver = false;
                            Console.WriteLine("Spausk bet juri mygtuka ir bandyk speti");
                            Console.ReadKey();
                            break;

                        case (ConsoleKey.H):
                            if (viewerAssistance1 == 0)
                            {
                                int trueAnswer = 0;
                                for (int k = 6; k < 10; k++)
                                {
                                    if (Convert.ToBoolean(question[questionNumber.ElementAt(i).Key - 1, k]))
                                        trueAnswer = k;
                                }
                                TwoAnswer(trueAnswer);
                                viewerAssistance1++;
                            }

                            else
                                Console.WriteLine("Tu puse per puse pagalba jau isnaudojai");
                            isGoodAnsver = false;
                            Console.WriteLine("Spausk bet juri mygtuka ir bandyk speti");
                            Console.ReadKey();
                            break;
                        default:
                            isGoodAnsver = false;
                            break;
                    }
                }
                while (!isGoodAnsver);

                if (isQuitOutOfGame)
                {
                    
                    break;

                }
            
            }
            if (point>playerList[currentUser])
         playerList[currentUser] = point;

            GameAnswerResult(currentUser, point, question,questionNumber, playerList);

        }

        private static string[,] QuestionsCreate()
        {
            string[,] question =
            {
            {"1","Koks yra didžiausias planetas mūsų saulės sistemoje?", "Žemė", "Jupiteris", "Saturnas", "Marsas","false", "true","false","false"},
            {"2", "Koks yra didžiausias sausumos gyvūnas pasaulyje?", "Afrikos dramblys", "Baltasis lokys", "Juodasis raganosis", "Afrikinis hipopotamas", "true","false","false", "false" },
            {"3", "Kuris iš šių mokslininkų pirmasis pasiūlė heliocentrinę Visatos modelį, kuriame teigiama, kad Žemė ir kitos planetos sukasi aplink Saulę?", "Galileo Galilei", "Nikola Tesla", "Johannes Kepler", "Mikalaus Kopernikas","false","false", "false", "true"},
            {"4", "Kuriame 20 amžiaus dešimtmetyje buvo sukurta pirmoji kompiuterinė programa, ir kas buvo jos autorė?", "1930-aisiais, Ada Lovelace", "1940-aisiais, Grace Hopper", "1950-aisiais, Margaret Hamilton", "1960-aisiais, Jean E. Sammet", "true","false","false", "false"  },
            {"5", "Koks buvo pirmasis žmogus, kuris žengė ant Mėnulio?","Neil Armstrong", "Buzz Aldrin", "Yuri Gagarin","John Glenn","true","false","false", "false" },
            {"6","Koks garsus kūrinys, parašytas L. van Beethoveno, yra žinomas kaip 'Mėnesiena'?", "Simfonija Nr. 5", "Sonatina Nr. 2", "Sonata Nr. 14", "Simfonija Nr. 9", "false", "false", "true","false"},
            {"7", "Kuriais metais Lietuva tapo NATO nare?", "2000", "2004", "2007", "2010", "false", "true", "false", "false"},
            {"8", "Koks yra aukščiausias Lietuvos kalnas?", "Gedimino kalnas", "Medvėgalis", "Birutės kalnas", "Aukštojas", "false", "false", "false", "true"},
            {"9", "Kuri Lietuvos upė yra ilgiausia?", "Neris", "Šešupė", "Nemunas", "Venta", "false", "false", "true", "false"},
            {"10", "Kiek rajonų turi Lietuva?", "10", "30", "50", "60", "false", "false", "false", "true"},
            {"11", "Kuris Lietuvos miestas vadinamas Laikina sostine?", "Kaunas", "Vilnius", "Trakai", "Kernave", "true", "false", "false", "false"},
            {"12", "Kurie metai laikomi Lietuvos valstybės atkūrimo metais?", "2004", "1940", "1990", "1918", "false", "false", "false", "true"},
            {"13", "Kokia yra Lietuvos nacionalinė gėlė?", "Rožė", "Rūta", "Saulutė", "Aguona", "false", "true", "false", "false"},
            {"14", "Kuri Lietuvos Respublikos Prezidentas ėjo šias pareigas 2009-2019 m.?", "Rolandas Paksas", "Algirdas Brazauskas", "Valdas Adamkus", "Dalia Grybauskaitė", "false", "false", "false", "true"},
            {"15", "Kokia Lietuvos etnografinė sritis garsėja kryždirbyste?", "Dzūkija", "Aukštaitija", "Žemaitija", "Suvalkija", "false", "true", "false", "false"},
            {"16", "Kuri Lietuvos jūra yra žemiausias Lietuvos taškas?", "Neringos ežeras", "Kuršių marios", "Baltijos jūra", "Upe Jura", "false", "false", "true", "false"},
            {"17", "Kuri Lietuvos upė prateka pro Anykscius?", "Nemunas", "Sventoji", "Merkys", "Neris", "false", "true", "false", "false"},
            {"18", "Kuriais metais buvo pasirašyta Lietuvos Nepriklausomybės akto deklaracija?", "1918", "1940", "1990", "2004", "true", "false", "false", "false"},
            {"19", "Kokia yra ilgiausia diena Lietuvoje?", "Birželio 24", "Birželio 22", "Liepos 1", "Birželio 21", "false", "true", "false", "false"},
            {"20", "Kuriame Lietuvos mieste yra Perkūno namai?", "Kaune", "Vilniuje", "Šiauliuose", "Panevėžyje", "true", "false", "false", "false"},
            {"21", "Koks yra Lietuvos nacionalinis paukštis?", "Žąsis", "Garnys", "Gandras", "Kregždė", "false", "false", "true", "false"},
            {"22", "Kiek kilometrų Lietuvos siena ribojasi su Baltarusija?", "502 km", "550 km", "456 km", "110 km", "true", "false", "false", "false"},
            {"23", "Kokia yra didžiausia Lietuvos sala?", "Nida", "Rusnė", "Kuršių Nerija", "Šventoji", "false", "true", "false", "false"},
            {"24", "Kokioje Lietuvos dalyje yra Žemaitija?", "Šiaurės vakaruose", "Pietuose", "Rytuose", "Centrinėje dalyje", "true", "false", "false", "false"},
            {"25", "Kuri iš šių Lietuvos ežerų yra didžiausias?", "Platelių", "Drūkšių", "Dusia", "Galvė", "false", "true", "false", "false"},
            {"26", "Koks yra seniausias Lietuvos miestas?", "Kernavė", "Kaunas", "Alytus", "Vilnius", "true", "false", "false", "false"},
            {"27", "Kurioje Lietuvos dalyje yra Druskininkų kurortas?", "Pietuose", "Šiaurėje", "Vakaruose", "Rytuose", "true", "false", "false", "false"},
            {"28", "Kur yra Lietuvos nacionalinis muziejus?", "Kaune", "Vilniuje", "Klaipėdoje", "Šiauliuose", "false", "true", "false", "false"},
            {"29", "Koks ežeras yra šalia Trakų pilies?", "Galvės", "Dusia", "Drūkšių", "Platelių", "true", "false", "false", "false"},
            {"30", "Kuriame mieste yra Lietuvos pajūrio muziejus?", "Palangoje", "Neringoje", "Šventojoje", "Klaipėdoje", "false", "false", "false", "true"},
            {"31", "Kuris Lietuvos prezidentas buvo išrinktas 2019 m.?", "Rolandas Paksas", "Dalia Grybauskaitė", "Gitanas Nausėda", "Valdas Adamkus", "false", "false", "true", "false"},
            {"32", "Kokia yra tradicinė Lietuvos gėrimo rūšis?", "Alus", "Vanduo", "Midus", "Vynas", "false", "false", "true", "false"},
            {"33", "Kurios religijos bažnyčia yra Vilniaus Aušros Vartai?", "Katalikų", "Protestantų", "Stačiatikių", "Liuteronu", "true", "false", "false", "false"},
            {"34", "Kokia yra pagrindinė Lietuvos eksportuojama prekė?", "Nafta", "Tekstilė", "Mediena", "Maisto produktai", "false", "false", "true", "false"},
            {"35", "Koks miestas žinomas kaip „Saulės miestas“?", "Vilnius", "Šiauliai", "Panevėžys", "Kaunas", "false", "true", "false", "false"},
            {"36", "Netoli kokio miesto įsikūręs Kryžių kalnas?", "Vilniaus", "Šiauliu", "Kėdainiu", "Kretingos", "false", "true", "false", "false"},
            {"37", "Kokį miestą kerta Gedimino prospektas?", "Kaunas", "Vilnius", "Klaipėda", "Panevėžys", "false", "true", "false", "false"},
            {"38", "Kokios spalvos yra Lietuvos vėliava?", "Geltona, žalia, raudona", "Mėlyna, balta, žalia", "Raudona, balta, juoda", "Žalia, balta, geltona", "true", "false", "false", "false"},
            {"39", "Kas buvo pirmasis atkurtos Lietuvos prezidentas?", "Algirdas Brazauskas", "Valdas Adamkus", "Rolandas Paksas", "Vytautas Landsbergis", "true", "false", "false", "false"},
            {"40", "Kuris miestas buvo pirmoji Lietuvos sostinė?", "Trakai", "Kernavė", "Vilnius", "Kaunas", "false", "true", "false", "false"},
            {"41", "Kurio Lietuvos ežero plotas didžiausias?", "Dusia", "Platelių ežeras", "Galvės ežeras", "Drūkšių ežeras", "false", "false", "false", "true"},
            {"42", "Kokia yra Lietuvos himno pavadinimo pirmoji eilutė?", "Oi graži Lietuva", "Lietuva, tėvyne mūsų", "Mes Lietuvos vaikai", "Aš Lietuvos", "false", "true", "false", "false"},
            {"43", "Kurioje Lietuvos vietovėje galima rasti piliakalnių kompleksą?", "Aukštaitijoje", "Trakuose", "Kernavėje", "Vilniuje", "false", "false", "true", "false"},
            {"44", "Koks nacionalinis Lietuvos augalas?", "Liepa", "Eglė", "Ąžuolas", "Beržas", "false", "false", "true", "false"},
            {"45", "Kokios spalvos yra Vilniaus miesto herbas?", "Raudona ir balta", "Balta, raudona ir auksinė", "Raudona ir auksinė", "Žalia ir balta", "false", "true", "false", "false"},
            {"46", "Kurioje vietovėje yra Lietuvoje garsus Puntuko akmuo?", "Biržuose", "Anykščiuose", "Kernavėje", "Kretingoje", "false", "true", "false", "false"},
            {"47", "Kokį žymų paminklą galima rasti Vilniuje prie Katedros aikštės?", "Mindaugo paminklą", "Gedimino paminklą", "Vytauto Didžiojo paminklą", "K. Donelaičio paminklą", "false", "true", "false", "false"},
            {"48", "Kurios marios yra Lietuvos teritorijoje?", "Kauno marios", "Nemuno marios", "Vilniaus marios", "Klaipėdos marios", "true", "false", "false", "false"},
            {"49", "Kas pastatė pirmąją Lietuvos bažnyčią?", "Vytautas Didysis", "Jogaila", "Mindaugas", "Kęstutis", "false", "false", "true", "false"},
            {"50", "Koks miestas yra Lietuvos krepšinio centras?", "Vilnius", "Kaunas", "Šiauliai", "Klaipėda", "false", "true", "false", "false"},
            {"51", "Kiek yra etnografinių Lietuvos regionų?", "4", "5", "6", "7", "false", "true", "false", "false"},
            {"52", "Kokia yra Vilniaus arkikatedros bazilikos varpinės spalva?", "Balta", "Raudona", "Žalia", "Ruda", "true", "false", "false", "false"},
            {"53", "Koks yra Lietuvos gyventojų tankumas?", "Apie 45 žmonės/km²", "Apie 55 žmonės/km²", "Apie 65 žmonės/km²", "Apie 75 žmonės/km²", "false", "false", "true", "false"},
            };
            return question;

        }

        private static void IsAnswerTrue(int answer, string[,] question, Dictionary<int,int> questionNumber, ref int point, int i)
        {


            {
                if (Convert.ToBoolean(question[questionNumber.ElementAt(i).Key - 1, answer]))
                {
                    point++;
                    Console.WriteLine();
                    Console.WriteLine("Atsakymas teisingas");
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Atsakymas neteisingas");
                }
                questionNumber[questionNumber.ElementAt(i).Key] = answer;
               
                Console.WriteLine();
                if (i < 9)
                    Console.WriteLine("Spausk bet kuri mygtuka ir bandyk atsakyti i sekanti klausima");
                else
                    Console.WriteLine("Spausk bet kuri mygtuka ir pasiziurek zaidimo rezultatus");
                Console.ReadKey();
            }
        }

        private static void GameAnswerResult(string currentUser, int point,string [,] question, Dictionary <int,int> questionNumber, Dictionary<string,int> playerList )
        {
            Console.Clear();
            Console.WriteLine("     ZAIDIMO ATASKAITA");
            Console.WriteLine();
            Console.WriteLine($"Zaidejas :{currentUser}     Surinktas tasku: {point}");

            var rating = playerList.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            var ratingList = rating.Keys.ToList();
            int place=ratingList.IndexOf(currentUser);

            Console.WriteLine("Zaidejo uzimama vieta :"+(place+1));
            Console.WriteLine();
            Console.WriteLine();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"{i+1}. Klausimas: {question[questionNumber.ElementAt(i).Key - 1, 1]} ");
                Console.WriteLine("");
               
                if (questionNumber.ElementAt(i).Value == 0)
                {
                    Console.WriteLine("Tu daugiau atsakymu nepateikei");
                    break;
                }
                else if (Convert.ToBoolean(question[questionNumber.ElementAt(i).Key - 1, questionNumber.ElementAt(i).Value]))
                {
                    Console.WriteLine($"Tu atsakei: {question[questionNumber.ElementAt(i).Key - 1, questionNumber.ElementAt(i).Value - 4]}");
                    Console.WriteLine("Tu atsakei teisingai !!!");
                    Console.WriteLine();
                    Console.WriteLine();
                }
                else
                {
                    for (int j = 6; j < 10; j++)
                    {
                        if (Convert.ToBoolean(question[questionNumber.ElementAt(i).Key - 1, j]))
                        {
                            Console.WriteLine($"Tu atsakei: {question[questionNumber.ElementAt(i).Key - 1, questionNumber.ElementAt(i).Value - 4]}");
                            Console.WriteLine($"Teisingas atsakymas buvo: {question[questionNumber.ElementAt(i).Key - 1, j - 4]}");
                            Console.WriteLine();
                            Console.WriteLine();
                        }
                    }
                }

            }
            Console.WriteLine();
            Console.WriteLine("Spausk bet kuri mygtuka ir grizk i meniu");
            Console.ReadKey();
            Console.Clear();
        }

        private static void ViewerAssistance(int trueAnswer)
        { 
        Random  intengerNumber= new Random();
           int truevalue =intengerNumber.Next(20,85);
            int falsevalue1 = intengerNumber.Next(1, 10);
            int falsevalue2 = intengerNumber.Next(1, (100 - truevalue - falsevalue1) / 2);
            int falsevalue3 = 100-truevalue-falsevalue1 - falsevalue2;
            Console.WriteLine();
            if (trueAnswer==6)
            
                Console.WriteLine($"Kad atsakymas A teisingas mano {truevalue} %, kad B - {falsevalue1} %, kad C - {falsevalue2} %, kad D - {falsevalue3} %");
            else if (trueAnswer==7)
                Console.WriteLine($"Kad atsakymas A teisingas mano {falsevalue3} %, kad B - {truevalue} %, kad C - {falsevalue2} %, kad D - {falsevalue1} %");
            else if (trueAnswer == 8)
                Console.WriteLine($"Kad atsakymas A teisingas mano {falsevalue1} %, kad B - {falsevalue2} %, kad C - {truevalue} %, kad D - {falsevalue3} %");
            else if (trueAnswer == 9)
                Console.WriteLine($"Kad atsakymas A teisingas mano {falsevalue2} %, kad B - {falsevalue1} %, kad C - {falsevalue3} %, kad D - {truevalue} %");
        }

        private static void TwoAnswer(int trueAnswer)
        {
            Console.WriteLine();
            if (trueAnswer == 6)
                Console.WriteLine("B ir D variantai neteisingi");
            else if (trueAnswer == 7)
                Console.WriteLine("A ir D variantai neteisingi");
            else if(trueAnswer == 8)
                Console.WriteLine("B ir D variantai neteisingi");
            else if (trueAnswer==9)
                Console.WriteLine("B ir C variantai neteisingi");
           

           


        }

     
    }


}
