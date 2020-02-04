using System;   
using System.Threading;
using System.Threading.Tasks;

class BalancesMain
{
    static Random rand = new Random();

    public static void startUpdates()
    {
        // Wait on a single task with no timeout specified.
        Task taskA = Task.Run( () =>  {
        	
        	//DownloadFileFromFTP.download();
        	UpdateBalances.update();
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