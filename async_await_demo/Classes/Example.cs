namespace async_await_demo.Classes
{
    public class Example
    {

        public async Task<string> PrintSomethingAsync()
        {
            Console.WriteLine("Before awaiting.");
            await Task.Delay(2000).ConfigureAwait(false); // simulating time consuming operation. 
            Console.WriteLine("After awaiting");    
            return "returned val from async method.";
        }


        public async Task DoSomethingASync()
        {
            Console.WriteLine("Inside async method");
            await Task.FromResult("some task");  // simulating task that instantly returns completed tasks 
            Console.WriteLine("before waiting 3 seconds");
            await Task.Delay(3000);
            Console.WriteLine("End of async method");
        }

        public async Task DoSomethingWithCancellationAsync(CancellationToken cts)
        {
            try
            {
                Console.WriteLine("Inside DoSomethingWithCancellationAsync method.");
                await Task.Delay(5000, cts);
                Console.WriteLine("Still inside DoSomethingWithCancellationAsync method, after long running operation.");
            }
            catch(OperationCanceledException oce)
            {
                Console.WriteLine(oce.Message);
            }
        }


        public async Task DoSomethingWithAnonFuncAsync()
        {
            Func<Task<string>, Task<int>> getStringLengthDelegateAsync = async (str) =>
            {
                string task = await str;  // await parameter which is of type task
                return task.Length;
            };
            async Task<string> someStringLocalFuncAsync() // local function can be asynchronous as well
            {
                await Task.Delay(2000); // simulating some operation
                return "something";
            }
            Task<int> getLengthTask = getStringLengthDelegateAsync(someStringLocalFuncAsync());
            int len = await getLengthTask; // unwrapping operation by await. Task<int> --> int
            Console.WriteLine($"Length of string is: {len}");
        }

        public async Task<string> DemonstrateExceptionAsync()
        {
            await Task.Delay(1000); // simulating some operation
            Console.WriteLine("after some operation.");
            MethodWithExceptionAsync(); // not awaiting
            Console.WriteLine("after exception in other task.");
            throw new Exception(message:"exception inside the method.");
            return "retured from DemonstrateExceptionAsync";
        }

        public async Task MethodWithExceptionAsync()
        {
            await Task.Delay(500); // simulating some operation
            Console.WriteLine("inside MethodWithExceptionAsync method.");
            throw new Exception(message:"Exception outside the method.");
        }
    }
}
