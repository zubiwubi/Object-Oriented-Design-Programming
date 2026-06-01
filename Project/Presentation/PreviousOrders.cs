public class PreviousOrders
{
    public static PreviousOrdersLogic previousOrdersLogic = new();
    public static SearchMoviesLogic searchMoviesLogic = new();
    public static OrderedExtrasLogic orderedExtrasLogic = new();

    public static FoodLogic foodLogic = new();
    public static DrinkLogic drinkLogic = new();
    public static MerchandiseLogic merchandiseLogic = new();


    public static void ViewPreviousOrders()
    {
        List<OrderModel> AllOrders = previousOrdersLogic.GetByAccountId(AccountLogic.CurrentAccount.Id);
        if (AllOrders.Count() == 0)
        {
            Console.WriteLine("No previous orders!");
            Console.WriteLine("Press 'Enter' to go back");
            Console.ReadKey();
            AccountHomePage.HomePage();
        }
        else
        {
            PrintBasicOrderInfo(AllOrders);
            Console.WriteLine();
            while (true)
            {
                Console.WriteLine("Enter the order Id of the order you want to see more details of. (Or 'Q' to go back to the menu)");

                string detailsOrder = Console.ReadLine();

                if (detailsOrder.Equals("Q", StringComparison.OrdinalIgnoreCase))
                {
                    AccountHomePage.HomePage();
                    break;
                }


                if (long.TryParse(detailsOrder, out long detailsOrderId))
                {
                    bool orderExists = AllOrders.Any(order => order.Id == detailsOrderId);

                    if (!orderExists)
                    {
                        Console.WriteLine("That order ID is not in your previous orders.");
                        continue;
                    }
                    OrderModel orderDetails = previousOrdersLogic.GetById(detailsOrderId);

                    if (orderDetails != null)
                    {
                        PrintExtraOrderInfo(orderDetails);

                        Console.WriteLine();
                        Console.WriteLine("Press 'Enter' to go back");
                        Console.ReadLine();

                        AccountHomePage.HomePage();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("The order ID could not be found.");
                    }
                }
                else
                {
                    Console.WriteLine("Please enter a valid numeric order ID.");
                }
            }
        }

    }
    private static void PrintBasicOrderInfo(List<OrderModel> orders)
    {
        Console.WriteLine(
            $"{"ID",-4} | {"MovieId",-7} | {"Movie Title",-25} | {"Start Time",-12} | {"Date Movie",-20} | {"Seat",-6} | {"Date Ordered",-20}| {"Ordered extras?",-5}"
        );

        Console.WriteLine(new string('-', 125));

        foreach (var order in orders)
        {
            bool extras = false;
            MovieModel orderMovie = searchMoviesLogic.GetByID(order.MovieId);
            OrderedExtrasModel? extrasOrdered = orderedExtrasLogic.GetByOrderId(order.Id);
            if (extrasOrdered != null)
            {
                extras = true;
            }

            Console.WriteLine(
                $"{order.Id,-4} | {order.MovieId,-7} | {orderMovie.Title,-25} | {orderMovie.StartTime,-12} | {orderMovie.Date,-20} | {order.SeatId,-6} | {order.Date,-20}| {extras,-5}"
            );
        }
    }

    private static void PrintExtraOrderInfo(OrderModel order)
    {
        Console.WriteLine(
            $"{"ID",-4} | {"OrderedExtra Id",-7} | {"Food name",-25} | {"Food amount",-12} | {"Drink name",-20} | {"Drink amount",-6} | {"Merch name",-20} | {"Merch amount",-5}"
        );

        Console.WriteLine(new string('-', 125));

        List<OrderedExtrasModel> orderedExtras =
            orderedExtrasLogic.GetAllByOrderId(order.Id) ?? new List<OrderedExtrasModel>();

        foreach (var orderedExtra in orderedExtras)
        {
            FoodModel? orderedFood = foodLogic.GetById(orderedExtra.FoodId);
            DrinkModel? orderedDrink = drinkLogic.GetById(orderedExtra.DrinkId);
            MerchandiseModel? orderedMerch = merchandiseLogic.GetById(orderedExtra.MerchandiseId);

            Console.WriteLine(
                $"{order.Id,-4} | " +
                $"{orderedExtra.Id,-15} | " +
                $"{orderedFood?.Name ?? "None",-25} | " +
                $"{orderedExtra.FoodQuantity,-12} | " +
                $"{orderedDrink?.Name ?? "None",-20} | " +
                $"{orderedExtra.DrinkQuantity,-12} | " +
                $"{orderedMerch?.Name ?? "None",-20} | " +
                $"{orderedExtra.MerchandiseQuantity,-5}"
            );
        }
    }
}