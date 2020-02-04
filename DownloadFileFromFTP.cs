using System;
using System.IO;
using System.Threading;
using System.Net;

class DownloadFileFromFTP {
	public static void download() {

		//ftp server variables
        String serverAddress = "192.168.0.33";
        String path = "Testing";
        String filename = "bbt.avi";
        String username = "administrator";
        String password = "Password1";



        //get the accountbalances.txt file from ftp server
        Console.WriteLine("Downloading....");
        FtpWebRequest request =
            (FtpWebRequest) WebRequest.Create("ftp://" + serverAddress + "/" + path + "/" + filename);
        request.Credentials = new NetworkCredential(username, password);
        request.Method = WebRequestMethods.Ftp.DownloadFile;

        using (Stream ftpStream = request.GetResponse().GetResponseStream())

        using (Stream fileStream = File.Create(@"" + filename))
        {
            byte[] buffer = new byte[10240];
            int read;
            while ((read = ftpStream.Read(buffer, 0, buffer.Length)) > 0)
            {
                fileStream.Write(buffer, 0, read);
                Console.WriteLine("Downloaded {0} bytes", fileStream.Position);
            }
        }

        /*
        //delete the accountbalances.txt file from server
        FtpWebRequest deleteRequest =
            (FtpWebRequest) WebRequest.Create("ftp://" + serverAddress + "/" + path + "/" + filename);

        deleteRequest.Credentials = new NetworkCredential(username, password);

        deleteRequest.Method = WebRequestMethods.Ftp.DeleteFile;

        using (FtpWebResponse deleteResponse = (FtpWebResponse) deleteRequest.GetResponse())
        {
            Console.WriteLine(deleteResponse.StatusDescription);
        }
        */

	}
}