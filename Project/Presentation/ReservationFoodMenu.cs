public class ReservationFoodMenu
{
    public static List<FoodModel> allFoods = FoodMenuLogic.GetAllFoods();
    public static List<DrinkModel> allDrinks = FoodMenuLogic.GetAllDrinks();

    // filteren

    //public static List<DrinkModel> allLoungeDrinks = [];
    public static List<FoodModel> allLoungeFood = [];
    //public static List<T> allLoungeConsumables = [];

    public static void Render()
    {
        FilterLoungeFood();

        foreach (var food in allLoungeFood)
        {
            Console.WriteLine(food.Name);
        }
    }

    public static void FilterLoungeFood()
    {
        foreach (var food in allFoods)
        {
            if (food.IsLounge == 1) // if true
            {
                allLoungeFood.Add(food);
            }
        }
    }
}


    

    // public static List<DrinkModel> GetAllDrinksbyType(bool isLounge)
    // {
    //     List<DrinkModel> loungeDrink = new();

    //     foreach (var drink in _drinkAccess.GetAll())
    //     {
    //         if (drink.IsLoungeDrink == isLoungeDrink)
    //         {
    //             loungeDrink.Add(drink);
    //         }
    //     }

    //     return loungeDrink;
    // }

    // public static void AddVeganDescription<T>(List<T> Consumables) where T: ConsumableModel
    // {
    //     foreach (var item in Consumables)
    //     {
    //         if (item.isLounge == 1)
    //         {
    //             SnackList.Add;
    //         }
    //     }
    // }

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