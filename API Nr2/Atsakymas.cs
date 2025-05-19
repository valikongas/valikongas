namespace API_Nr2
{
    public class Atsakymas : IAtsakymas
    {
        public string Atsakymas1 { get; set; }
        public Atsakymas(string atsakymas1)
        {
            Atsakymas1 = atsakymas1;
        }

        public void AtsakymoFormavimas(string message)
        {
            Atsakymas1 = message + "AAAAAAAAAAA";
        }
    }
}
