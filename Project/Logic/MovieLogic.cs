using System.Reflection.PortableExecutable;
using System.Text.RegularExpressions;
public class MovieLogic
{
    private static MovieAccess _Access = new();
    public bool IsDateFormatValid;
    public bool IsTimeFormatValid;
    public bool IsDurationFormatValid;
    public List<int> BBFCs = [3, 9, 12, 15, 18];
    public List<string> Genres = ["Fantasy", "Drama", "Comedy", "Crime", "Adventure", "Western"];
    public List<char> characters = new() { '!', '@', '#', '$', '%', '^', '&', '*', '.' };
    public List<int> digits = new() { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    public List<MovieModel> GetAllMovies()
    {
        return _Access.GetAllMovies();
    }
    public void Add(MovieModel movie)
    {
        _Access.Add(movie);
    }

    public void Update(MovieModel movie)
    {
        _Access.Update(movie);
    }

    public void UpdateBool(MovieModel movie)
    {
        _Access.UpdateBool(movie);
    }
    public MovieModel? CheckMovieExist(MovieModel movie)
    {
        return _Access.CheckMovieExists(movie);
    }
    public bool IsLocationIdValid(int Id)
    {
        if (string.IsNullOrEmpty(Id.ToString().Trim()))
        {
            return false;
        }


        if (Id != 1 && Id != 2 && Id != 3)
        {
            return false;
        }

        return true;
    }

    public bool IsTitleValid(string title)
    {
        if (string.IsNullOrEmpty(title.Trim()))
        {
            return true;
        }

        if (title.Length < 2 || title.Length > 30)
        {
            return false;
        }

        return true;
    }

    public bool IsDescriptionValid(string description)
    {
        if (string.IsNullOrEmpty(description.Trim()))
        {
            return true;
        }

        if (description.Length < 5 || description.Length > 200)
        {
            return false;
        }

        return true;
    }


    public bool IsGenreValid(string genre)
    {
        if (string.IsNullOrEmpty(genre.Trim()))
        {
            return true;
        }

        if (genre.Length < 2 || genre.Length > 10)
        {
            return false;
        }

        if (!Genres.Contains(genre))
        {
            return false;
        }

        foreach (char i in characters)
        {
            if (genre.Contains(i))
            {
                return false;
            }
        }

        foreach (char i in digits)
        {
            if (genre.Contains(i))
            {
                return false;
            }
        }
        return true;
    }
    public bool IsDateValid(string date)
    {
        IsDateFormatValid = Regex.IsMatch(date, @"^\d{2}-\d{2}-\d{4}$");

        if (string.IsNullOrEmpty(date.Trim()))
        {
            return true;
        }

        if (!IsDateFormatValid)
        {
            return false;
        }

        foreach (char i in characters)
        {
            if (date.Contains(i))
            {
                return false;
            }
        }

        foreach (char i in date)
        {
            if (char.IsLetter(i))
            {
                return false;
            }

        }

        return true;
    }

    public bool IsTimeValid(string time)
    {
        IsTimeFormatValid = Regex.IsMatch(time, @"^\d{2}:\d{2}$");

        if (string.IsNullOrEmpty(time.Trim()))
        {
            return true;
        }

        if (!IsTimeFormatValid)
        {
            return false;
        }

        foreach (char i in characters)
        {
            if (time.Contains(i))
            {
                return false;
            }
        }
        return true;
    }
    public bool IsDurationValid(string duration)
    {
        IsDurationFormatValid = Regex.IsMatch(duration, @"^\d{1}:\d{2}$");

        if (string.IsNullOrEmpty(duration.Trim()))
        {
            return true;
        }

        if (!IsDurationFormatValid)
        {
            return false;
        }

        foreach (char i in characters)
        {
            if (duration.Contains(i))
            {
                return false;
            }
        }
        return true;
    }
    public bool IsBBFCValid(int bbfc)
    {
        if (string.IsNullOrEmpty(bbfc.ToString().Trim()))
        {
            return false;
        }

        if (bbfc != 3 && bbfc != 9 && bbfc != 12 && bbfc != 15 && bbfc != 18)
        {
            return false;
        }
        return true;
    }
}