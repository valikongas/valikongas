using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesseract;

namespace Marleksa_1
{
    internal class AtpazinimasDokumento
    {



        public void AtpazinimasDokumentoMetodas()
        {
            string tessDataPath = @"C:\Users\gedasvalikonis\Desktop\Marleksa";
            string imagePath = @"C:\Users\gedasvalikonis\Desktop\Marleksa\bandomasispaveiksliukas.jpg";
            try
            {
                // Sukuriamas Tesseract variklis
                using (var engine = new TesseractEngine(tessDataPath, "lit", EngineMode.Default))
                {
                    // Įkeliamas paveikslėlis
                    using (var img = Pix.LoadFromFile(imagePath))
                    {
                        // Atpažįstamas tekstas
                        using (var page = engine.Process(img))
                        {
                            string text = page.GetText();
                            Console.WriteLine("Atpažintas tekstas:");
                            Console.WriteLine(text);
                            Console.ReadLine();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Įvyko klaida: " + ex.Message);
                Console.ReadLine() ;
            }
        }
    
    
    }
}
