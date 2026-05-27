public class NewsletterChain
{
    public static void SendNewsletter()
    {
        Console.Write("Monthly or weekly? [1] Monthly [2] Weekly: ");
        string frequencyChoice = Console.ReadLine();
        string frequency = "";
        if (frequencyChoice == "1")
        {
            frequency = "Monthly";
        }
        else if (frequencyChoice == "2")
        {
            frequency = "Weekly";
        }
        else
        {
            Console.WriteLine("Input was incorrect. Please input [1] for monthly or [2] for weekly. Else it will default to monthly");
            frequency = "monthly";
        }

        Console.Write("Subject: ");
        string subject = Console.ReadLine();

        Console.Write("Main Body of the email");
        string mainBody = Console.ReadLine();


        Console.Write("Discounts? Leave blank if none");
        string discounts = Console.ReadLine();

        Console.Write("Any new releases? Leave blank if none");
        string newReleases = Console.ReadLine();


        string email = $@"
        
        Dear costumer,
        
        Welcome to our {frequency} newsletter from the Rotterdam Cinema!
        
        {mainBody}
        
        
        === DISCOUNTS ===
        {discounts}
        If you see this empty then it means there's no applicable discounts at the moment.
        
        === New Releases ===
        {newReleases}
        If you see this empty then it means there's no current new releases to be announced. 
        
        Kind regards,
        The Rotterdam Cinema Team

        ";
        // 1. input

        // 2. build email body

        // 3. get customers

        // 4. send



        AccountLogic accountLogic = new AccountLogic();
        list<AccountModel> allAccounts = accountLogic.GetAllAccounts();
        foreach


        // create the tool to access accounts
        // get all accounts from the database
        // create an empty list for customers only
        // loop through all accounts, if the account is a customer add it to the customer list
        // if there are no customers, show error and go back
        // ask admin to confirm sending
        // if admin says no, cancel and go back
        // loop through customer list and send the email to each one
        // show done message
    }
}