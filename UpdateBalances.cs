
class UpdateBalances {
	public static void update() {
		//update balance url
        String address = "http://127.0.0.1:8000/partial/edit/";

		//read contents of accountbalances.txt file and send make http het request for account update for each line
        string[] lines = File.ReadAllLines("accountbalances.txt");
        foreach (string line in lines)
        {
            String[] strlist = line.Split(',');

            String accountName = strlist[1];
            String ledgerBalance = strlist[2];
            String availableBalance = strlist[3];

            Console.WriteLine("Account Name: " + accountName +
                              ", Ledger Balance: " + ledgerBalance +
                              ", Available Balance: " + availableBalance);

            ///send http get request
            //laravel route: . . . /{ accountName }/{ ledgerBalance }/{ availableBalance }
            string url = address + "/" + accountName + "/" + ledgerBalance + "/" + availableBalance;
            string url = "https://stackoverflow.com/questions/943852/how-to-send-an-https-get-request-in-c-sharp"; //test url
            HttpWebRequest getRequest = (HttpWebRequest) WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse) getRequest.GetResponse();
            Stream resStream = response.GetResponseStream();
            Console.WriteLine(response.StatusDescription);

        }
	}
}