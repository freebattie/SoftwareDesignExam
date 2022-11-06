

using Presentation.Utils;

namespace SoftwareDesignExamTest {
    internal class PresentationTests {
    
        [Test]
        public void IntInputTest() {
            var sr = new StringReader("x");
            Console.SetIn(sr);
            var input = Reader.ReadIntAsString();
           
            
            sr = new StringReader("2");
            Console.SetIn(sr);
            var stringInput = Reader.ReadIntAsString();

            //Test invalid input
            Assert.That(input.Equals("ERROR"));
            //Test Valid Input
            Assert.That(stringInput.Equals("2"));


            //var standarInputStream = new StreamReader(Console.OpenStandardInput());
            //Console.SetIn(standarInputStream);

        }
      
        [Test]
        public void ValidStringInputTest() {
            var sr = new StringReader("Testname");
            Console.SetIn(sr);
            var stringInput = Reader.ReadString();
            
            Assert.That(stringInput.Equals("Testname"));
           

        }
        [Test]
        public void WriterTest() {
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            
            Writer.PrintLine("Hello World");

            Assert.AreEqual("Hello World\r\n", stringWriter.ToString());


        }

    }
}
