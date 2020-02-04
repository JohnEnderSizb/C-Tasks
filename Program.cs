using System;   
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static Random rand = new Random();

    static void Main()
    {
        // Wait on a single task with no timeout specified.
        Task taskA = Task.Run( () =>  {
        	//DownloadFileFromFTP downloadObject = mew DownloadFileFromFTP();
        	DownloadFileFromFTP.download();
        	
        	}
    	);

        Console.WriteLine("taskA Status: {0}", taskA.Status);
        try {
          taskA.Wait();
          Console.WriteLine("taskA Status: {0}", taskA.Status);
       } 
       catch (AggregateException) {
          Console.WriteLine("Exception in taskA.");
       } 
    }    
















}

/*


*/