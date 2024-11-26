using System.Security.Cryptography.X509Certificates;

namespace _2_lygio_8_pamoka_Generic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Nr.1 Print
            Print<int,string> kintamujuPora1 = new Print<int , string>(10,"Tomas");
            var kintamujuPora2 = new Print<int, string>("Arunas");
            var kintamujuPora3 = new Print<int, string>(30);
            kintamujuPora1.PrintFirstCons();
            kintamujuPora1.PrintSecondCons();
            kintamujuPora2.ChangeFirstCons(20);
            kintamujuPora2.PrintFirstCons();
            kintamujuPora2.PrintSecondCons();
            kintamujuPora3.ChangeSecondCons("Laima");
            kintamujuPora3.PrintFirstCons();
            kintamujuPora3.PrintSecondCons();
            Console.WriteLine("");
            

            //-----------------------

            //Nr.2 FourSideGeometricFicgure
            var kvadratas = new FourSideGeometricFigure("kvadratas", 5, 5);
            var staciakampis = new FourSideGeometricFigure("staciakampis", 5, 10);
            kvadratas.Show(kvadratas);
            staciakampis.Show(staciakampis);
            Console.WriteLine("");
            //------------------------------


            //Nr.3
            var type=new Type<int,string> (10,"Gedas");
            type.GetType();
            //--------------------------------


            //Nr.4
            Soccer soccer1=new Soccer("Zalgiris", 5000, 10, "Futbolas" );
            Soccer soccer2 = new Soccer("Banga", 300, 15, "Futbolas");

            var futbolas = new Champion<Soccer>();
            futbolas.AddComandList(soccer1);
            futbolas.AddComandList (soccer2);
            soccer1.SoccerPrint(futbolas.ComandList);
            futbolas.PrintComandList();
            





        }
    }
}
