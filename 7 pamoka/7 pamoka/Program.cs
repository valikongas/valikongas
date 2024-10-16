using System.Diagnostics.CodeAnalysis;

namespace _7_pamoka
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ////Nr.1. uzduotis

            //Console.Write("Ivesk slaptazodi:");
            //string password = Console.ReadLine();
            //Console.Write("Ivesk emaila:");
            //string email = Console.ReadLine();

            //bool isPassword = IsPasswordValid(password);
            //if (isPassword)
            //    Console.WriteLine("Slaptazodis geras");
            //else
            //    Console.WriteLine("Slaptazodism per trumpas");
            //bool isMail = IsMailValid(email);
            //if (isMail)
            //    Console.WriteLine("Emailas geras");
            //else
            //    Console.WriteLine("Emailas blogas");


            ////Uzduotis Nr.2
            //Console.Write("Ivesk varda: ");
            //string name = Console.ReadLine();
            //Console.Write("Ivesk pavarde: ");
            //string surname = Console.ReadLine();

            //string duomenys = GetInitials(name, surname);
            //Console.WriteLine(duomenys);

            Console.WriteLine("Ivesk kokio skaiciaus noretum suskaiciuoti faktoriala:");
            int skaicius=(Convert.ToInt32(Console.ReadLine()));
            int suma = 1;
            int atsakymas = Recursion(skaicius);
            Console.WriteLine("Faktorialas lygus: "+atsakymas);





        }
        //// Uzduotis Nr. 1
        //public static bool IsPasswordValid(string password)
        //{
        //    if (password.Length > 8)
        //        return true;
        //    return false;
        //}

        //private static bool IsMailValid(string email)
        //{
        //    if (email.Contains('@') && email.Contains('.'))
        //        return true;
        //    return false;


        //}
        ////Uzduotis Nr. 2
        //private static string GetInitials(string name, string surname)
        //{

        //    string word = string.Concat(name, " ", surname);
        //    return word;
        //}

        private static int Recursion(int skaicius)
        {

            if (skaicius != 1)
            {

                Console.WriteLine("pries skaicius" + skaicius);
                skaicius = skaicius * Recursion(skaicius - 1);
                Console.WriteLine("veliau skaicius: " + skaicius);
                return skaicius;
            }
            else
            {
                Console.WriteLine("Isejimas");
                return skaicius;
            }
        }






    }




}
