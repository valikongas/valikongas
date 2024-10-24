using System.Text;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // string str = "gedas dangus alytus kaunass";

            // StringBuilder sb = new StringBuilder(str);

            // for (int i=0; i<(sb.Length-1); i++)
            // for (int j=i+1; j<sb.Length; j++)
            // {
            //     if (sb[i] == sb[j])
            //     {
            //             sb = sb.Remove(j, 1);
            //             j -= 1;
            //     }

            // }
            //Console.WriteLine(sb.ToString());

            ////Nr. 1
            // int[] masyvas = new int[10];

            // for (int i = 0; i < masyvas.Length; i++)
            // {
            //     masyvas[i] = i+5;
            // }
            // int sum = 0;
            // int max = 0;
            // for (int i = 0; i < masyvas.Length; i++)
            // {
            //     masyvas[i] = masyvas[i] * masyvas[i];
            //     Console.WriteLine(masyvas[i]);
            //     sum += masyvas[i];
            //     if (masyvas[i] > max)
            //         max = masyvas[i];
            // }
            // Console.WriteLine($"Suma = {sum}");
            // Console.WriteLine($"Max = {max}");

            // int[] invertMasyvas = new int[10];
            // for (int i = 0; i < invertMasyvas.Length; i++)
            // {
            //     invertMasyvas[i] = masyvas[9 - i];
            //     Console.WriteLine(invertMasyvas[i]);
            // }


            ////Nr.2
            //string text = "labas";
            //char[] chars = text.ToCharArray();
            //for (int i = 0; i < chars.Length; i++)
            //{
            //    Console.Write("'" + chars[i] + "', ");
            //}
            //Console.WriteLine();
            //Console.WriteLine(chars[0]);
            //Console.WriteLine(chars[chars.Length-1]);


            //Nr.3.1-2
            int[] masyvas = new int[50];
            Random random = new Random();   
            for (int i = 0; i < masyvas.Length; i++)
            {  masyvas[i] = random.Next(1,100);
                Console.Write(masyvas[i]+" ");
            }
            for (int j = 0; j < masyvas.Length; j++)
            {
                for (int i = 0; i < masyvas.Length - 1; i++)
                {
                    if (masyvas[i] > masyvas[i + 1])
                    {
                        int laikinas = masyvas[i];
                        masyvas[i] = masyvas[i + 1];
                        masyvas[i + 1] = laikinas;
                    }
                }
            }
                Console.WriteLine();
            for (int i = 0; i < masyvas.Length; i++)
            {
              
                Console.Write(masyvas[i]+" ");
            }


            






        }
    }
}
