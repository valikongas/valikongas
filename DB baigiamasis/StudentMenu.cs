using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_baigiamasis
{
    public class StudentMenu
    {

        public static void Menu()
        {
           
            do
            {
                Console.Clear();
                Console.WriteLine("         MENIU");
                Console.WriteLine("_________________________");
                Console.WriteLine("1 Sukurti studenta");
                Console.WriteLine("2 Koreguoti studento duomenis");
                Console.WriteLine("3 Naikinti studenta");
                Console.WriteLine("4 Priskirti prie departamento studenta");
                Console.WriteLine("5 Keisti studento departamenta");
                Console.WriteLine("6 Atsieti nuo departamento studenta");
                Console.WriteLine("7 Priskirti studentui paskaitas");
                Console.WriteLine("8 Panaikinti sudentui paskaitas");
                Console.WriteLine("Q Grizti i pagrindini meniu");
                ConsoleKeyInfo clickkey = Console.ReadKey(intercept: true);  // intercept true nerodyti ivesties, false default  - rodyti

                switch (clickkey.Key)

                {
                    case ConsoleKey.D1 or ConsoleKey.NumPad1:  // D1 - 1 virs qwert, NumPad1 - 1 ant skaiciu klaviatiuros
                        StudentOperation.CreateNewStudent();
                        break;
                    case ConsoleKey.D2 or ConsoleKey.NumPad2:
                        StudentOperation.CorrectionStudentData();
                        break;

                    case ConsoleKey.D3 or ConsoleKey.NumPad3:
                        StudentOperation.RemoveStudent();
                        break;

                    case ConsoleKey.D4 or ConsoleKey.NumPad4:
                        StudentOperation.AddStudentToDepartament();
                        break;
                    case ConsoleKey.D5 or ConsoleKey.NumPad5:
                        StudentOperation.ChangeStudentDepartament();
                        break;
                    case ConsoleKey.D6 or ConsoleKey.NumPad6:
                        StudentOperation.RemoveStudentFromDepartament();
                        break;
                    case ConsoleKey.D7 or ConsoleKey.NumPad7:
                        StudentOperation.AddStudentToLecture();
                        break;
                    case ConsoleKey.D8 or ConsoleKey.NumPad8:
                        StudentOperation.RemoveStudentFromLecture();
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
