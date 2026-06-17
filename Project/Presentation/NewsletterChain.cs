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
            frequency = "Monthly";
        }

        Console.Write("Subject: ");
        string subject = Console.ReadLine();

        Console.Write("Main Body of the email: ");
        string mainBody = Console.ReadLine();


        Console.Write("Discounts? Leave blank if none: ");
        string discounts = Console.ReadLine();

        Console.Write("Any new releases? Leave blank if none: ");
        string newReleases = Console.ReadLine();


        string email = $@"
        
        Dear customer,
        
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

        AccountLogic accountLogic = new AccountLogic();
        List<AccountModel> allAccounts = accountLogic.GetAllAccounts();
        List<AccountModel> customerList = new List<AccountModel>();
        foreach (AccountModel account in allAccounts)
        {
            if (account.Type == "Customer")
            {
                customerList.Add(account);
            }
        }


        foreach (AccountModel customer in customerList)
        {
            Mail.SendNewsletterMail(customer.EmailAddress, subject, email);
        }
    }
}