

namespace DB_baigiamasis
{
    public class LectureMenu
    {
        public static void Menu()
        {
        
            do
            {
                Console.Clear();
                Console.WriteLine("         MENIU");
                Console.WriteLine("_________________________");
                Console.WriteLine("1 Sukurti paskaita");
                Console.WriteLine("2 Koreguoti paskaitos pavadinima");
                Console.WriteLine("3 Naikinti paskaita");
                Console.WriteLine("4 Priskirti paskaita prie departamento");
                Console.WriteLine("5 Atsieti paskaita nuo departamento");
                Console.WriteLine("6 Priskirti paskaitai studentus");
                Console.WriteLine("7 Atsieti paskaitos studentus");
                Console.WriteLine("Q Grizti i pagrindini meniu");
                ConsoleKeyInfo clickkey = Console.ReadKey(intercept: true);  

                switch (clickkey.Key)

                {
                    case ConsoleKey.D1 or ConsoleKey.NumPad1:  
                        LectureOperation.CreateNewLecture();
                        break;
                    case ConsoleKey.D2 or ConsoleKey.NumPad2:
                        LectureOperation.CorrectionLectureName();
                        break;

                    case ConsoleKey.D3 or ConsoleKey.NumPad3:
                        LectureOperation.RemoveLecture();
                        break;

                    case ConsoleKey.D4 or ConsoleKey.NumPad4:
                        LectureOperation.AddLectureToDepartament();
                        break;
                    case ConsoleKey.D5 or ConsoleKey.NumPad5:
                        LectureOperation.RemoveLectureFromDepartament();
                        break;
                    case ConsoleKey.D6 or ConsoleKey.NumPad6:
                        LectureOperation.AddStudentToLecture();
                        break;
                    case ConsoleKey.D7 or ConsoleKey.NumPad7:
                        LectureOperation.RemoveStudentFromLecture();
                        break;

                    case ConsoleKey.Q:
                        MainMenu.Menu();
                        break;
                }

            }
            while (true);


        }


    }
}
