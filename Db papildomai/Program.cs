namespace Db_papildomai
{
    internal class Program
    {
        static void Main(string[] args)
        {
           using var dbContect = new GenericDBContext();
           using var orderRepository = new OderRepository (dbContect);
           using var orderItemRepository = new OrderItemRepository(dbContect);



        }
    }
}
