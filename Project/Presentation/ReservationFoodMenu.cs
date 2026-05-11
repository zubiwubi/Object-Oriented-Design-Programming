public class ReservationFoodMenu : CustomMessageWithMenuOS
{
    protected static List<string> Options { get; set; } = new List<string>() { "VIEW SNACKS", "CONTINUE TO PAYMENT WITHOUT SNACKS" };
    protected static string Message { get; set; } = "";
    
    // Filtered Lists with all the Movie Snacks & Drinks
    public static List<FoodModel> allSnacks{ get; set; } = FoodMenuLogic.GetAllFoods().Where(f => f.IsLounge == 0).ToList();
    public static List<DrinkModel> allMovieDrinks { get; set; } = FoodMenuLogic.GetAllDrinks().Where(d => d.IsLounge == 0).ToList();

    public static void FoodOrderChecker(int movieId, int seatNum, string callerType) // Confirm First
    {
        Console.Clear();
        
        Message = $"\tCurrent order: Movie #{movieId} | Seat #{seatNum}\n\tAre you interested in adding anything to eat to your order? (This will open the snack menu)";

        while (true)
        {
            int selectedOption = MenuRenderer(Options, Message);

            switch (selectedOption)
            {
                case 0: // ------------ VIEW SNACKS -------------
                    FoodOrder();
                    Console.ReadKey();
                    break;
                case 1: // ------------ CONTINUE WITHOUT SNACKS -------------
                    Payment.Order(movieId, seatNum, callerType); // REDIRECT TO PAYMENT SCREEN
                    break;
            }
        }
    }

    // public static void Render<T>(List<T> Cart) where T: ConsumableModel // Collect the IDs
    // {
        
    // }
    public static void FoodOrder() // send foodid 
    {
        Display.ClearScreen();

        Console.WriteLine($"\tFOOD MENU");

        foreach (var food in allSnacks)
        {
            Console.WriteLine($"{food.Id} || {food.Name}");
        }

        Console.WriteLine($"\tDRINK MENU");

        foreach (var drink in allMovieDrinks)
        {
            Console.WriteLine($"{drink.Id} || {drink.Name}");
        }

        Console.WriteLine("Please select the ID for the food you want to order.");
        long foodId = Convert.ToInt64(Console.ReadLine());

        Console.WriteLine("Please select the ID for the drink you want to order.");
        long drinkId = Convert.ToInt64(Console.ReadLine());

        Display.ClearScreen();

        Console.WriteLine($"Confirm your order. Your order is: ");

        foreach (var drink in allMovieDrinks)
        {
            if (drinkId == drink.Id)
            {
                Console.WriteLine($"{drink.Name} ({drink.Size}) || {drink.Price}");
            }
        }

        foreach (var food in allSnacks)
        {
            if (foodId == food.Id)
            {
                Console.WriteLine($"{food.Name} || {food.Price}");
            }
        }

        Console.WriteLine($"Is that correct?");
        string input = Console.ReadLine();

        if (input == "y")
        {
            Console.WriteLine("Continuing to payment screen.");
        }
        else
        {
            Console.WriteLine("Ok let's re-order");
        }

        //Payment.Order(movieId, seatNum, callerType, foodId, drinkId);
    }
}



    // public void ShowMenu(bool isSnackMenu)
    // {
        
    //     bool validInput = false;

    //     while (!validInput)
    //     {
    //         Console.WriteLine("Do you want to order food?  (y/n)");
    //         string input = Console.ReadLine().ToLower();

    //         if (input == "n")
    //         {
    //             Console.WriteLine("Redirecting to payment...");
    //             Payment.Order(0, 0);
    //             return;
    //         }
    //         else if (input == "y")
    //         {
    //             validInput = true;

    //             FoodModel selected = ViewFoodMenu.SelectFoodItem(isSnackMenu);

    //             // save orders
    //             List<FoodModel> order = new List<FoodModel>();
    //             order.Add(selectedItem);

    //             // string menuType = isSnackMenu ? "SNACK MENU" : "LOUNGE MENU";
    //             // Console.WriteLine($"\n ---- {menuType} ----\n");
                
        
    //             // VALIDATION LOOP // check otherwise send to payment  
    //             bool confirmValid = false;

    //             while (!confirmValid)
    //             {
    //                 Console.WriteLine($"You selected: {selectedItem.Name}");
    //                 Console.WriteLine("Confirm order? (y/n)");

    //                 string confirm = Console.ReadLine().ToLower();

    //                 if (confirm == "n")
    //                 {
    //                     order.Clear();
    //                     Console.WriteLine("Order cancelled.");
    //                     confirmValid = true;
    //                 }
    //                 else if (confirm == "y")
    //                 {
    //                     Console.WriteLine("Redirecting to payment...");
    //                     Payment.Order(0, 0);
    //                     return;
    //                 }
    //                 else
    //                 {
    //                     Console.WriteLine("Invalid choice!");
    //                 }
    //             }
    //         }
    //         else
    //         {
    //             Console.WriteLine("Invalid choice!");
    //         }
    //    }