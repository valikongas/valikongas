using System.Reflection.PortableExecutable;
using static System.Net.Mime.MediaTypeNames;

namespace _2_lygio_6_pamoka_Stream
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Nr.1
            
            string path = "C:\\Users\\gedasvalikonis\\Documents\\GitHub\\valikongas\\2 lygio 6 pamoka Stream\\tekstas.txt";
            string path1 = "C:\\Users\\gedasvalikonis\\Documents\\GitHub\\valikongas\\2 lygio 6 pamoka Stream\\irasytastekstas.txt";
            string path2 = "C:\\Users\\gedasvalikonis\\Documents\\GitHub\\valikongas\\2 lygio 6 pamoka Stream\\newirasytastekstas.txt";
            string tekstas = File.ReadAllText(path);
            Console.WriteLine("Pirmas variantas:");
            Console.WriteLine(tekstas);
            var tekstas1 = File.ReadLines(path);
            Console.WriteLine("");
            Console.WriteLine("Antras variantas:");
            foreach (string line in tekstas1)
            {
                Console.WriteLine(line);
            }
            File.WriteAllLines(path1, tekstas1);
          //  File.Copy(path1, path2);


            //Nr.2
            foreach (string text in tekstas1)
                Console.WriteLine("Simboliu skaicius" + text.Length);

            StreamWriter streamWriter = new StreamWriter(path2);
            streamWriter.WriteLine("Gero vakaro");
            streamWriter.WriteLine("Dabar yra 21:50");
            streamWriter.WriteLine(555);

            streamWriter.Dispose();

            BinaryWriter binaryWriter = new BinaryWriter(File.Open(path1, FileMode.Open));
            binaryWriter.Write(tekstas);
            binaryWriter.Close();
            binaryWriter.Dispose();

            using (BinaryReader binaryReader=new BinaryReader(File.Open(path2, FileMode.Open)))
            {
                Console.WriteLine("XXXXXXXXXXXXX");
                while (binaryReader.BaseStream.Position < binaryReader.BaseStream.Length)
                {
                    string x=binaryReader.ReadByte().ToString();
                    Console.WriteLine(x);
                }
            }
        
        
        }




    }
}
