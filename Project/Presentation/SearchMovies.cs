public static class SearchMovies
{
    public static void SearchMovie()
    {
        SearchMoviesLogic moviesLogic = new();
        List<MovieModel> allMovies = SearchMoviesLogic.GetAll();
        List<MovieModel> matchingMovies;

        Console.Write("Enter a title of the movie(press enter to skip): ");
        string title = Console.ReadLine();
        if (title == "Q" || title == "q") { return; }

        Console.Write("Enter a genre of the movie(press enter to skip): ");
        string genre = Console.ReadLine();
        if (genre == "Q" || genre == "q") { return; }

        Console.Write("Enter a auditorium number (1,2,3)(press enter to skip): ");
        string locationInput = Console.ReadLine();
        if (locationInput == "Q" || locationInput == "q") { return; }

        int? location = null;

        if (!string.IsNullOrWhiteSpace(locationInput))
        {
            if (int.TryParse(locationInput, out int parsedLocation))
            {
                location = parsedLocation;
            }
            else
            {
                Console.WriteLine("Invalid location input. Restarting the search");
                Console.WriteLine();
                SearchMovie();
            }
        }
        Console.Write("Enter a date when you would like to see the movie (DD-MM-YYYY) (press enter to skip): ");
        string date = Console.ReadLine();
        if (date == "Q" || date == "q") { return; }
        while (!SearchMoviesLogic.DateInPastValidation(date))
        {
            Console.WriteLine("Date is in the past. Please try again.");
            Console.Write("Enter a date (DD-MM-YYYY) (press enter to skip): ");

            date = Console.ReadLine();
        }
        matchingMovies = moviesLogic.FilterMovies(allMovies, title, genre, location, date);

        if (matchingMovies.Count == 0)
        {

            Console.WriteLine("\nNo movies found matching your criteria.");
            Console.WriteLine("\nPress any key to return to the main menu.");
            Console.ReadKey();
            return;
        }


        Console.WriteLine("\nMatching movies:");
        PrintMovies(matchingMovies);

        Console.WriteLine("\nEnter the film Id to see the description.\nEnter Q to return to the main menu.");
        while (true)
        {
            string CustomerChoice = Console.ReadLine();
            if (CustomerChoice == "Q" || CustomerChoice == "q")
            {
                return;
            }
            if (int.TryParse(CustomerChoice, out int CustomerChoiceInt))
            {
                bool found = false;
                foreach (var movie in matchingMovies)
                {
                    if (movie.Id == CustomerChoiceInt)
                    {
                        found = true;
                        ViewMovies.ViewMovie(CustomerChoiceInt);
                    }

                }
                if (!found)
                {
                    Console.WriteLine("Movie not found");
                    Console.WriteLine("\nPress any key to return to main menu");
                    Console.ReadKey();
                    return;
                }
                return;
            }
            else
            {
                Console.WriteLine("Invalid input! Enter a valid number or Q to return to the main menu:");
            }
        }
    }


    private static void PrintMovies(List<MovieModel> movies)
    {
        Console.WriteLine("ID   | Title                          |Genre             |Location  | Date         | StartTime | EndTime   | Duration | BBFC   ");
        Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------");
        foreach (var movie in movies)
        {

            Console.WriteLine(
                $"{movie.Id,-4} | {movie.Title,-31}|{movie.Genre,-18}|{movie.LocationId,-9} | {movie.Date,-12} | {movie.StartTime,-9} | {movie.EndTime,-9} | {movie.Duration,-8} | {movie.BBFC,-7}"
            );
        }
    }
}
