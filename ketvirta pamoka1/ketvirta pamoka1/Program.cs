////1 pavyzdys
//int day = 4;
//switch (day)
//{
//    case 1:
//        Console.WriteLine("Pirmadienis");
//        break;
//    case 2:
//        Console.WriteLine("Antradienis");
//        break;
//    case 3:
//        Console.WriteLine("Trečiadienis");
//        break;
//    default:
//        Console.WriteLine("Nežinoma diena");
//        break;
//}


//// 1.1 uzduotis
//Console.Write("Ivesk savaites diena: ");
//int weekDay = Convert.ToInt32(Console.ReadLine());
//string diena = weekDay switch
//{
//    1 => "Pirmadienis",
//    2 => "Antradienis",
//    3 => "treciadienis",
//    4 => "ketvirtadienis",
//    5 => "Penktadinis",
//    6 => "Sestadienis",
//    7 => "Sekmadienis",
//    _ => "Nesamone ivedei",

//};

//Console.WriteLine(diena);




//// 1.2 uzduotis
//Console.Write("Ivesk amziu: ");
//int age = Convert.ToInt32(Console.ReadLine());
//string amzius = age switch
//{
//    >=7 and <=18 => "Moksleivis",
//    >18 and <=25 => "Studentas",
//    >25 and <=65 => "Darbuotojas",
//    >65 => "Pensininkas",
//    _ => "Vaikas",

//};
//Console.WriteLine(amzius);



//// 1.3 uzduotis
//using System;

//Console.Write("Ivesk data: ");
//string menesis = Console.ReadLine();
//int monatNo = Convert.ToInt32(menesis.Substring(5));
//string monatName = monatNo switch
//{
//    <= 3  => "Pirmas ketvirtis",
//    > 3 and <= 5 => "Antras ketvirtis",
//    > 5 and <= 8 => "Trecias ketvirtis",
//    > 8 and <=12 => "Ketvirtas ketvirtis",
//    _ => "Nesamone ivedei"

//};
//Console.WriteLine(monatName);




//// 2.1 uzduotis
//using System;

//Console.Write("Ivesk figura, kur 1-keturkampis, 2-apkritimas, 3-kvadratas: ");
//int figura = Convert.ToInt32(Console.ReadLine());
//double plotas = 0;
//switch (figura)
//{
//    case 1:
//        Console.Write("Ivesk pirma krastine :");
//        int krastine1 = Convert.ToInt32(Console.ReadLine());
//        Console.Write("Ivesk antra krastine :");
//        int krastine2 = Convert.ToInt32(Console.ReadLine());
//        plotas = krastine1 * krastine2;
//        break;
//    case 2:
//        Console.Write("Ivesk spinduli :");
//        int spindulys = Convert.ToInt32(Console.ReadLine());
//        plotas = spindulys * spindulys * Math.PI;
//        break;
//    case 3:
//        Console.Write("Ivesk krastine :");
//        int krastine3 = Convert.ToInt32(Console.ReadLine());
//        plotas = krastine3 * krastine3;
//        break;
//    default:
//        Console.WriteLine("Nesamone ivedei");
//        break;
//}

//Console.WriteLine(plotas);


//Nr. 3.3. Uzduotis

double USDEUR = 0.9;
double USDGPB = 0.85;
double USDJPY = 130.9;

Console.Write("Ivesk valiuta (EUR, GPB, USD, JPY): ");
string valiuta = Console.ReadLine().Substring(0, 3).ToUpper();
Console.Write("Ivesk kieki: ");
double kiekis = Convert.ToDouble(Console.ReadLine());

switch (valiuta)
{
    case "USD":
        Console.WriteLine(Math.Round(kiekis * USDEUR,2) + " EUR");
        Console.WriteLine(Math.Round(kiekis * USDGPB,2) + " GPB");
        Console.WriteLine(Math.Round (kiekis * USDJPY,2) + " JPY");
        break;
    case "EUR":
        Console.WriteLine(Math.Round(kiekis / USDEUR,2) + " USD");
        Console.WriteLine(Math.Round(kiekis / USDEUR,2) * USDGPB + " GPB");
        Console.WriteLine(Math.Round (kiekis / USDEUR,2) * USDJPY + " JPY");
        break;
    case "GPB":
        Console.WriteLine(Math.Round(kiekis / USDGPB*USDEUR,2) + " EUR");
        Console.WriteLine(Math.Round(kiekis / USDGPB,2)+ " USD");
        Console.WriteLine(Math.Round(kiekis / USDGPB * USDJPY,2) + " JPY");
        break;
    case "JPY":
        Console.WriteLine(Math.Round(kiekis / USDJPY * USDEUR,2) + " EUR");
        Console.WriteLine(Math.Round(kiekis / USDJPY*USDGPB,2) + " GPB");
        Console.WriteLine(Math.Round(kiekis / USDJPY,2) + " USD");
        break;


}



