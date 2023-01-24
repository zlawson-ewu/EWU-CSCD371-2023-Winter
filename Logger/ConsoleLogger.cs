using System;
using System.IO;

namespace Logger;

internal class ConsoleLogger : BaseLogger
{
    public override void Log(LogLevel logLevel, string message)
    {
        string date = DateTime.Now.ToString();
        Console.WriteLine($" {date} {ClassName} {logLevel} : {message}");
    }
}