namespace _2_lygis_17_pamoka_Multitreading
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var progress1 = new Progressbar();
            Task antra = ProgressPrint(progress1);
            Task pirma = ProgressIncrease(progress1);
            Task trecias = PrintDir(@"C:\\Users\\gedasvalikonis\\Downloads\");
            
            
            
            
            await pirma;

            
            Console.WriteLine("Programa baigta.");
            await antra;
            Console.WriteLine("Viskas baig4si");
        }

        public static async Task ProgressIncrease(Progressbar progress1)
        {
            while (progress1.progress < 100)
            {
                progress1.progress++;
                await Task.Delay(50);
            }
        }

        public static async Task ProgressPrint(Progressbar progress2)
        {
            while (progress2.progress <= 100)
            {
                Console.WriteLine("Dabar yra: " + progress2.progress);
                if (progress2.progress == 100)
                {
                    progress2.progress++;
                }
                await Task.Delay(500);
            }
        }

        public static async Task PrintDir(string path)
        {
            while (true)
            {
                string[] failai = Directory.GetFiles(path);
               foreach (string file in failai)
                {
                    Console.WriteLine(file);
                }
                await Task.Delay(2000);
            }
        }

    }
}



