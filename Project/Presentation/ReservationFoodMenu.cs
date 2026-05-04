public class ReservationFoodMenu
{
    public void ShowMenu(bool isSnackMenu)
    {
        bool validInput = false;

        while (!validInput)
        {
            Console.WriteLine("Do you want to order food?  (y/n)");
            string input = Console.ReadLine().ToLower();

            if (input == "n")
            {
                Console.WriteLine("Redirecting to payment...");
                Payment.Order(0, 0);
                return;
            }
            else if (input == "y")
            {
                validInput = true;
                var menu = FoodMenuLogic.GetAllFoodsByType(isSnackMenu);

                // save orders
                List<object> order = new List<object>();

                foreach (var item in menu)
                {
                Console.WriteLine($"{item.Name} - {item.Description} - €{item.Price}");
                }

                // VALIDATION LOOP
                bool confirmValid = false;

                while (!confirmValid)
                {
                    Console.WriteLine("Confirm order? (y/n)");
                    string confirmInput = Console.ReadLine().ToLower();

                    if (confirmInput == "n")
                    {
                        order.Clear();
                        confirmValid = true;
                    }
                    else if (confirmInput == "y")
                    {
                        Console.WriteLine("Redirecting to payment...");
                        Payment.Order(0, 0);
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice!");
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid choice!");
            }
        }
    }
}