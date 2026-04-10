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
        Console.WriteLine($"Leeftijd   : {movie.BBFC}");
        Console.WriteLine($"Duur       : {movie.Duration}");

        Console.WriteLine();
        Console.WriteLine($"Datum      : {movie.Date}");
        Console.WriteLine($"Tijd       : {movie.StartTime} - {movie.EndTime}");
        Console.WriteLine($"Zaal       : {movie.LocationId}");

        Console.WriteLine();
        Console.WriteLine("----------------------------------------");
        Console.WriteLine("Beschrijving:");
        Console.WriteLine(movie.Description);
        Console.WriteLine("========================================");

        Console.WriteLine("\nDruk op een toets om terug te gaan naar de hoofd menu.");
        Console.ReadKey();

        return;
    }
}