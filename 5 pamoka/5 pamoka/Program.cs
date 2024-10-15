//// Nr. 1.1 Uzduotis
//string text = Console.ReadLine();
//char firstSymbol = text[0];
//string firstSymbol1 = Convert.ToString(firstSymbol);
//firstSymbol1 = firstSymbol1.ToUpper();
//char firstSymbol2 = Convert.ToChar(firstSymbol1);
//char[] word = text.ToCharArray();
//word[0] = firstSymbol2;
//Console.WriteLine(word);


//// Nr. 1.1 Uzduotis
//Console.Write("Ivesk zodi: ");
//string text = Console.ReadLine();
//string firstSymbol = char.ToUpper(text[0]).ToString();
//Console.WriteLine(firstSymbol+text.Substring(1));


////Nr. 2.1 Uzduotis
//string text = Console.ReadLine();

//char[] word = text.ToCharArray();
//if (text.Length >= 10)
//{
//    word[1] = 'g';
//    word[3] = 'b';
//    word[5] = '*';
//    word[7] = 'x';
//    word[9] = 'w';
// Console.WriteLine(word);
//}
//else
//Console.WriteLine("Ivesk ilgesni zodi");



////Nr. 3.1 Uzduotis
//string kodas="0";

//Console.Write("Ivesk penkiu simboliu teksta: ");
//string text = Console.ReadLine();
//if(text.Length == 5)
//{
//    Console.Write("Ivesk skaiciu kaip norio uzkoduoti: ");
//    kodas =  Console.ReadLine();
//}

//else
//Console.WriteLine("Ivedei teksta ne penkiu simboliu");

//text=text.Insert(1,kodas);
//text=text.Insert(3, kodas);
//text=text.Insert(5, kodas);
//text=text.Insert(7, kodas);
//text=text.Insert(9, kodas);

//Console.WriteLine("Uzkoduotas tekstas: "+text);


////Nr.2.1 Uzduotis
//Console.Write("Ivesk sakini:");
//string text = Console.ReadLine();
//text = text.Replace("a", "uo");
//text = text.Replace('i', 'e');
//Console.WriteLine(text);

////Nr.2.2 Uzduotis
//Console.Write("Ivesk sakini:");
//string text = Console.ReadLine();
//Console.Write("Ivesk zodi kuri nori pakeisti:");
//string text1 = Console.ReadLine();
//Console.Write("Ivesk kokiu zodziu nori pakeisti:");
//string text2 = Console.ReadLine();

//text = text.Replace(text1, text2);
//Console.WriteLine(text);

////Nr.2.3 Uzduotis
//Console.Write("Ivesk amziu:");
//int age = Convert.ToInt32( Console.ReadLine());
//int likometu = 90 - age;
//Console.WriteLine("tau iki 90 metu liko " + likometu + " metu;" + likometu*52+" savaiciu; "+ likometu*365+" dienu");


////Nr.3.1 Uzduotis
//Console.Write("Ivesk zodi:");
//string text = Console.ReadLine();
//if (text[0] == char.ToUpper(text[0]))
//    Console.WriteLine(text.ToUpper());
//else
//    Console.WriteLine(char.ToUpper(text[0])+text.Substring(1));


////Nr.3.2 Uzduotis
//Console.Write("Ivesk zodi:");
//string text = Console.ReadLine();
//if(text.Contains('a'))
//    Console.WriteLine(text + "-"+text.IndexOf('a'));
//else
//    Console.WriteLine("Simbolis a nerastas");




////Nr.3.3 Uzduotis
//Console.Write("Ivesk zodi:");
//string text = Console.ReadLine();
//if (text.Equals("labas"))
//{
//    string atvirksciai = new string(text.Reverse().ToArray());
//    Console.WriteLine(atvirksciai);
//}
//else
//    Console.WriteLine(text);




//Nr.6 Uzduotis
Console.Write("Ivesk pirma varda: ");
string vardas1 = Console.ReadLine();
Console.Write("Ivesk antras varda: ");
string vardas2 = Console.ReadLine();
int sum1 = 0;
int sum2 = 0;
int suma = 0;

for (int i = 0; i < vardas1.Length - 1; i++)
{
    sum1 = sum1 + "tikroji meile".Count(x => x == vardas1[i]);

}

for (int i = 0; i < vardas2.Length - 1; i++)
{
    sum2 = sum2 + "tikroji meile".Count(x => x == vardas2[i]);

}

suma = Convert.ToInt32((Convert.ToString(sum1) + Convert.ToString(sum2)));

switch (suma)
{
    case (< 30 or > 90):
        Console.WriteLine("vienas kitam puikiai tinka");
        break;
    case (>= 30 and <= 50):

        Console.WriteLine("Vienas kitam tinka vidutiniskai");
        break;
    default:
        Console.WriteLine("Vienas kitam netinka");
        break;
}