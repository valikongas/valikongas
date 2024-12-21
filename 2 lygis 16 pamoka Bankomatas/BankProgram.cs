using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace _2_lygis_16_pamoka_Bankomatas
{
    public static class BankProgram
    {
        public static void BankProgramRun(string insertCardGuid)
        {
            string json = File.ReadAllText(@"C:\\Users\\gedasvalikonis\\Desktop\\bandau.json");
            var cardData = JsonSerializer.Deserialize<List<Card>>(json);

            //duomenu is failo uzkrovimas
            //List<Card> cardData = new List<Card>();
            //using (StreamReader cardDateRead = new StreamReader(@"C:\Users\gedasvalikonis\Desktop\testui.txt"))
            //{
            //    string? line = "";
            //    while ((line = cardDateRead.ReadLine()) != null)
            //    {
            //        string[] cardDataPerson = line.Split(',');
            //        List<decimal> operationPerson = new List<decimal>();
            //        if (cardDataPerson.Length > 8)
            //        {
            //            for (int i = 8; i < cardDataPerson.Length; i++)
            //            {
            //                operationPerson.Add(Convert.ToDecimal(cardDataPerson[i]));
            //            }
            //        }

            //        Card card = new Card
            //            (Convert.ToInt64(cardDataPerson[0]),
            //             cardDataPerson[1],
            //             cardDataPerson[2],
            //             cardDataPerson[3],
            //             Convert.ToInt32(cardDataPerson[4]),
            //             Convert.ToDecimal(cardDataPerson[5]),
            //             Convert.ToInt32(cardDataPerson[6]),
            //             DateOnly.Parse(cardDataPerson[7]),
            //             operationPerson);
            //        cardData.Add(card);
            //    }
            //}

            // patikrina ar kortele gera
            Card inputCard = new Card();
            int index = -1;
            foreach (Card card in cardData)
            {
                if (card.Guid == insertCardGuid)
                {
                    inputCard = card;
                    index++;
                    break;
                }
            }

            if (index < 0)
            {
                Console.WriteLine("Jūsų koretlė netinkama.");
                Environment.Exit(0);
            }

            //ivedame ir patikriname slaptazodi
            bool isPasswordTrue = false;
            while (!isPasswordTrue)
            {
                int attemps = 0;
                Console.WriteLine("Įveskite slaptažodį iš keturių skaičių. Jei nori išeiti spausk z.");
                string infputPassword = "";
                int number = 0;
                for (int i = 0; i < 4; i++)
                {
                    bool isNumber = false;
                    while (!isNumber)
                    {
                        var key = Console.ReadKey().KeyChar;
                        if (key == 'q')
                            break;
                        else
                            isNumber = int.TryParse(key.ToString(), out number);
                        Console.Clear();
                        Console.WriteLine("Įveskite slaptažodį iš keturių skaičių. Jei nori išeiti spausk z.");
                        for (int j = 0; j <= i; j++)
                        {
                            Console.Write("X");
                        }
                    }

                    if (isNumber == false)
                    {
                        Console.WriteLine("Jūs išėjote iš sistemos.");
                        Environment.Exit(0);
                    }
                    infputPassword = infputPassword + number;
                }

                if (Convert.ToInt32(infputPassword) == inputCard.Password)
                {
                    Console.Clear();
                    Console.WriteLine("Jus prisijungete.");
                    isPasswordTrue = true;
                    BankAccount(inputCard, cardData);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Įvestas slaptažodis neteisingas");
                    attemps++;
                    if (attemps > 2)
                    {
                        Console.WriteLine("Jūs tris kartus neteisingai įvedėte slaptažodį");
                        Environment.Exit(0);
                    }
                }
            }
        }
        public static void BankAccount(Card inputCard, List<Card> cardData)
        {
            //bankomato programa
            do
            {
                Console.WriteLine($"Vartotojas: {inputCard.Name} {inputCard.Surname}");
                Console.WriteLine($"Pinigų suma: {inputCard.CashSum} EUR.");
                Console.WriteLine();
                Console.WriteLine("Jūs galite rinktis:");
                Console.WriteLine("----------------------------");
                Console.WriteLine("1 - Pažiūrėti sąskaitos likutį.");
                Console.WriteLine("2 - Pažiūrėti paskutines 5 transakcijas");
                Console.WriteLine("3 - Pinigų išėmimas");
                Console.WriteLine("4 - Išeiti");
                var key = Console.ReadKey().KeyChar;
                if (key == '1')
                {
                    Console.Clear();

                }
                else if (key == '2')
                {
                    Console.Clear();
                    for (int i = 0; i < inputCard.Operation.Count && i < 5; i++)
                    {
                        if (inputCard.Operation[i] > 0)
                            Console.WriteLine($"Pinigų įnešimas {inputCard.Operation[i]}");
                        else
                            Console.WriteLine($"Pinigų išėmimas {inputCard.Operation[i]}");
                    }
                }
                else if (key == '3')
                {
                    Console.Clear();
                    Console.WriteLine("Pinigu isemimas");
                    Console.WriteLine("--------------------------------------");
                    Console.WriteLine();
                    Console.WriteLine($"Pinigu likutis {inputCard.CashSum} EUR.");
                    Console.Write("Kiek pinigu norite nuimti: ");
                    decimal cash = 0;
                    bool isParseCash = false;
                    while (!isParseCash)
                    {
                        isParseCash = decimal.TryParse(Console.ReadLine(), out cash);
                        if (!isParseCash)
                        {
                            Console.WriteLine("Ivedei ne skaiciu, ivesk teisinga skaiciu.");
                        }
                    }
                    if (cash > 1000 || cash > inputCard.CashSum || inputCard.OperationCount > 10)
                    {
                        Console.WriteLine("Operacija negalima");
                    }
                    else
                    {
                        inputCard.CashSum -= cash;
                        inputCard.Operation.Add(-cash);
                        if (inputCard.LastOperationDate == DateOnly.FromDateTime(DateTime.Now))
                        {
                            inputCard.OperationCount++;
                        }
                        else
                        {
                            inputCard.LastOperationDate = DateOnly.FromDateTime(DateTime.Now);
                            inputCard.OperationCount = 1;
                        }
                    }

                }
                else if (key == '4')
                {
                    Console.Clear();
                    Console.WriteLine("Pasiimkite kortele");
                    SaveData(inputCard, cardData);
                    Environment.Exit(0);
                }
                else
                {
                    Console.Clear();
                }
            }
            while (true);


        }

        public static void SaveData(Card inputCard, List<Card> cartData)

        {
            // duomenu issaugojimas

            string json = JsonSerializer.Serialize(cartData, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(@"C:\\Users\\gedasvalikonis\\Desktop\\bandau.json", json);
            //try
            //{

            //using (StreamWriter cardDateWriter = new StreamWriter(@"C:\Users\gedasvalikonis\Desktop\testui.txt"))
            //{
            //    string line = "";
            //    foreach (Card card in cartData)
            //    {
            //        if (inputCard.Guid == card.Guid)
            //        {

            //                    line = string.Join(',',
            //                       inputCard.CardNr.ToString(),
            //                       inputCard.Name,
            //                       inputCard.Surname,
            //                       inputCard.Guid,
            //                       inputCard.Password.ToString(),
            //                       inputCard.CashSum.ToString(),
            //                       inputCard.OperationCount.ToString(),
            //                       inputCard.LastOperationDate.ToString()) + "," +
            //                       string.Join(',', inputCard.Operation);
            //                }
            //                else
            //                {

            //                    line = string.Join(',',
            //                        card.CardNr.ToString(),
            //                        card.Name,
            //                        card.Surname,
            //                        card.Guid,
            //                        card.Password.ToString(),
            //                        card.CashSum.ToString(),
            //                        card.OperationCount.ToString(),
            //                        card.LastOperationDate.ToString()) + "," +
            //                        string.Join(',', card.Operation);
            //                }
            //                cardDateWriter.WriteLine(line);
            //            }
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine("Nepavyko duomenu irasyti. Ivyko klaida: " + ex);
            //    }
            
        }



    }
}
