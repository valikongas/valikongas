namespace testavimas
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetTextLeght_WithLeadWhiteSpaceText_RturnsLenght()
        {
            // Arrange
            string input = "   gedas   ";
            int expected = 6;

            //Act
            int actual= Methods.GetTextLenght(input);


            Assert.AreEqual(expected,actual);
        }
    }
}