
using System;
using Microsoft.Office.Interop.Word;

namespace ConsoleApp4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Application wordApp = new Application();
            Document wordDoc = wordApp.Documents.Add();

            try
            {
                // Pridedame tekstą
                Paragraph para = wordDoc.Content.Paragraphs.Add();
                para.Range.Text = "Tai yra pavyzdinis tekstas, kuris bus suformatuotas.";

                // Formatuojame tekstą
                para.Range.Font.Bold = 1;              // Parieškinimas
                para.Range.Font.Size = 14;            // Šrifto dydis
                para.Range.Font.Name = "Arial";       // Šrifto pavadinimas
                para.Range.Font.Color = WdColor.wdColorBlue; // Teksto spalva
                para.Alignment = WdParagraphAlignment.wdAlignParagraphCenter; // Centruotas tekstas
              
                para.Format.SpaceBefore = 0; // Jokio tarpo prieš
                para.Format.SpaceAfter = 0;  // Jokio tarpo po
                para.Format.LineSpacingRule = WdLineSpacing.wdLineSpaceSingle; // Viengubas eilučių intervalas
                para.Range.InsertParagraphAfter();

                // Pridedame naują pastraipą
                Paragraph para2 = wordDoc.Content.Paragraphs.Add();
                para2.Range.Font.Size= 12;
                para2.Range.Text = $" \n\tasasass  Antra pastraipa su kita spalva sdsdsd\nsd sdsdsdsd sdsdsd sdsdsd sdsdsdsd sdsdsdsd sdsdsffdfs sdsdsdsd sdsdsf.";
                para2.Range.Font.Color = WdColor.wdColorRed;
                para2.Alignment= WdParagraphAlignment.wdAlignParagraphJustify;
                para2.Range.Font.Name = "Time New Roman";
                
                para2.Range.InsertParagraphAfter();
                // trecias paragrafas

                Paragraph para3 = wordDoc.Content.Paragraphs.Add();
                para3.Range.Text = $"\tasasass  Antra pastraipa su kita spalva sdsdsdsd sdsdsdsd sdsdsd sdsdsd sdsdsdsd sdsdsdsd sdsdsffdfs sdsdsdsd sdsdsf.";
                para3.Range.Font.Color = WdColor.wdColorOliveGreen;
          


                // Išsaugome failą
                string filePath = @"C:\Users\gedasvalikonis\Documents\GitHub\valikongas\ConsoleApp4\failas.docx";
                wordDoc.SaveAs2(filePath);
                Console.WriteLine("Failas išsaugotas: ");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Klaida: " + ex.Message);
            }
            finally
            {
                // Uždaryti Word aplikaciją
                wordDoc.Close();
                wordApp.Quit();
            }
        }
    }
}
