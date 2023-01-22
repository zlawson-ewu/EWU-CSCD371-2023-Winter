using System;
using System.IO;

namespace Logger
{
    public class LogFactory
    {
        private string? _Path;
        public void ConfigureFileLogger(string path)
        {
            if (path is not null)
            {
                _Path = path;
            }
        }

        public BaseLogger CreateLogger(string className)
        {
            return new FileLogger(_Path) { ClassName = className };
        }
    }
}
