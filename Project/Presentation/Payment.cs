using System.ComponentModel.DataAnnotations;

public class Payment
{
    protected static AccountLogic accountLogic = new();
    public static void Order(int movieId, int seat)
    {
        // make arrow keys
        Console.WriteLine("Choose a payment system?");
        Console.WriteLine("[1] IBAN");
        Console.WriteLine("[2] PayPal");
        while (true)
        {
            string? paymentChoice = Console.ReadLine()?.Trim();

            if (paymentChoice == "1")
            {
                Console.WriteLine("=== Payment Information ===");
                Console.WriteLine("Enter an IBAN card number you want to use(with or without spaces): ");
                string newCard = Console.ReadLine()?.Trim();
                while (true)
                {
                    bool isNewCardValid = PaymentLogic.IBANCheck(newCard);
                    if (isNewCardValid)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a correct card:");
                        newCard = Console.ReadLine()?.Trim();
                    }
                }
            }
            else if (paymentChoice == "2")
            {
                Console.WriteLine($"Enter your PayPal email:");
                string email = Console.ReadLine()?.Trim();
                bool emailValid = accountLogic.IsEmailValid(email);
                if (emailValid)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter a correct card:");
                    email = Console.ReadLine()?.Trim();
                }


            }

            // make arrow keys
            Console.WriteLine("Confirm Payment?");
            Console.WriteLine("[1] Yes");
            Console.WriteLine("[2] No");

            string? ConfirmChoice = Console.ReadLine()?.Trim();

            if (ConfirmChoice == "1")
            {
                Console.WriteLine("\nPurchase Confirmed.");
                Console.WriteLine($"The order has been added to the system'");
                // check if logged in, if not, do not save -> print QR code
                PaymentLogic.SaveOrder(AccountLogic.CurrentAccount.Id, movieId, seat, 1, 1);//foodid and drinkid
                Console.WriteLine("\nPress any key to return to the main menu...");
                Console.ReadKey();
                Console.Clear();
                AccountHomePage.HomePage();
            }
            else if (ConfirmChoice == "2")
            {
                Console.WriteLine($"The order has been cancelled");
                Console.WriteLine("\nPress any key to return to the main menu...");
                Console.ReadKey();
                Console.Clear();
                AccountHomePage.HomePage();

            }
        }
    }
}