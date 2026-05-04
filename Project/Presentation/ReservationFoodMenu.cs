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

                FoodModel selected = ViewFoodMenu.SelectFoodItem(isSnackMenu);

                // save orders
                List<FoodModel> order = new List<FoodModel>();
                order.Add(selectedItem);

                // string menuType = isSnackMenu ? "SNACK MENU" : "LOUNGE MENU";
                // Console.WriteLine($"\n ---- {menuType} ----\n");
                
        
                // VALIDATION LOOP
                bool confirmValid = false;

                while (!confirmValid)
                {
                    Console.WriteLine($"You selected: {selectedItem.Name}");
                    Console.WriteLine("Confirm order? (y/n)");

                    string confirm = Console.ReadLine().ToLower();

                    if (confirm == "n")
                    {
                        order.Clear();
                        Console.WriteLine("Order cancelled.");
                        confirmValid = true;
                    }
                    else if (confirm == "y")
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