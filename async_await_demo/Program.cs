// See https://aka.ms/new-console-template for more information
using async_await_demo.Classes;

//Console.WriteLine("Hello, World!");


Example eg = new Example();


/*string ret = await eg.PrintSomethingAsync();
Console.WriteLine($"Returned from async method: {ret}");
Console.WriteLine("All done.");

Console.WriteLine("----------------");

var task = eg.DoSomethingASync();
Console.WriteLine("right after initilizing async method");
task.Wait();
Console.WriteLine("Task Done");*/



/*cancellation token example*/
Console.WriteLine("----------------------------------------");
Console.WriteLine("Task cancellation example");
Console.WriteLine("----------------------------------------");
/*using (CancellationTokenSource cts = new CancellationTokenSource())
{
    Task someTask = eg.DoSomethingWithCancellationAsync(cts.Token);  // start the task
    try
    {
        // demonstrating expiration of cancellation token
        await Task.Delay(6000); // delay further execution for 6 seconds
        cts.Cancel(); // cancel the operation after 6 seconds.
        // end of demonstrating expiration of cancellation token

        // demonstrating cancellation token
        *//*await Task.Delay(2000); // delay further execution for 2 seconds
        cts.Cancel(); // cancel the operation after 2 seconds.*//*
        // end of demonstrating expiration of cancellation token

        await someTask;
    }
    catch (OperationCanceledException oce)
    {
        Console.WriteLine($"Operation cancelled: {oce.Message}");
    }
}
*/


/* anonymouns functions */
await eg.DoSomethingWithAnonFuncAsync();



/* demonstrate exception in async methods*/
var exceptionMethod = eg.DemonstrateExceptionAsync();
await Task.Delay(1500);
Console.WriteLine("after initiating method with exception.");
//await exceptionMethod;
Console.WriteLine("after awaiting faulted task");



/* codebase goes async mode*/
AsyncMode asyncMode = new AsyncMode();
var someAsyncCodeTask = asyncMode.A();
await someAsyncCodeTask;
Console.WriteLine($"All async mode task completed. Status: {someAsyncCodeTask.Status}");
