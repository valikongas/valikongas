////Nr. 1.1
//int i = 0;
//while(i<=4)
//{  
//    i++;
//    Console.WriteLine(i);

//}
//while (i >=1 )
//{
//    Console.WriteLine(i);
//    i--;
//}

////Nr. 1.2
//int i = 2;
//while (i <= 10)
//{

//    Console.WriteLine(i);
//    i+=2;
//}
//i = 1;
//while (i <= 9)
//{

//    Console.WriteLine(i);
//    i += 2;
//}


////Nr.1.3
//while (Convert.ToInt32(Console.ReadLine()) > 100)
//{ }
//while (Convert.ToInt32(Console.ReadLine()) >= 0)
//{ }

//////Nr.2.1
//int skaicius = 1;


//while (skaicius >= 0)
//{ 
//skaicius = Convert.ToInt32(Console.ReadLine());
//    int suma = 1;

//    while (skaicius > 0)
//    {
//        suma = suma * skaicius;
//        skaicius--;
//    }
//    Console.WriteLine("faktorialas " + suma);
//}


////Nr.2.2
//Console.Write("Ivesk teigiama skaiciu: ");
//string skaicius = Console.ReadLine();
//int i= 0;
//while (i < skaicius.Length)
//{
//    if (i != skaicius.Length - 1)
//    {
//        Console.Write(skaicius[i] + ",");
//        i++;
//    }
//    else
//    {
//        Console.Write(skaicius[i] + ".");
//        i++;
//    }
//    }

////Nr.2.3
//Console.Write("Ivesk teigiama skaiciu: ");
//int skaicius = Convert.ToInt32( Console.ReadLine());
//int i = 1;

//while (i <= skaicius)
//{
//    int j = i;
//   while (j >= 1)
//   {
//       Console.Write("*");
//       j--;
//   }
//    Console.WriteLine("");
//    i++;
//}

//Nr.5
int ciklas = 0;
Random skaicius = new Random();
int atsitiktinis = skaicius.Next(1, 100);
bool atspejai = false;
Console.Write("Sugalvojau skaiciu, nuo 1 iki 100. Atspek.Spek skaiciu: ");
do
{
    ciklas++;
    int skaicius1 = Convert.ToInt32(Console.ReadLine());
    if (skaicius1 == atsitiktinis)
    {
        Console.WriteLine("Atspejai is "+ciklas+ " karto");
        atspejai = true;
    }
    else if (skaicius1 > atsitiktinis)
    {
        Console.WriteLine("Skaicius per didelis");
    }
    else
    {
        Console.WriteLine("Skaicius per mazas");
    }
}
while (!atspejai);


