namespace _2_lygis_10_pamoka_exeption
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // Nr.1
            string word = "Petras";
            try
            {
                double wordconvert = Convert.ToDouble(word);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Konvertavimo klaida dėl tipo " + ex.Message);
            }
            Console.WriteLine();
            //----------------

            try
            {
                Object daiktas = new Object();
                double daiktasconvert = Convert.ToDouble(daiktas);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Netikamas objektas konbertavimui  " + ex.Message);
            }
            Console.WriteLine();
            //----------------------


            //Nr.2
            int[] arr = { 1, 2, 3, 4, 5 };
            try
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    Console.WriteLine(arr[i]);
                }
                Console.WriteLine(arr[7]);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Įvyko klaida: " + ex.Message);
            }
            //-----------------------------

            //Nr.3
            int[] arr2 = { 19, 0, 75, 52 };

            for (int i = 0; i < arr2.Length; i++)
            {
                try
                {
                    Console.WriteLine(arr2[i] / arr2[i + 1]);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Įvyko klaida: " + ex.Message);
                }
            }
            //---------------------------------


            //Nr.4
            Console.WriteLine("Pradeta uzduotis Nr.4");
            string path = "C:\\Users\\gedasvalikonis\\Desktoop\\testui.txt";
            StreamWriter writer = default;
            try
            {
                writer = new StreamWriter(path);
                throw new Netikra_klaida("Viskas vyksta kaip priklauso :)");
            }
            catch(Netikra_klaida ex)
            {
                Console.WriteLine("Klaidu nera. " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ivyko klaida: " + ex.Message);
                
            }
            try
            {
                writer.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Ivyko klaida uzdarant: "+ex.Message);
            }
            Console.WriteLine();
            Console.WriteLine("Kodas baigtas");
        }
    }
}
