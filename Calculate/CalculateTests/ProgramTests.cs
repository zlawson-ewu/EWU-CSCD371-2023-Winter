using Calculate;

namespace CalculateTests;

[TestClass]
public class ProgramTests
{
    [TestMethod]
    public void Program_SetAndInvokeDelegateProperties_Success()
    {
        string testWriteLine = "WriteLine test string.";
        string testReadLine = "ReadLine string to be read";

        void testActionWriteLine(string testLineOut) { Console.WriteLine(testLineOut); }
        string testFunctionReadLine() { return testReadLine; }

        Program program = new() { WriteLine = testActionWriteLine, ReadLine = testFunctionReadLine };

        var stringWriter = new StringWriter();
        Console.SetOut(stringWriter);
        program.WriteLine(testWriteLine);

        Assert.AreEqual<string>("WriteLine test string.", stringWriter.ToString().Trim());
        Assert.AreEqual<string>("ReadLine string to be read", program.ReadLine()!);
    }
}