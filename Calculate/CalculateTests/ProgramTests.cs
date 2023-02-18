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

            string testActionWriteLine(string testLineOut) { return testLineOut; }
            string testActionReadLine(string testLineIn) { return testLineIn; }

            Program program = new() { WriteLine = testActionWriteLine, ReadLine = testActionReadLine };

            string writeLineOutput = program.WriteLine(testWriteLine);
            string testStoreReadLine = program.ReadLine(testReadLine);

            Assert.AreEqual<string>("WriteLine test string.", writeLineOutput);
            Assert.AreEqual<string>("ReadLine string to be read", testStoreReadLine);

        }
    }
}