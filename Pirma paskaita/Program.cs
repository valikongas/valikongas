// See https://aka.ms/new-console-template for more information
using System;

Console.WriteLine("   /\\");
Console.WriteLine("  /  \\");
Console.WriteLine(" /    \\");
Console.WriteLine("/______\\");

Console.WriteLine("     *****");
Console.WriteLine("   **     ** ");
Console.WriteLine(" **         ** ");
Console.WriteLine("**    Hello   **");
Console.WriteLine("**     from   **");
Console.WriteLine(" **    C#    **");
Console.WriteLine("   **     ** ");
Console.WriteLine("     *****");

Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("   /\\");
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("  /  \\");
Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine(" /    \\");
Console.ForegroundColor = ConsoleColor.DarkMagenta;
Console.WriteLine("/______\\");
Console.ForegroundColor = ConsoleColor.White;

Console.ForegroundColor = ConsoleColor.Blue;
Console.WriteLine("  / \\       / \\");
Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine(" /    \\       /   \\");
Console.ForegroundColor = ConsoleColor.DarkBlue;
Console.WriteLine("  \\    \\       /   /");
Console.ForegroundColor = ConsoleColor.DarkCyan;
Console.WriteLine(" /    \\       /   \\");
Console.ForegroundColor = ConsoleColor.White;


//-----------------------------------------------------
// Nr. 5
String vaisius="Obuolys";
String kaina = "2 eur";
int kiekis = 5;
Console.WriteLine("Preke: "+vaisius);
Console.WriteLine("Kiekis: " + kiekis);
Console.WriteLine("Kaina: " + kaina);

//-----------------------------------------------------
// Nr. 6
String vardas = "Vardenis Pavardenis";
String pareigos = "Software Developer";
String pastas = "johndoe@example.com";
String phone = "+1 123-456-7890";
int amzius = 28;

Console.WriteLine("Vardas: " + vardas);
Console.WriteLine("Amzius: " + amzius);
Console.WriteLine("Pareigos " + pareigos);
Console.WriteLine("E. Pastas : " + pastas);
Console.WriteLine("Tel.: " + phone);