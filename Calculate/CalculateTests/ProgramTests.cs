using Calculate;

namespace CalculateTests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void Program_SetsAndInvokesProperties_Success()
        {
            string testWriteLine = "WriteLine test string.";
            string testReadLine = "ReadLine string to be read";

            void testActionWriteLine(string testLineOut) { Console.WriteLine(testLineOut); }
            string testActionReadLine() { return testReadLine; }

            Program program = new() { WriteLine = testActionWriteLine, ReadLine = testActionReadLine };

            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            program.WriteLine(testWriteLine);

            Assert.AreEqual<string>("WriteLine test string.", testWriteLine);
            Assert.AreEqual<string>("ReadLine string to be read", program.ReadLine()!);
        }
    }
}