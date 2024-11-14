namespace _3_pamoka__paveldimumas_ir_Virtual_metod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Manager manager1 = new(35);
            
            Console.WriteLine(manager1.Name + " " + manager1.Salary + " EUR." + " Jis turi pavaldiniu " + manager1.Employees);
            manager1.Name = "Petras Petraitis";
            manager1.Salary = 1000;
            manager1.Greeting(manager1.Name);
            Console.WriteLine(manager1.Name + " " + manager1.Salary + " EUR."+" Jis turi pavaldiniu "+manager1.Employees);
            Programer programer1 = new Programer("Tomas", 1500,"Basic" );
            Console.WriteLine(programer1.Name + " " + programer1.Salary + " EUR." + " Jis programuoja " + programer1.ProgrammingLanguage);
            programer1.ProgrammingLanguage = "Basic";
            Console.WriteLine(programer1.Name + " " + programer1.Salary + " EUR." + " Jis programuoja " + programer1.ProgrammingLanguage);
            
          
            List<Programer> programeriai = [new Programer("Pirmas", 1100, "C++")];
            programeriai[0].Greeting(programeriai[0].Name);
            programeriai.Add(new Programer("Antras", 2200, "D++"));
            programeriai.Add(new Programer("Trecias", 3300, "E++"));
        
            manager1.Greeting(manager1.Name);
            manager1.Printmetodas(manager1.Name,programeriai);


            
        }
    }
}
