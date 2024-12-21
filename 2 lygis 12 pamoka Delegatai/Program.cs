namespace _2_lygis_12_pamoka_Delegatai
{
    internal class Program
    {

        private delegate string StringOperation (string firstNamem, string lastName, string age);
        private delegate int IntengerOperation(int value1, int value2);
        private delegate List<int> ListOperation (List<int> list, int step);
        private delegate string TypeOperation<T> (T i);
        

         static void Main(string[] args)
        {
            //var stringOperation1 = new StringOperation(StringConcat);
            StringOperation stringOperation1 = StringConcat;

            string id = stringOperation1("Gedas", "valikonis", "45");
            Console.WriteLine(id);
            
            var intOperation1 = new IntengerOperation(InengerSum);
            int suma = intOperation1(5, 10);
            Console.WriteLine(suma);

            var listOperation= new ListOperation(ListOperation1);
            List<int> sarasas = new List<int>{ 1,2,3,4,5,6,7,8};
            List<int> list = listOperation(sarasas,3);
            foreach(int i in list)
                Console.WriteLine(i);

            var typeOperation1 = new TypeOperation<string>(GetType1);
      
            string tipas = typeOperation1("Gedas");
            Console.WriteLine(tipas);



        }
    
    public  static string StringConcat(string firstName, string lastName, string age)
        {
            return string.Concat(firstName," ", lastName,", amzius: ", age);
        }
        public static int InengerSum(int number1, int number2)
        {
            return number1+number2;
        }

        public static List<int> ListOperation1(List<int> list, int step)
        {
            List<int> newList=new List<int>();
            for (int i = 0; i < list.Count; i=i+step)
            {
                newList.Add(list[i]);
            }
            return newList;
        }

        public static string GetType1<T>(T t)
        {
            return t.GetType().ToString();
        }

        public static string Tekstas(string text)
        {
            return text+" atsakymas";
        }
    }
}
