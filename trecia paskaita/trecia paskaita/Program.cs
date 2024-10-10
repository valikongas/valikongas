

//int valandos = Convert.ToInt32(Console.ReadLine());
//if (valandos < 12)
//    Console.WriteLine("Gero ryto");
//else if (valandos >= 12 && valandos < 16)
//    Console.WriteLine("Geros dienos");
//else
//    Console.WriteLine("Gero vakaro");


////Uzduotis Nr.4
//Console.Write("Ivesk amziu: ");
//int amzius = Convert.ToInt32(Console.ReadLine());
//if (amzius<18)
//    Console.WriteLine("Jums priklauso nepilnamecio akcija");
//else if(amzius>=18 && amzius<65)
//    Console.WriteLine("Jus esate suauges");
//else
//    Console.WriteLine("Jums priklauso senjoro akcija");

////Uzduotis Nr.5
//Console.Write("Ivesk metus: ");
//int metai = Convert.ToInt32(Console.ReadLine());
//if((metai%4 == 0 && metai%100 != 0)||metai%400 ==0)
//    Console.WriteLine("Tai yra keliamieji metai");
//else
//    Console.WriteLine("Tai nera keliamieji metai");

////Uzduotis Nr.6
//Console.Write("Ivesk skaiciu: ");
//int skaicius = Convert.ToInt32(Console.ReadLine());
//if (skaicius % 3 == 0 && skaicius % 5 == 0 )
//    Console.WriteLine("BazingaPop");
//else if (skaicius%3==0)
//    Console.WriteLine("Bazinga");
//else if (skaicius%5 == 0)
//Console.WriteLine("Pop");
//else
//    Console.WriteLine(skaicius);

////Uzduotis Nr.7
//Console.Write("Ivesk pirma skaiciu: ");
//int skaicius1 = Convert.ToInt32(Console.ReadLine());
//Console.Write("Ivesk antra skaiciu: ");
//int skaicius2 = Convert.ToInt32(Console.ReadLine());
//if(skaicius1>0 && skaicius2>0)
//    Console.WriteLine("Abu skaiciai yra teigiami");
//else if (skaicius1 > 0 || skaicius2 > 0)
//    Console.WriteLine("Vienas is skaiciu yra teigiamas");
//else
//    Console.WriteLine("Ne vienas skaicius nera teigiamas");


////Uzduotis Nr.8
//Console.Write("Ivesk pirma skaiciu: ");
//int skaicius1 = Convert.ToInt32(Console.ReadLine());
//Console.Write("Ivesk antra skaiciu: ");
//int skaicius2 = Convert.ToInt32(Console.ReadLine());
//Console.Write("Ivesk trecia skaiciu: ");
//int skaicius3 = Convert.ToInt32(Console.ReadLine());
//int sum = 0;
//if (skaicius1 > 0 && skaicius2 > 0)
//{ sum = skaicius1 + skaicius2;
//    if (skaicius3 > 0)
//        sum += skaicius3;
//}
//else if (skaicius1 > 0 && skaicius3 > 0)
//    sum = skaicius1 + skaicius3;
//else if (skaicius2 > 0 && skaicius3 > 0)
//    sum = skaicius2 + skaicius3;
//else
//    Console.WriteLine("Neimanoma suskaiciuoti sumos");
//if(sum !=0)
//Console.WriteLine("Suma yra: "+sum);

////Uzduotis Nr.8-2
//Console.Write("Ivesk data: ");
//string men = Console.ReadLine().Substring(5,2);
//if (men=="01" || men=="02" || men=="03")
//    Console.WriteLine("Saltas laikotarpis");
//else if (men == "06" || men == "07" || men == "08")
//    Console.WriteLine("Karstas laikotarpis");
//else
//    Console.WriteLine("Vidutinio laikotarpio menuo");


// Uzduotis Nr.10
String preke1 = "1. Pienas";
int kaina1 = 10;
String preke2 = "2. Duona";
int kaina2 = 15;
String preke3 = "3. Kiausiniai";
int kaina3 = 18;
double nuolaida = 1;
double moketi = 0;
string lojalumas = "Ne";
Console.WriteLine(preke1+" "+kaina1+"EUR");
Console.WriteLine(preke2+" "+kaina2+"EUR");
Console.WriteLine(preke3+" "+kaina3+"EUR");
Console.Write("Pasirink pirma preke: ");
int pasirinkimas1 = Convert.ToInt32(Console.ReadLine());
if (pasirinkimas1 == 1)
    moketi = kaina1;
else if (pasirinkimas1 == 2)
    moketi = kaina2;
else
    moketi = kaina3;
Console.Write("Pasirink antra preke: ");
int pasirinkimas2 = Convert.ToInt32(Console.ReadLine());
if (pasirinkimas2 == 1)
    moketi = moketi+kaina1;
else if (pasirinkimas2 == 2)
    moketi = moketi+kaina2;
else
    moketi = moketi+kaina3;

if (pasirinkimas1 == pasirinkimas2)
    nuolaida = 0.9;
Console.Write("Ar turi lojalumo kortele: ");
lojalumas = Console.ReadLine();
if (lojalumas == "Taip")
    nuolaida = nuolaida*0.9;
Console.WriteLine("Moketina suma: "+moketi*nuolaida);



