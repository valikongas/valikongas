using System.Net.Http.Headers;

namespace _2_lygis_15_pamoka_Interface_prak
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Nr.1-----------------------------
            Bass bass1 = new Bass("pirmas eserys",10);
            Cat cat1= new Cat("Pirmas katinas",15);
            Dog dog1 = new Dog("Pirmas suo", 20);
            Carp carp1 = new Carp("Pirmas karpis", 3);
            Carp carp2= new Carp("Antras karpis", 5);
            Carp carp3 = new Carp("Trecias karpis", 2);
            List<IAnimal> animal =new  List <IAnimal>
            {
                bass1,
                cat1,
                dog1,
                carp1,
                carp2
            };
            
            foreach (var item in animal)
            {
                item.Eat();
                
            }
            var mammal= new List<IMammal> { cat1,dog1};
            foreach (var item in mammal)
            {
                item.GiveBirth();
            }
            var fish=new List<IFish> { bass1,carp1,carp2};
            foreach (var item in fish)
            {
                item.Swim();
            }

            var zuvys = new List<Carp> { carp1, carp2, carp3 };

            zuvys.Sort();

            foreach (var item in zuvys)
            {
                Console.WriteLine(item.Name+" "+item.Weight);
            }



            //Nr.2---------------------------
            Triangle trikampis1 = new Triangle("trikampis", 10.0, 5.0);
            Triangle trikampis2 = new Triangle("trikampis", 20.0, 4.0);
            Quadrilateral kvadratas1 = new Quadrilateral("kvadratas", 5.0);
            Quadrilateral kvadratas2 = new Quadrilateral("kvadratas", 10.0);
            Pentagof penkiakampis1 = new Pentagof("penkaikampis", 5.0);
            Pentagof penkiakampis2 = new Pentagof("penkaikampis", 10.0);
            Hexagon sesiakampis1 = new Hexagon("sesiakampis", 5.0);
            Hexagon sesiakampis2 = new Hexagon("sesiakampis", 10.0);

            var figuros=new List<CompareArea>
            {trikampis1,trikampis2,kvadratas1,kvadratas2,penkiakampis1, penkiakampis2, sesiakampis1, sesiakampis2 }
                ;
            foreach (var item in figuros)
            {
                item.Area=item.GetArea();
            }
            

            figuros.Sort();

            foreach (var item in figuros)
            {
                Console.WriteLine(item.Name + " " + item.Area);
            }


        }
    }
}
