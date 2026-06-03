using System.Reflection.PortableExecutable;
using System.Text.RegularExpressions;
public class MovieLogic
{
    private static MovieAccess _Access = new(); 
    public bool IsDateFormatValid; 
    public bool IsTimeFormatValid; 
    public bool IsDurationFormatValid;
    public List<int> AuditoriumIds = [1, 2, 3];
    public  List<int> BBFCs = [3 ,9 ,12 ,15 , 18 ]; 
    public List<string> Genres = ["Fantasy","Drama", "Comedy", "Crime", "Adventure", "Western"];
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
        if (string.IsNullOrEmpty(Id.ToString()))
        {
            return false; 
        }

        foreach (int i in AuditoriumIds)
        {
            if (Id == i)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        return true;
    }

    public bool IsTitleValid(string title)
    {
        if (string.IsNullOrEmpty(title.Trim()))
        {
            return false; 
        }

        if (title.Length < 2 || title.Length > 30)
        {
            return false; 
        }

        return true;
    }

    public bool IsGenreValid(string genre)
    {
        if (string.IsNullOrEmpty(genre.Trim()))
        {
            return false; 
        }

        if (genre.Length < 2 || genre.Length > 10)
        {
            return false; 
        }
        
        if (!Genres.Contains(genre))
        {
            return false;    
        }
            
        return true;
    }

    public bool IsDescriptionValid(string description)
    {
        if (string.IsNullOrEmpty(description.Trim()))
        {
            return false; 
        }

        if (description.Length < 5 || description.Length > 200)
        {
            return false; 
        }

        return true;
    }
    public bool IsDateValid(string date)
    {
        IsDateFormatValid = Regex.IsMatch(date,  @"^\d{2}-\d{2}-\d{4}$");

        if (string.IsNullOrEmpty(date.Trim()))
        {
            return false; 
        }

        if (!IsDateFormatValid)
        {
            return false; 
        }

        // add symbol check
        // cant be past date 
        // day 
        // month


        return true; 
    }

    public bool IsTimeValid(string time)
    {
        IsTimeFormatValid = Regex.IsMatch(time, @"^\d{2}:\d{2}$");

        if (string.IsNullOrEmpty(time))
        {
            return false; 
        }

        if (!IsTimeFormatValid)
        {
            return false; 
        }

        // between 00 and 23 
        // between 00 - 59

        // add symbol check
        return true;
    }
    public bool IsDurationValid(string duration)
    {
        IsDurationFormatValid = Regex.IsMatch(duration, @"^\d{1}:\d{2}$");

        if (string.IsNullOrEmpty(duration))
        {
            return false; 
        }

        if (!IsDurationFormatValid)
        {
            return false; 
        }

        // symbol check
        return true;
    }
    public bool IsBBFCValid(int bbfc)
    {
        if (string.IsNullOrEmpty(bbfc.ToString()))
        {
            return false; 
        } 

        foreach (int i in BBFCs)
        {
            if (bbfc == i)
            {
                return true;
            }
        }
        return true; 
    }
}