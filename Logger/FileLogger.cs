using System;
using System.IO;

namespace Logger
{
    internal class FileLogger : BaseLogger
    {
        private string? path;

        public FileLogger(string? path)
        {
            this.path = path;
        }

        public override void Log(LogLevel logLevel, string message)
        {
            FileStream stream = File.OpenWrite(path);
            StreamWriter writer = new StreamWriter(stream);
            string date = DateTime.Now.ToString();
            string className = this.GetType().Name;
            writer.WriteLine($" {date} {nameof(className)} {logLevel} : {message}");
            writer.Dispose();
        }
    }
}