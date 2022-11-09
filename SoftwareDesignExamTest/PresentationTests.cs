

using Presentation.Utils;

namespace SoftwareDesignExamTest {
    internal class PresentationTests {
        
        /// <summary>
        /// Tester at ReadIntAsString retunere "ERROR" hvis verdien ikke er et gyldig int
        /// </summary>
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


           
        }
      
        /// <summary>
        /// Test at ReadString kan lese en streng fra input 
        /// </summary>
        [Test]
        public void ValidStringInputTest() {
            var sr = new StringReader("Testname");
            Console.SetIn(sr);
            var stringInput = Reader.ReadString();
            
            Assert.That(stringInput.Equals("Testname"));
           

        }
        /// <summary>
        /// Test at PrintLine printer string til outputten
        /// </summary>
        [Test]
        public void WriterTest() {
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            
            Writer.PrintLine("Hello World");

            Assert.That(stringWriter.ToString().Equals("Hello World\r\n"));


        }

    }
}
