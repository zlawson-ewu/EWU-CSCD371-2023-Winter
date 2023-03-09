namespace Week._09.TaskParallelLibrary;

[TestClass]
public class MultithreadingTests {
    public void PrintOutput_OnReadLine_Success() {
        CancellationTokenSource tokenSource = new();

        void WriteToConsole(CancellationToken token) {
            while (!token.IsCancellationRequested) Console.Write('-');
        }

        try {
            Task task = Task.Factory.StartNew(() => {
                // throw new NotImplementedException();
                while (!tokenSource.Token.IsCancellationRequested) {
                    Console.Write('-');
                }
            }, tokenSource.Token);
            Console.ReadLine();
            tokenSource.Cancel();
            task.Wait();
        }
        catch (Exception exception) {
            Console.WriteLine(exception);

        }
    }
}