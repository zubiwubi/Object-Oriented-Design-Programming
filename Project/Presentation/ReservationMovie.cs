public static class ReservationMovie
{
    public static int ChosenMovieId = 0;

    public static void Reserve()
    {
        Console.Clear();
        Console.WriteLine("===========================================");
        Console.WriteLine("           RESERVE A MOVIE");
        Console.WriteLine("===========================================");
        Console.WriteLine();

        List<MovieModel> allMovies = SearchMoviesLogic.GetAll();

        if (allMovies.Count == 0)
        {
            Console.WriteLine("Sorry, there are no movies available right now.");
            Console.WriteLine("Press any key to return to the main menu.");
            Console.ReadKey();
            return;
        }

        Console.WriteLine("Here is the list of all available movies:");
        Console.WriteLine();
        Console.WriteLine("ID   | Title                          | Genre             | Hall     | Date         | StartTime | EndTime   | Duration | BBFC");
        Console.WriteLine("-------------------------------------------------------------------------------------------------------------------------------");

        for (int i = 0; i < allMovies.Count; i++)
        {
            MovieModel movie = allMovies[i];
            string line = movie.Id.ToString().PadRight(4) + " | "
                + movie.Title.PadRight(31) + "| "
                + movie.Genre.PadRight(18) + "| "
                + movie.LocationId.ToString().PadRight(9) + "| "
                + movie.Date.PadRight(12) + " | "
                + movie.StartTime.PadRight(9) + " | "
                + movie.EndTime.PadRight(9) + " | "
                + movie.Duration.PadRight(8) + " | "
                + movie.BBFC.ToString();
            Console.WriteLine(line);
        }

        Console.WriteLine();
        Console.WriteLine("Note: you can only choose 1 movie per order.");
        Console.WriteLine("Type Q at any time to go back to the main menu.");
        Console.WriteLine();

        while (true)
        {
            Console.Write("Please enter the ID of the movie you want to reserve: ");
            string input = Console.ReadLine();

            if (input == "Q" || input == "q")
            {
                return;
            }

            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("ERROR: You did not enter anything. Please try again.");
                Console.WriteLine();
                continue;
            }

            int chosenId;
            bool isNumber = int.TryParse(input, out chosenId);
            if (!isNumber)
            {
                Console.WriteLine("ERROR: '" + input + "' is not a valid number. Please try again.");
                Console.WriteLine();
                continue;
            }

            MovieModel chosenMovie = null;
            foreach (MovieModel movie in allMovies)
            {
                if (movie.Id == chosenId)
                {
                    chosenMovie = movie;
                    break;
                }
            }

            if (chosenMovie == null)
            {
                Console.WriteLine("ERROR: There is no movie with ID " + chosenId + ". Please try again.");
                Console.WriteLine();
                continue;
            }

            Console.Clear();
            Console.WriteLine("===========================================");
            Console.WriteLine("           CONFIRMATION");
            Console.WriteLine("===========================================");
            Console.WriteLine();
            Console.WriteLine("You have chosen the following movie:");
            Console.WriteLine();
            Console.WriteLine("Title    : " + chosenMovie.Title);
            Console.WriteLine("Genre    : " + chosenMovie.Genre);
            Console.WriteLine("Date     : " + chosenMovie.Date);
            Console.WriteLine("Time     : " + chosenMovie.StartTime + " - " + chosenMovie.EndTime);
            Console.WriteLine("Hall     : " + chosenMovie.LocationId);
            Console.WriteLine("BBFC     : " + chosenMovie.BBFC);
            Console.WriteLine();
            Console.WriteLine("Are you sure you want to reserve this movie? (Y/N)");

            string confirmation = Console.ReadLine();
            if (confirmation == "Y" || confirmation == "y")
            {
                ChosenMovieId = (int)chosenMovie.Id;

                Console.WriteLine();
                Console.WriteLine("Your movie has been successfully reserved!");
                Console.WriteLine("Redirecting you to the seat selection screen...");
                Console.WriteLine();
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();

                OverviewMapsSeats seatScreen = new OverviewMapsSeats();
                seatScreen.Render();

                return;
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Reservation cancelled. You can choose a different movie.");
                Console.WriteLine();
            }
        }
    }
}