using System;   
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static Random rand = new Random();

    static void Main()
    {
    	Action<object> action = (object obj) =>
	      {
	         Console.WriteLine("Task={0}, obj={1}, Thread={2}",
	         Task.CurrentId, obj,
	         Thread.CurrentThread.ManagedThreadId);
	      };
        // Wait on a single task with no timeout specified.
        Task taskA = Task.Run( () => Thread.Sleep(2000));

        Console.WriteLine("taskA Status: {0}", taskA.Status);
        try {
          taskA.Wait();
          Console.WriteLine("taskA Status: {0}", taskA.Status);
       } 
       catch (AggregateException) {
          Console.WriteLine("Exception in taskA.");
       } 

       // Construct a started task
        Task t2 = Task.Run( () => {Console.WriteLine("Task={0}, obj={1}, Thread={2}",
                                                     Task.CurrentId, taskData,
                                                      Thread.CurrentThread.ManagedThreadId);
        // Block the main thread to demonstrate that t2 is executing
        t2.Wait(); 
        Console.WriteLine("Finished!!");
    }    
}
// The example displays output like the following:
//     taskA Status: WaitingToRun
//     taskA Status: RanToCompletion