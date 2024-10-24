
////Nr. 1.
//int a = 10;
//int b = 5;
//int c = 12;

//int max = a;
//if (b > max)
//    max = b;
//if (c > max)
//    max = c;

//Console.WriteLine("The maximum value is: " + max);

////Eil.Nr. 3
//int counter = 0;
//while(counter<=10)
//{
//    Console.WriteLine("Count: " + counter);
//    counter++;
//}

////Nr. 5.
//string name1 = "John";
//string name2 = "john";
//if (name1.Equals(name2))
//{
//    Console.WriteLine("Name are the same.");
//}
//else
//{
//    Console.WriteLine("Names are different.");
//}


using System.Diagnostics;
using System.Text;

StringBuilder sb = new StringBuilder("Pradinis tekstas aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");

    // Pridėti tekstą
    sb.Append(", pridėtas tekstas");

    Console.WriteLine(sb.ToString());

    // Įterpti tekstą
    sb.Insert(8, " naujas");

    Console.WriteLine(sb.ToString());

    // Pašalinti dalį teksto
    sb.Remove(0, 7);

    Console.WriteLine(sb.ToString());

    // Pakeisti dalį teksto
    sb.Replace('a','x',20,10);


    Console.WriteLine(sb.ToString());


Stopwatch sw = new Stopwatch();
sw.Start();

sw.Stop();
TimeSpan laikas = sw.Elapsed;
Console.WriteLine(sw.Elapsed);
Console.WriteLine(laikas);

TimeSpan timeSpan = new TimeSpan();

