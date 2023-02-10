namespace Logger;

public class FileLoggerFactory : ILogFactory<FileLogger>
{
    private string? _FileName;
    public string FileName { 
        get => _FileName!;
        init
        {
            _FileName=value??throw new ArgumentNullException(nameof(value));
        }
    }

    public FileLoggerFactory(string fileName)
    {
        FileName=fileName;
    }

    public FileLogger CreateLogger(string logSource)
    {
        return new FileLogger(logSource, FileName);
    }
}