


namespace DB_baigiamasis
{
    public static class MainMenu
    {
        public static void Menu()
        {
            bool isQuit = false;
            do
            {
                Console.Clear();
                Console.WriteLine("         MENIU");
                Console.WriteLine("_________________________");
                Console.WriteLine("1 Sukurimas/korekcijos departamentu duomenimis");
                Console.WriteLine("2 Sukurimas/Korekcijos su paskaitu duomenimis  ");
                Console.WriteLine("3 Sukurimas/Korekcijos su studentu duomenimis");
                Console.WriteLine("------------------------------------------------");
                Console.WriteLine("4 Atvaizduoti visus departamento studentus");
                Console.WriteLine("5 Atvaizduoti visas departamento paskaitas");
                Console.WriteLine("6 Atvaizduoti visas paskaitas pagal studenta");
                Console.WriteLine("------------------------------------------------");
                Console.WriteLine("7 Atvaizduoti departamento medi");


                Console.WriteLine("Q Iseiti is programos");
                ConsoleKeyInfo clickkey = Console.ReadKey(intercept: true);  // intercept true nerodyti ivesties, false default  - rodyti

                switch (clickkey.Key)

                {
                    case ConsoleKey.D1 or ConsoleKey.NumPad1:  // D1 - 1 virs qwert, NumPad1 - 1 ant skaiciu klaviatiuros
                      DepartmentMenu.Menu();
                        break;
                    case ConsoleKey.D2 or ConsoleKey.NumPad2:
                      LectureMenu.Menu();
                        break;

                    case ConsoleKey.D3 or ConsoleKey.NumPad3:
                        StudentMenu.Menu();
                        break;

                    case ConsoleKey.D4 or ConsoleKey.NumPad4:
                        DepartamentOperation.StudentView();
                        break;

                    case ConsoleKey.D5 or ConsoleKey.NumPad5:
                        DepartamentOperation.LectureView();
                        break;

                    case ConsoleKey.D6 or ConsoleKey.NumPad6:
                        StudentOperation.LectureByStudentView();
                        break;

                    case ConsoleKey.D7 or ConsoleKey.NumPad7:
                        DepartamentOperation.ViewTree();
                        break;



                    case ConsoleKey.Q:
                        Environment.Exit(0);
                        break;
                }

            }
            while (!isQuit);


        }
    }
}
