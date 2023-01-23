using System;
using System.IO;

namespace Logger;

internal class FileLogger : BaseLogger
{
    private string? _Path;

    public FileLogger(string? path)
    {
        _Path = path;
    }

    public override void Log(LogLevel logLevel, string message)
    {
        StreamWriter writer = File.AppendText(_Path);
        string date = DateTime.Now.ToString();
        writer.WriteLine($" {date} {ClassName} {logLevel} : {message}");
        writer.Dispose();
    }
}