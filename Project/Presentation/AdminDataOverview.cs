public class AdminDataOverview
{
    private static OrderedExtrasLogic _orderedExtrasLogic = new();
    private static PreviousOrdersLogic _previousOrdersLogic = new();
    private static SearchMoviesLogic _searchMoviesLogic = new();

    public static void PrintData()
    {
        while (true)
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1 - Show all orders");
            Console.WriteLine("2 - Show orders by MovieId");
            Console.WriteLine("3 - Food/Drink/Merch overview");
            Console.WriteLine("Q - Return to Admin Homepage");

            string choice = Console.ReadLine();

            if (choice.ToLower() == "q")
            {
                AdminHomePage.Homepage();
                return;
            }

            if (choice == "1")
            {
                List<OrderModel> AllOrders = _previousOrdersLogic.GetAllOrders();

                int AmountOfOrders = AllOrders.Count();

                Console.WriteLine($"Amount of orders in total: {AmountOfOrders}");
                Console.WriteLine("");
                PrintAllOrders(AllOrders);
                Console.WriteLine("");
                continue;
            }
            else if (choice == "2")
            {
                Console.WriteLine("Enter MovieId (or Q to cancel):");
                string input = Console.ReadLine();

                if (input.ToLower() == "q")
                    continue;

                if (!long.TryParse(input, out long movieId))
                {
                    Console.WriteLine("Invalid MovieId. Try again.");
                    Thread.Sleep(2000);
                    continue;
                }

                List<OrderModel> AllOrdersPerMovieId = _previousOrdersLogic.GetByMovieId(movieId);

                int AmountOfOrdersPerMovie = AllOrdersPerMovieId.Count();

                Console.WriteLine($"Amount of orders for this movie: {AmountOfOrdersPerMovie}");
                Console.WriteLine("");

                PrintAllOrders(AllOrdersPerMovieId);
                Console.WriteLine("");
                continue;
            }
            else if (choice == "3")
            {
                Console.WriteLine("");


                List<OrderedExtrasModel> AllExtras = _orderedExtrasLogic.GetAll();


                PrintAllExtras(AllExtras);
                Console.WriteLine("");
                continue;
            }
            else
            {
                Console.WriteLine("Invalid option. Try again.");
                Console.WriteLine("");
            }


        }
    }


    private static void PrintAllOrders(List<OrderModel> orders)
    {
        Console.WriteLine(
            $"{"ID",-4} | {"MovieId",-7} | {"Movie Title",-25} | {"Start Time",-12} | {"Date Movie",-20} | {"Seat",-20} | {"Date Ordered",-20}| {"Ordered extras?",-5}"
        );

        Console.WriteLine(new string('-', 160));

        foreach (var order in orders)
        {
            bool extras = false;
            MovieModel orderMovie = _searchMoviesLogic.GetByID(order.MovieId);
            OrderedExtrasModel? extrasOrdered = _orderedExtrasLogic.GetByOrderId(order.Id);
            if (extrasOrdered != null)
            {
                extras = true;
            }

            Console.WriteLine(
                $"{order.Id,-4} | {order.MovieId,-7} | {orderMovie.Title,-25} | {orderMovie.StartTime,-12} | {orderMovie.Date,-20} | {order.Seat,-20} | {order.Date,-20}| {extras,-5}"
            );
        }
    }

    private static void PrintAllExtras(List<OrderedExtrasModel> orders)
    {
        Console.WriteLine(
            $"{"ID",-4} | {"OrderId",-15} | {"FoodId",-25} | {"Food amount",-12} | " +
            $"{"DrinkId",-20} | {"Drink amount",-12} | {"MerchId",-20} | {"Merch amount",-12}"
        );

        Console.WriteLine(new string('-', 170));

        foreach (var order in orders)
        {
            Console.WriteLine(
                $"{order.Id,-4} | " +
                $"{order.OrderId,-15} | " +
                $"{order.FoodId?.ToString() ?? "None",-25} | " +
                $"{order.FoodQuantity,-12} | " +
                $"{order.DrinkId?.ToString() ?? "None",-20} | " +
                $"{order.DrinkQuantity,-12} | " +
                $"{order.MerchandiseId?.ToString() ?? "None",-20} | " +
                $"{order.MerchandiseQuantity,-12}"
            );
        }
    }

}

