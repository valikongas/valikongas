
namespace DB_baigiamasis
{
    public class DepartmentMenu
    {
        public static void Menu()
        {

            do
            {
                Console.Clear();
                Console.WriteLine("         MENIU");
                Console.WriteLine("_________________________");
                Console.WriteLine("1 Sukurti departamenta");
                Console.WriteLine("2 Koreguoti departamento pavadinima");             
                Console.WriteLine("3 Naikinti departamenta");
                Console.WriteLine("4 Priskirti prie departamento paskaitas");
                Console.WriteLine("5 Atsieti nuo departamento paskaitas");
                Console.WriteLine("6 Priskirti prie departamento studentus");
                Console.WriteLine("7 Atsieti nuo departamento studentus");
                Console.WriteLine("Q Grizti i pagrindini meniu");
                ConsoleKeyInfo clickkey = Console.ReadKey(intercept: true);  // intercept true nerodyti ivesties, false default  - rodyti

                switch (clickkey.Key)

                {
                    case ConsoleKey.D1 or ConsoleKey.NumPad1:  // D1 - 1 virs qwert, NumPad1 - 1 ant skaiciu klaviatiuros
                        DepartamentOperation.CreateNewDepartament();
                        break;
                    case ConsoleKey.D2 or ConsoleKey.NumPad2:
                        DepartamentOperation.CorrectionDepartamentName();
                        break;

                    case ConsoleKey.D3 or ConsoleKey.NumPad3:
                        DepartamentOperation.RemoveDepartament();
                        break;                    
                    
                    case ConsoleKey.D4 or ConsoleKey.NumPad4:
                        DepartamentOperation.AddLectureToDepartament();
                        break;
                    case ConsoleKey.D5 or ConsoleKey.NumPad5:
                        DepartamentOperation.RemoveLectureFromDepartament();
                        break;
                    case ConsoleKey.D6 or ConsoleKey.NumPad6:
                        DepartamentOperation.AddStudentToDepartament();
                        break;
                    case ConsoleKey.D7 or ConsoleKey.NumPad7:
                        DepartamentOperation.RemoveStudentFromDepartament();
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
