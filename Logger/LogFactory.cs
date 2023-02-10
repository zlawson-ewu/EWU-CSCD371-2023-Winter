namespace Logger;

public interface ILogFactory<TLogger> where TLogger : ILogger
{
    TLogger CreateLogger(string logSource);
}


public class LogFactory<TLogger, TLogFactory> where TLogger: ILogger
    where TLogFactory : ILogFactory<TLogger>, new()
{
    public string? FileName { get; set; }
    

    public TLogger CreateLogger(string logSoure)
    {
        
        return new TLogFactory().CreateLogger(logSoure);
    }
    public void ConfigureFileLogger(string fileName) => FileName=fileName;

}
