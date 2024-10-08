
string vardas = "gedas";
int X = vardas.Length;
Console.WriteLine(X);

char pirmas = vardas[0];
char paskutinis = vardas[vardas.Length - 1];
Console.WriteLine(pirmas);
Console.WriteLine(paskutinis);


string vardasNew = vardas.Replace('g', 'G');
Console.WriteLine(vardasNew);

Console.WriteLine("Ivesk zodi:");
string text1 = Console.ReadLine();
Console.WriteLine("Ivesk indeksa:");
int index = Int32.Parse(Console.ReadLine());
Console.WriteLine(text1[index - 1]);
Console.WriteLine(text1.Length);

string s = "9999999999999999999999999";
Console.WriteLine(s.Substring(12).Trim().Replace('a', 'b'));
Console.WriteLine(s.Substring(0, 4));

Console.WriteLine(s.IndexOf("an"));
Console.WriteLine(s.IndexOf('M'));
string ss = string.Concat(s, "Valikonis");
Console.WriteLine(ss);


int s1 = Convert.ToInt32(s);