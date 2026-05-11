public class Payment
{
    protected static AccountLogic accountLogic = new();
    protected static PaymentLogic paymentLogic = new();
    public static void Order(int movieId, int seat, string caller)
    {
        Console.WriteLine("Choose a payment system?");
        Console.WriteLine("[1] IDeal/WERO");
        Console.WriteLine("[2] PayPal");

        while (true)
        {
            string? paymentChoice = Console.ReadLine()?.Trim();

            if (paymentChoice == "1")
            {
                string? newCard;
                while (true)
                {
                    Console.WriteLine("Enter an IBAN card number (with or without spaces): ");
                    newCard = Console.ReadLine()?.Trim();

                    if (paymentLogic.IBANCheck(newCard))
                        break;

                    Console.WriteLine("Please enter a correct IBAN.");
                }

                break;
            }
            else if (paymentChoice == "2")
            {
                string? email;
                while (true)
                {
                    Console.WriteLine("Enter your PayPal email:");
                    email = Console.ReadLine()?.Trim();

                    if (accountLogic.IsEmailValid(email))
                        break;

                    Console.WriteLine("Please enter a correct email.");
                }

                break;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please select 1 or 2.");
            }
        }

        while (true)
        {
            Console.WriteLine("Confirm Payment?");
            Console.WriteLine("[1] Yes");
            Console.WriteLine("[2] No");

            string? confirmChoice = Console.ReadLine()?.Trim();

            if (confirmChoice == "1")
            {
                Console.WriteLine("\nPurchase Confirmed.");
                Console.WriteLine("The order has been added to the system");

                if (caller == "Guest")
                {
                    string? emailForTicket;
                    while (true)
                    {
                        Console.WriteLine("Please enter your email to receive your ticket:");
                        emailForTicket = Console.ReadLine()?.Trim();

                        if (accountLogic.IsEmailValid(emailForTicket))
                            break;

                        Console.WriteLine("Please enter a correct email.");
                    }
                    int orderId = PaymentLogic.SaveOrder(null, movieId, seat);
                    QRCodeGen.QrCodeGeneration(emailForTicket, orderId, movieId, seat);
                    Console.WriteLine("\nPress any key to return to the main menu...");
                    Console.ReadKey();
                    Display.ClearScreen();
                    return;
                }
                else
                {
                    int orderId = PaymentLogic.SaveOrder(AccountLogic.CurrentAccount.Id, movieId, seat);
                    QRCodeGen.QrCodeGeneration(AccountLogic.CurrentAccount.EmailAddress, orderId, movieId, seat);
                    Console.WriteLine("\nPress any key to return to the main menu...");
                    Console.ReadKey();
                    Display.ClearScreen();
                    AccountHomePage.HomePage();
                    return;
                }
            }
            else if (confirmChoice == "2")
            {
                Console.WriteLine("The order has been cancelled");
                Console.WriteLine("\nPress any key to return to the main menu...");
                Console.ReadKey();

                if (caller != "Guest")
                {
                    Display.ClearScreen();
                    AccountHomePage.HomePage();
                }
                return;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please select 1 or 2.");
            }
        }
    }
}