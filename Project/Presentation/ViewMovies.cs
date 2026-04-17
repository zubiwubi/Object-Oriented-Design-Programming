public class ViewMovies
{
    public static void ViewMovie(int id)
    {
        MovieModel movie = SearchMoviesLogic.GetByID(id);

        Console.Clear();

        Console.WriteLine("========================================");
        Console.WriteLine($"{movie.Title.ToUpper()}");
        Console.WriteLine("========================================");

        Console.WriteLine($"Genre      : {movie.Genre}");
        Console.WriteLine($"BBFC/Age   : {movie.BBFC}");
        Console.WriteLine($"Duration   : {movie.Duration}");

        Console.WriteLine();
        Console.WriteLine($"Date       : {movie.Date}");
        Console.WriteLine($"Times      : {movie.StartTime} - {movie.EndTime}");
        Console.WriteLine($"Auditorium : {movie.LocationId}");

        Console.WriteLine();
        Console.WriteLine("----------------------------------------");
        Console.WriteLine("Description:");
        Console.WriteLine(movie.Description);
        Console.WriteLine("========================================");

        Console.WriteLine("\nPress any key to return to the main menu.");
        Console.ReadKey();

        return;
    }
}