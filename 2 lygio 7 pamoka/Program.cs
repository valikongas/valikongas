namespace _2_lygio_7_pamoka
{
    internal class Program
    {
        static void Main(string[] args)
        {
             
            // jei Validate class ne Static
            //     Validation<int> validation = new Validation<int>();
             //     validation.ValidationMetod(5);

            //jei Validate class static
            Validation<int>.ValidationMetod(5);  

            ShowValues<int,string> showValues = new ShowValues<int,string>();
            showValues.KeliTipai(5, "antanas");

          

        }
    }
}
