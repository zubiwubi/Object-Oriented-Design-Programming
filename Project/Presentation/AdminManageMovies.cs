using System.Data;
using System.Reflection;
public class AdminManageMovies : IPage
{
    private static MovieLogic movieLogic = new(); 
    public static ConsoleKeyInfo Key { get; set; }
    public static int Arrow { get; set; }
    public static int MenuChoice { get; set; }
    public static bool IsOptionSelected { get; set; }
    public static List<string> Menu {get; set;} = new() {"Yes","No"};
    public static List<string> ManageOptions = new() {"Add movie", "Update movie", "Delete movie", "go back"};
    public static void StartPage()
    {
        Display.ClearScreen(); 
        Console.WriteLine(@$"


  __  __                                                     _           
 |  \/  | __ _ _ __   __ _  __ _  ___   _ __ ___   _____   _(_) ___  ___ 
 | |\/| |/ _` | '_ \ / _` |/ _` |/ _ \ | '_ ` _ \ / _ \ \ / / |/ _ \/ __|
 | |  | | (_| | | | | (_| | (_| |  __/ | | | | | | (_) \ V /| |  __/\__ \
 |_|  |_|\__,_|_| |_|\__,_|\__, |\___| |_| |_| |_|\___/ \_/ |_|\___||___/
                           |___/                                         

            
        ");

        Display.ClearScreen();
        Tools.ColorYellowMessage($"DISCLAIMER: press 'BACKSPACE' to go back");
        Tools.ColorYellowMessage($"press 'ENTER' to continue");
        Key = Console.ReadKey();

        if (Key.Key == ConsoleKey.Backspace)
        {
            Tools.ProgressBar();
            AdminHomePage.CreateAdminMenu();
        }
        else if (Key.Key == ConsoleKey.Enter)
        {
            Tools.ProgressBar(); 
            CreateManageMenu(); 
        }
    }


    public  static void CreateManageMenu()
    {
        IsOptionSelected = false; 
        while (!IsOptionSelected)
        {
            Display.ClearScreen();
            Tools.ColorYellowMessage("DISCLAIMER: press 'BACKSPACE' to go back.");
            Tools.ColorYellowMessage("press 'ENTER' to select a choice.");

            for (int i = 0; i < ManageOptions.Count; i++)
            {
                if (i == Arrow)
                {
                    Console.Write("➥ ");
                    Tools.ColorMagentaMessage($" [{i + 1}] {ManageOptions[i]}");
                }
                else
                {
                    Console.WriteLine($" [{i + 1}] {ManageOptions[i]}");
                }
            }

            Key = Console.ReadKey();
            if (Key.Key == ConsoleKey.UpArrow)
            {
                Arrow--;

                if (Arrow < 0)
                {
                    Arrow = ManageOptions.Count - 1;
                }
            }
            else if (Key.Key == ConsoleKey.DownArrow)
            {
                Arrow++;

                if (Arrow >= ManageOptions.Count)
                {
                    Arrow = 0;
                }
            }
            else if (Key.Key == ConsoleKey.Enter)
            {
                MenuChoice = Arrow;
                IsOptionSelected = true;
            }
            else if (Key.Key == ConsoleKey.Backspace)
            {
                Tools.ProgressBar();
                AdminHomePage.CreateAdminMenu();
            }
        }
        
        switch (MenuChoice)
        {
            case 0:
                Tools.ProgressBar();
                AddMovie();
                break;
            case 1:
                Tools.ProgressBar();
                UpdateMovie();
                break;
            case 2: 
                Tools.ProgressBar(); 
                DeleteMovie(); 
                break; 
            case 3:
                Tools.ProgressBar();
                AdminHomePage.CreateAdminMenu(); 
                break;
        }   
    
    }

    public static void AddMovie()
    {
        Display.ClearScreen(); 

        int LocationId = AskLocationId(); 
        string Title = AskTitle();
        string Genre = AskGenre();
        string Description = AskDescription();
        string Date = AskDate();
        string StartTime = AskStartTime(); 
        string EndTime = AskEndTime();  
        string Duration = AskDuration(); 
        int BBFC = AskBBFC(); 
            
        
        MovieModel movie = new MovieModel(LocationId, Title, Genre, Description, Date, StartTime, EndTime, Duration, BBFC);  
        MovieModel CheckMovieExist = movieLogic.CheckMovieExist(movie)!; 

        if (CheckMovieExist != null)
        {
            Tools.ErrorMessage("this item already exists!");
            Tools.ColorYellowMessage("DISCLAIMER: press 'BACKSPACE' to go back");
            Key = Console.ReadKey(); 
            if (Key.Key == ConsoleKey.Backspace)
            {
                Tools.ProgressBar();
                CreateManageMenu(); 
            }
        }
        else
        {
            movieLogic.Add(movie); 
            Tools.ApproveMessage($"'{movie.Title}' succesfully added!! ✅✅✅"); 
            Tools.ColorYellowMessage("DISCLAIMER: press 'ENTER' to go back to the menu");
            Key = Console.ReadKey()!;

            if (Key.Key == ConsoleKey.Enter)
            {
                Tools.ProgressBar(); 
                CreateManageMenu(); 
            } 
        }
    }
    public static void UpdateMovie()
    {
        List<MovieModel> CurrentMovies = movieLogic.GetAllMovies(); 
        IsOptionSelected = false; 
        while (!IsOptionSelected)
        {
            Display.ClearScreen(); 

            for (int i = 0; i < CurrentMovies.Count; i++)
            {
                if (i == Arrow)
                {
                     Console.Write("➥ ");
                    Tools.ColorMagentaMessage($"[{i + 1}] TITLE: {CurrentMovies[i].Title}");
                    Console.WriteLine("❀° ┄─────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────╮");
                    Tools.ColorMagentaMessage($@"AUDITORIUM: {CurrentMovies[i].LocationId}  | GENRE: {CurrentMovies[i].Genre}  DATE: {CurrentMovies[i].Date}
                    | {CurrentMovies[i].StartTime} | {CurrentMovies[i].EndTime} | {CurrentMovies[i].Duration} | {CurrentMovies[i].BBFC}");
                    Console.WriteLine("╰────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────┄ °❀");

                    Console.WriteLine($"DESCRIPTION: {CurrentMovies[i].Description}");
                }
                else
                {
                    Console.WriteLine($"[{i + 1}] TITLE: {CurrentMovies[i].Title}");
                    Console.WriteLine("❀° ┄─────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────╮");
                    Console.WriteLine($@"AUDITORIUM: {CurrentMovies[i].LocationId} | GENRE: {CurrentMovies[i].Genre}  DATE: {CurrentMovies[i].Date}
                    | {CurrentMovies[i].StartTime} | {CurrentMovies[i].EndTime} | {CurrentMovies[i].Duration} | {CurrentMovies[i].BBFC}");
                    Console.WriteLine("╰────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────┄ °❀");

                    Console.WriteLine($"DESCRIPTION: {CurrentMovies[i].Description}");
                    Console.WriteLine();
                }
            }

            Key = Console.ReadKey();
            if (Key.Key == ConsoleKey.UpArrow)
            {
                Arrow--;

                if (Arrow < 0)
                {
                    Arrow = CurrentMovies.Count - 1;
                }
            }
            else if (Key.Key == ConsoleKey.DownArrow)
            {
                Arrow++;

                if (Arrow >= CurrentMovies.Count)
                {
                    Arrow = 0;
                }
            }
            else if (Key.Key == ConsoleKey.Backspace)
            {
                Tools.ProgressBar();
                CreateManageMenu();
            }
            else if (Key.Key == ConsoleKey.Enter)
            {
                MenuChoice = Arrow;
                IsOptionSelected = true;

                Display.ClearScreen(); 

                Console.WriteLine($"Currently selected item: {CurrentMovies[MenuChoice].Title}");

                int LocationId = AskLocationId(); 
                string Title = AskTitle();
                string Genre = AskGenre();
                string Description = AskDescription();
                string Date = AskDate();
                string StartTime = AskStartTime(); 
                string EndTime = AskEndTime();  
                string Duration = AskDuration(); 
                int BBFC = AskBBFC(); 
                      
                MovieModel movie = new MovieModel(LocationId, Title, Genre, Description, Date, StartTime, EndTime, Duration, BBFC);  
                MovieModel CheckMovieExist = movieLogic.CheckMovieExist(movie)!; 

                if (CheckMovieExist != null)
                {
                    Tools.ErrorMessage("this item already exists!");
                    Tools.ColorYellowMessage("DISCLAIMER: press 'BACKSPACE' to go back");
                    Key = Console.ReadKey(); 
                    if (Key.Key == ConsoleKey.Backspace)
                    {
                        Tools.ProgressBar();
                        CreateManageMenu(); 
                    }
                }
                else
                {
                    movie.Id = CurrentMovies[MenuChoice].Id; 
                    movieLogic.Update(movie); 
                    Tools.ApproveMessage($"'{CurrentMovies[MenuChoice].Title}' succesfully updated to:'{movie.Title}'!! ✅✅✅"); 
                    Tools.ColorYellowMessage("DISCLAIMER: press 'ENTER' to go back to the menu");
                    Key = Console.ReadKey()!;

                    if (Key.Key == ConsoleKey.Enter)
                    {
                        Tools.ProgressBar(); 
                        CreateManageMenu(); 
                    }    
                }
            }
        }
    }
    public static void DeleteMovie()
    {
        List<MovieModel> CurrentMovies = movieLogic.GetAllMovies(); 
        IsOptionSelected = false; 
        while (!IsOptionSelected)
        {
            Display.ClearScreen(); 

            for (int i = 0; i < CurrentMovies.Count; i++)
            {
                if (i == Arrow)
                {
                    Console.Write("➥ ");
                    Tools.ColorMagentaMessage($"[{i + 1}] TITLE: {CurrentMovies[i].Title}");
                    Console.WriteLine("❀° ┄─────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────╮");
                    Tools.ColorMagentaMessage($@"AUDITORIUM: {CurrentMovies[i].LocationId}  | GENRE: {CurrentMovies[i].Genre}  DATE: {CurrentMovies[i].Date}
                    | {CurrentMovies[i].StartTime} | {CurrentMovies[i].EndTime} | {CurrentMovies[i].Duration} | {CurrentMovies[i].BBFC}");
                    Console.WriteLine("╰────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────┄ °❀");

                    Console.WriteLine($"DESCRIPTION: {CurrentMovies[i].Description}");
                }
                else
                {
                    Console.WriteLine($"[{i + 1}] TITLE: {CurrentMovies[i].Title}");
                    Console.WriteLine("❀° ┄─────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────╮");
                    Console.WriteLine($@"AUDITORIUM: {CurrentMovies[i].LocationId} | GENRE: {CurrentMovies[i].Genre}  DATE: {CurrentMovies[i].Date}
                    | {CurrentMovies[i].StartTime} | {CurrentMovies[i].EndTime} | {CurrentMovies[i].Duration} | {CurrentMovies[i].BBFC}");
                    Console.WriteLine("╰────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────────┄ °❀");

                    Console.WriteLine($"DESCRIPTION: {CurrentMovies[i].Description}");
                    Console.WriteLine();
                }  
            }

            Key = Console.ReadKey();
            if (Key.Key == ConsoleKey.UpArrow)
            {
                Arrow--;

                if (Arrow < 0)
                {
                    Arrow = CurrentMovies.Count - 1;
                }
            }
            else if (Key.Key == ConsoleKey.DownArrow)
            {
                Arrow++;

                if (Arrow >= CurrentMovies.Count)
                {
                    Arrow = 0;
                }
            }
            else if (Key.Key == ConsoleKey.Backspace)
            {
                Tools.ProgressBar();
                CreateManageMenu();
            }
            else if (Key.Key == ConsoleKey.Enter)
            {
                MenuChoice = Arrow;
                IsOptionSelected = true;


                int subArrow = 0;
                int subMenuChoice = 0;
                bool IsSelected = false;
                ConsoleKeyInfo subKey;

                while (!IsSelected)
                {
                    Display.ClearScreen(); 
                    Console.WriteLine($"Currently selected item: {CurrentMovies[MenuChoice].Title}");
                    Tools.ErrorMessage("[WARNING] THIS ACTION CAN'T BE UNDONE [WARNING]");
                    Tools.ColorYellowMessage("Are you sure you want to delete this item?");
                    for (int i = 0; i < Menu.Count; i++)
                    {
                        if (i == subArrow)
                        {
                            Console.Write("➥ ");
                            Tools.ColorMagentaMessage($"[{i + 1}] {Menu[i]}");
                        }
                        else
                        {
                            Console.WriteLine($"[{i + 1}] {Menu[i]}"); 
                        }

                    }

                    subKey = Console.ReadKey();
                    if (subKey.Key == ConsoleKey.UpArrow)
                    {
                        subArrow--;

                        if (subArrow < 0)
                        {
                            subArrow = Menu.Count - 1;
                        }
                    }
                    else if (subKey.Key == ConsoleKey.DownArrow)
                    {
                        subArrow++;

                        if (subArrow >= Menu.Count)
                        {
                            subArrow = 0;
                        }
                    }

                    else if (subKey.Key == ConsoleKey.Enter)
                    {
                        subMenuChoice = subArrow;
                        IsSelected = true;
                    }

                }

                switch (subMenuChoice)
                {
                    case 0: 
                        Display.ClearScreen();
                        movieLogic.UpdateBool(CurrentMovies[MenuChoice]); 
                        Tools.ApproveMessage($"'{CurrentMovies[MenuChoice].Title}' has been successfully deleted!");
                        Tools.ColorYellowMessage("press 'ENTER' to go back");
                        Key = Console.ReadKey(); 
                        if (Key.Key == ConsoleKey.Enter)
                        {
                            Tools.ProgressBar(); 
                            CreateManageMenu(); 
                        }
                        break;
                    case 1: 
                        Tools.ErrorMessage("deleting cancelled.");
                        Tools.ColorYellowMessage("press 'ENTER' to go back");
                        Key = Console.ReadKey(); 
                        if (Key.Key == ConsoleKey.Enter)
                        {
                            Tools.ProgressBar(); 
                            CreateManageMenu();                
                        }
                        break; 
                }

            }
            
        }   
    }
    private static int AskLocationId()
    {
        Display.ClearScreen(); 
        Tools.ColorYellowMessage("DISCLAIMER: you can only enter:\n1 (auditorium 1)\n2 (auditorium 2)\n3 (auditorium 3)");

        string LocationIdString;
        int LocationId = 0;
        do
        {
            Console.WriteLine("Enter the number of the auditorium [REQUIRED FIELD]: ");
            LocationIdString = Console.ReadLine()!;

            if (string.IsNullOrEmpty(LocationIdString))
            {
                Tools.ErrorMessage("location id can't be empty!!");
                continue; 
            }

            if (!int.TryParse(LocationIdString, out int locationId))
            {
                Tools.ErrorMessage("invalid Id: must be 1, 2, or 3!!");
                continue; 
            }
            else
            {
                LocationId = locationId; 
            }

            if (!movieLogic.IsLocationIdValid(LocationId))
            {
                Tools.InvalidLocationIdPrint(LocationId); 
            }

        } while (!movieLogic.IsLocationIdValid(LocationId)); 
        return LocationId; 
    }
    private static string AskTitle()
    {
        Display.ClearScreen(); 
        Tools.ColorYellowMessage("DISCLAIMER: Title can't be empty\nTitle can't be less then 2 characters and/or more then 30 characters");
        string title;
        do
        {
            Console.WriteLine("Enter the movie title [REQUIRED FIELD]: ");
            title = Console.ReadLine()!; 

            if (!movieLogic.IsTitleValid(title))
            {
                Tools.InvalidTitlePrint(title); 
            }

        } while (!movieLogic.IsTitleValid(title)); 
        return title; 
    }
    private static string AskGenre()
    {
        Display.ClearScreen(); 
        Tools.ColorYellowMessage("DISCLAIMER: Genre can't be empty\nGenre can't be less then 2 characters and/or more then 10 characters\nGenre can only be:");
        Tools.ColorYellowMessage("Fantasy, Drama\nCrime, Adventure\nComedy, Western");
        string genre;
        do
        {
            Console.WriteLine("Enter the movie genre [REQUIRED FIELD]: ");
            genre = Console.ReadLine()!; 

            if (!movieLogic.IsGenreValid(genre))
            {
                Tools.InvalidGenrePrint(genre); 
            }

        } while (!movieLogic.IsGenreValid(genre)); 
        return genre; 
    }
    private static string AskDescription()
    {
        Display.ClearScreen(); 
        Tools.ColorYellowMessage("DISCLAIMER: Description can't be empty\nDescription can't be less then 2 characters and/or more then 200 characters");
        string description;
        do
        {
            Console.WriteLine("Enter the movie description [REQUIRED FIELD]: ");
            description = Console.ReadLine()!; 

            if (!movieLogic.IsDescriptionValid(description))
            {
                Tools.InvalidDescriptionPrint(description); 
            }

        } while (!movieLogic.IsDescriptionValid(description)); 
        return description; 
    }
    private static string AskDate()
    {
        Display.ClearScreen(); 
        Tools.ColorYellowMessage("DISCLAIMER: Date can't be empty\nDate must be in corrent format : DD-MM-YYYY");
        string date;
        do
        {
            Console.WriteLine("Enter the date [REQUIRED FIELD]: ");
            date = Console.ReadLine()!; 

            if (!movieLogic.IsDateValid(date))
            {
                Tools.InvalidDatePrint(date); 
            }

        } while (!movieLogic.IsDateValid(date) || !SearchMoviesLogic.DateInPastValidation(date)); 
        return date; 
    }
    private static string AskStartTime()
    {
        Display.ClearScreen(); 
        Tools.ColorYellowMessage("DISCLAIMER: Start time can't be empty\nstart time must be in correct format: 00:00");
        string startTime;
        do
        {
            Console.WriteLine("Enter the start time [REQUIRED FIELD]: ");
            startTime = Console.ReadLine()!; 

            if (!movieLogic.IsTimeValid(startTime))
            {
                Tools.InvalidTimePrint(startTime); 
            }

        } while (!movieLogic.IsTimeValid(startTime)); 
        return startTime; 
    }
    private static string AskEndTime()
    {
        Display.ClearScreen(); 
        Tools.ColorYellowMessage("DISCLAIMER: End time can't be empty\nend time can't be same as the start time\nend time must be in correct format: 00:00");
        string endTime;
        do
        {
            Console.WriteLine("Enter the end time [REQUIRED FIELD]: ");
            endTime = Console.ReadLine()!; 

            if (!movieLogic.IsTimeValid(endTime))
            {
                Tools.InvalidTimePrint(endTime); 
            }

        } while (!movieLogic.IsTimeValid(endTime)); 
        return endTime; 
    }
    private static string AskDuration()
    {
        Display.ClearScreen(); 
        Tools.ColorYellowMessage("DISCLAIMER: Duration can't be empty\nDuration must be in correct format 0:00");
        string duration;
        do
        {
            Console.WriteLine("Enter the Duration [REQUIRED FIELD]: ");
            duration = Console.ReadLine()!; 

            if (!movieLogic.IsDurationValid(duration))
            {
                Tools.InvalidDurationPrint(duration); 
            }

        } while (!movieLogic.IsDurationValid(duration)); 
        return duration; 
    }
    private static int AskBBFC()
    {
        Display.ClearScreen(); 
        Tools.ColorYellowMessage("DISCLAIMER: BBFC can't be empty\nBBFC can only be: 3, 9, 12, 15, 18");

        string bbfcString; 
        int Bbfc = 0; 
        do
        {
            Console.WriteLine("Enter the BBFC REQUIRED FIELD]: ");
            bbfcString = Console.ReadLine()!;

            if (string.IsNullOrEmpty(bbfcString))
            {
                Tools.ErrorMessage("BBFC can't be empty!!");
                continue; 
            }

            if (!int.TryParse(bbfcString, out int bbfc))
            {
                Tools.ErrorMessage("invalid BBFC: must be 3, 9, 12 ,15, 18!!");
                continue;
            }
            else
            {
                Bbfc = bbfc; 
            }

            if (!movieLogic.IsBBFCValid(Bbfc))
            {
                Tools.InvalidBBFCPrint(Bbfc); 
            }

        } while (!movieLogic.IsBBFCValid(Bbfc)); 
        return Bbfc; 
    }
}