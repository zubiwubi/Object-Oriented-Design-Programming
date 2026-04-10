public class SearchMoviesLogic
{
    private static readonly MovieAccess _movieAccess = new();

    public static List<MovieModel> GetAll()
    {
        return _movieAccess.GetAll();
    }

    public static MovieModel? GetByID(int id)
    {
        return _movieAccess.GetById(id);
    }


    public List<MovieModel> FilterMovies(List<MovieModel> allMovies, string title, string genre, int? location, string date)
    {
        var queryMovies = allMovies;

        if (!string.IsNullOrWhiteSpace(title))
        {
            queryMovies = queryMovies.FindAll(f =>
                f.Title.Contains(title, StringComparison.OrdinalIgnoreCase));
        }

        if (location.HasValue)
        {
            queryMovies = queryMovies.FindAll(f =>
                f.LocationId == location.Value);
        }

        if (!string.IsNullOrWhiteSpace(genre))
        {
            queryMovies = queryMovies.FindAll(f =>
                f.Genre == genre);
        }

        if (!string.IsNullOrWhiteSpace(date))
        {
            queryMovies = queryMovies.FindAll(f =>
                f.Date == date);
        }

        queryMovies = queryMovies.FindAll(f =>
            DateTime.TryParseExact(f.Date, "dd-MM-yyyy", null,
                System.Globalization.DateTimeStyles.None, out DateTime movieDate) &&
            TimeSpan.TryParse(f.StartTime, out TimeSpan startTime) &&
            (movieDate.Date + startTime) >= DateTime.Now
        );

        return queryMovies;
    }

    public static bool DateInPastValidation(string date)
    {
        if (DateTime.TryParse(date, out DateTime inputDate))
        {
            DateTime today = DateTime.Today;
            return !(today > inputDate.Date);
        }
        else if (date == "")
        {
            return true;
        }
        else
        {
            Console.WriteLine("Niet de juiste format.");
            // Console.WriteLine("Invalid date format.");
            return false;
        }
    }
}



