public static class SearchMovies
{
    public static void SearchMovie()
    {
        SearchMoviesLogic moviesLogic = new();
        List<MovieModel> allMovies = SearchMoviesLogic.GetAll();
        List<MovieModel> matchingMovies;

        Console.Write("Vul een title van de film die u wilt zien(druk enter om leeg te laten of Q om terug te gaan): ");
        // Console.Write("Enter a title of the movie(press enter to skip): ");
        string title = Console.ReadLine();
        if (title == "Q" || title == "q") { return; }

        Console.Write("Vul een nummer van de auditorium (1,2,3) (druk enter om leeg te laten of Q om terug te gaan): ");
        // Console.Write("Enter a auditorium number (1,2,3)(press enter to skip): ");
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
                SearchMovie();
            }
        }
        Console.Write("Vul een datum in van wanneer u de film wilt zien (dd-MM-jjj) (druk enter om leeg te laten of Q om terug te gaan): ");
        // Console.Write("Enter a date when you would like to see the movie (DD-MM-YYYY) (press enter to skip): ");
        string date = Console.ReadLine();
        if (date == "Q" || date == "q") { return; }
        while (!SearchMoviesLogic.DateInPastValidation(date))
        {
            // Console.WriteLine("Date is in the past. Please try again.");
            // Console.Write("Enter a date (DD-MM-YYYY) (press enter to skip): ");
            Console.WriteLine("Datum is in het verleden.");
            Console.Write("Vul een datum in(dd-MM-jjj) (druk enter om leeg te laten): ");

            date = Console.ReadLine();
        }
        matchingMovies = moviesLogic.FilterMovies(allMovies, title, location, date);

        if (matchingMovies.Count == 0)
        {

            // Console.WriteLine("\nNo movies found matching your criteria.");
            // Console.WriteLine("\nPress any key to return to the main menu.");
            Console.WriteLine("\nGeen films gevonden die aan uw criteria voldoen.");
            Console.WriteLine("\nDruk een toets om naar de menu door te gaan.");
            Console.ReadKey();
            return;
        }


        // Console.WriteLine("\nMatching movies:");
        Console.WriteLine("\nLijst van films:");
        PrintMovies(matchingMovies);
        // Console.WriteLine("\nPress any key to return to main menu");


        // optie om de id of title te invullen om dan description van de film te zien.

        // Console.WriteLine("\nDruk een toets om naar de menu door te gaan.");
        Console.WriteLine("\nVul de film Id om de omschrijving van de film te zien.\nVul in Q om terug te gaan naar de hoofd menu..");
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
                    Console.WriteLine("Film niet gevonden");
                }
                Console.WriteLine("\nDruk een toets om naar het menu door te gaan.");
                Console.ReadKey();
                return;
            }
            else
            {
                Console.WriteLine("Ongeldige invoer! Voer een geldig nummer in of Q om terug te gaan:");
            }
        }
    }


    private static void PrintMovies(List<MovieModel> movies)
    {
        // Console.WriteLine("ID   | Title                          |Location  | Date         | StartTime | EndTime   | Duration | BBFC   ");
        // Console.WriteLine("-------------------------------------------------------------------------------------------------------------");
        Console.WriteLine("ID   | Titel                          |Locatie   | Datum        | StartTjd | EindTijd   | Duur     | BBFC   ");
        Console.WriteLine("-------------------------------------------------------------------------------------------------------------");

        foreach (var movie in movies)
        {

            Console.WriteLine(
                $"{movie.Id,-4} | {movie.Title,-31}|{movie.LocationId,-9} | {movie.Date,-12} | {movie.StartTime,-9} | {movie.EndTime,-9} | {movie.Duration,-8} | {movie.BBFC,-7}"
            );
        }
    }
}
