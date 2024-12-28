using _2_lygis_egzaminas;

namespace Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void FirstBigChar_LeadAllSmallChar_ReturnsFirstCharBig()
        {
            //Arange
            string name = "aaaa";
            string expected = "Aaaa";

            //Act
            string actual =MenuItem.FirstBigChar(name);

            //Assert
            
            Assert.AreEqual(expected,actual);
        }
        [Test]
        public void OrderSum_LeadOrder_ReturnOrderSum()
        {
            //Arange
            Order order = new Order();
            order.OrderedDishes = new List<Dishes>();
            var dishes1 = new Dishes();
            dishes1.Price = 15M;
            var dishes2 = new Dishes();
            dishes2.Price = 10M;
            order.OrderedDishes.Add(dishes1);
            order.OrderedDishes.Add(dishes2);

            order.OrderedDrinks = new List<Drink>();
            var drink1 = new Drink();
            drink1.Price = 9.6M;
            var drink2 = new Drink();
            drink2.Price = 5.4M;
            order.OrderedDrinks.Add(drink1);
            order.OrderedDrinks.Add(drink2);
            decimal expected = 40M;

            //Act
            OrderOperations.OrderSum(order);


            //Assert

            Assert.AreEqual(order.Sum, expected);
        }


        [Test]
        public void ClientReceiptText_LeadReceiptClient_ReturnText()
        {
            //Arange
           ReceiptClient receiptClient = new ReceiptClient();
           Restorant restorant = new Restorant();
           receiptClient.Restorant = restorant;
            receiptClient.OrderCompleted = new DateTime(2022,12,31,15,30,15);
            receiptClient.Dishes = new List<Dishes>();
            var dishes1 = new Dishes();
            dishes1.Price = 1M;
            dishes1.Name = "A";
            var dishes2 = new Dishes();
            dishes2.Name = "B";
            dishes2.Price = 2M;
            receiptClient.Dishes.Add(dishes1);
            receiptClient.Dishes.Add(dishes2);

            receiptClient.Drinks = new List<Drink>();
            var drink1 = new Drink();
            drink1.Name = "C";
            drink1.Price = 3M;
            var drink2 = new Drink();
            drink2.Name = "D";
            drink2.Price = 4M;
            receiptClient.Drinks.Add(drink1);
            receiptClient.Drinks.Add(drink2);

            receiptClient.Sum = 10M;

           string expected = $"Geriausias restoranas\nIm. k. 123123123\nPVM moketojo kodas LT123123123\nPilies g. 54, Vilnius\n\nData: 31/12/2022 15:30:15\n\n            Kvitas\n\n   A\t\t1\n   B\t\t2\n   C\t3\n   D\t4\n----------------------------------------\n                 Suma:  10\n\n";

            //Act
            string actual=ReceiptClient.ClientReceiptText(receiptClient);


            //Assert

            Assert.AreEqual(actual, expected);

        }

        [Test]
        public void CreatTable_ReturnTableNumber()
        {
            //Arange
            
            int expected = 10;

            

            //Act
            Table[] table=TableOperation.CreateTables();
            int actual = table.Length;
 

            //Assert
      
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void DataLoad()
        {
            //Arange 
            string expected = "Gedas";

            //Act
            string path = @"C:\Users\gedasvalikonis\Documents\GitHub\valikongas\2 lygis egzaminas\waiter.json";
        List<Waiter> waiter = DataOperation.DataLoad<Waiter>(path);
            string actual = waiter[0].Name;



            //Assert

            Assert.AreEqual(expected, actual);
        }
    }
}