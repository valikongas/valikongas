using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace testas
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            //Arange
            int[] pirmasPaketas = { 2, 4, 2, 4, 8 };
            int[] antrasPaketas = { -2, -4, -2, -4, -8 };
            double expected = 4.0;
            double expected2 = -4.0;

            //Act
            double actual=Skaiciavimai.AverageCalc(pirmasPaketas);
            double actual2 = Skaiciavimai.AverageCalc(antrasPaketas);


            Assert.AreEqual(expected,actual);
            Assert.AreEqual(expected2, actual2);
        }
        
        [Test]
        public void Test2()
        {
            //Arange
            int[] pirmasPaketas = { 2, 4, 2, 4, 8 };
            int[] antrasPaketas = { -2, 2,-4, -2, -4, -8 };
            int[] expected = { 2, 4, 2, 4, 8 };
           int[] expected2 = {2};

            //Act
            int[] actual = Skaiciavimai.Positiv(pirmasPaketas);
            int[] actual2 = Skaiciavimai.Positiv(antrasPaketas);


            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expected2, actual2);
        }



    }


}


