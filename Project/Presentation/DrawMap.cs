public class DrawMap
{
    private PriceSeatsLogic priceSeats = new PriceSeatsLogic();

    public List<(int Row, int Col)> ChosenSeats = new();

    private int currentRow = 0;
    private int currentCol = 0;

    public void StartPosition(char[,] auditorium)
    {
        for (int i = 0; i < auditorium.GetLength(0); i++)
        {
            for (int j = 0; j < auditorium.GetLength(1); j++)
            {
                if (auditorium[i, j] == '●')
                {
                    currentRow = i;
                    currentCol = j;
                    return;
                }
            }
        }
    }
    public void SeatSelection(string caller, char[,] auditorium, string name, string info, string screen, string callerType, int locationId)
    {
        while (true)
        {
            Display.ClearScreen();

            var seats = PriceSeatsLogic.seatAccess.GetSeatsByLocation(locationId);

            // HEADER
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.WriteLine($" {name} ");
            Console.ResetColor();

            for (int i = 0; i < auditorium.GetLength(0); i++)
            {
                for (int j = 0; j < auditorium.GetLength(1); j++)
                {
                    bool isSelected = i == currentRow && j == currentCol;
                    bool isSeat = auditorium[i, j] == '●';

                    if (!isSeat)
                    {
                        Console.Write("   ");
                        continue;
                    }

                    if (isSelected)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write(" X ");
                        Console.ResetColor();
                        continue;
                    }

                    var seat = seats.FirstOrDefault(s => s.Row == i && s.Col == j);

                    if (seat != null)
                    {
                        if (seat.Type == "premium")
                            Console.ForegroundColor = ConsoleColor.Red;
                        else if (seat.Type == "standard")
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                        else
                            Console.ForegroundColor = ConsoleColor.Gray;
                    }

                    Console.Write(" ● ");
                    Console.ResetColor();
                }

                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine(screen);
            Console.WriteLine();
            Console.WriteLine(info);

            if (caller == "")
            {
                Console.WriteLine("\nPress enter to return to main menu");
                Console.ReadKey();
                return;
            }

            if (caller == "reserve")
            {
                Console.WriteLine("\nUse arrows | Enter = confirm | ESC = back");
                bool exit = SeatSelectionArrow(auditorium, locationId, callerType, "", "", caller);
                if (exit) return;
            }
            else if (caller == "Admin")
            {
                Console.WriteLine("\nUse arrows | Enter = confirm | ESC = back");
                bool exit = SeatSelectionArrow(auditorium, locationId, callerType, info, screen, caller);
                if (exit) return;
            }
        }
    }

    public bool SeatSelectionArrow(char[,] auditorium, int locationId, string callerType = "", string info = "", string screen = "", string caller = "")
    {
        Console.WriteLine();

        double priceSeat = priceSeats.PriceSeatCalc(locationId, currentRow, currentCol);
        Console.WriteLine($"Price current seat: {priceSeat}");

        var key = Console.ReadKey(true).Key;

        switch (key)
        {
            case ConsoleKey.UpArrow:
                if (currentRow - 1 >= 0 && auditorium[currentRow - 1, currentCol] == '●')
                    currentRow--;
                break;

            case ConsoleKey.DownArrow:
                if (currentRow + 1 < auditorium.GetLength(0) && auditorium[currentRow + 1, currentCol] == '●')
                    currentRow++;
                break;

            case ConsoleKey.LeftArrow:
                if (currentCol - 1 >= 0 && auditorium[currentRow, currentCol - 1] == '●')
                    currentCol--;
                break;

            case ConsoleKey.RightArrow:
                if (currentCol + 1 < auditorium.GetLength(1) && auditorium[currentRow, currentCol + 1] == '●')
                    currentCol++;
                break;

            case ConsoleKey.Enter:

                string seatNum = $"{currentCol}{currentRow}";

                Console.WriteLine($"Selected seat: Row {currentRow}, Col {currentCol}");
                Console.ReadKey();

                if (caller == "reserve")
                {
                    while (true)
                    {
                        Console.WriteLine(
                            "Q = Quit\nX = Continue with order\nA = Add seats to your order\nR = Reselect last seat\nRA = reset all");

                        string choice = Console.ReadLine();

                        if (choice == "Q" || choice == "q")
                        {
                            ChosenSeats.Clear();
                            AccountHomePage.HomePage();
                        }
                        else if (choice == "X" || choice == "x")
                        {
                            ChosenSeats.Add((currentRow, currentCol));

                            string seatsString = string.Join(", ", ChosenSeats.Select(s => $"({s.Row},{s.Col})"));
                            ChosenSeats.Clear();
                            ReservationFoodMenu.FoodOrderChecker(ReservationMovie.ChosenMovieId, seatsString, callerType);

                        }
                        else if (choice == "A" || choice == "a")
                        {
                            ChosenSeats.Add((currentRow, currentCol));
                            SeatSelection(caller, auditorium, "", info, screen, callerType, locationId);
                        }
                        else if (choice == "R" || choice == "r")
                        {
                            SeatSelection(caller, auditorium, "", info, screen, callerType, locationId);
                        }
                        else if (choice == "RA" || choice == "ra")
                        {
                            ChosenSeats.Clear();
                            SeatSelection(caller, auditorium, "", info, screen, callerType, locationId);
                        }
                        else
                        {
                            Console.WriteLine("Wrong input");
                        }
                    }
                }

                if (callerType == "Admin")
                {
                    while (true)
                    {
                        Console.WriteLine(
                            "Q = Quit\nX = Change Type\nA = Add more to change\nR = Reselect last seat\nRA = reset all");

                        string choice = Console.ReadLine();

                        if (choice == "Q" || choice == "q")
                        {
                            ChosenSeats.Clear();
                            AdminHomePage.Homepage();
                        }
                        else if (choice == "X" || choice == "x")
                        {
                            ChosenSeats.Add((currentRow, currentCol));

                            var copy = new List<(int Row, int Col)>(ChosenSeats);
                            ChosenSeats.Clear();

                            AdminManageSeatPrice.printSeats(copy);
                        }
                        else if (choice == "A" || choice == "a")
                        {
                            ChosenSeats.Add((currentRow, currentCol));
                            SeatSelection(caller, auditorium, "", info, screen, callerType, locationId);
                        }
                        else if (choice == "R" || choice == "r")
                        {
                            SeatSelection(caller, auditorium, "", info, screen, callerType, locationId);
                        }
                        else if (choice == "RA" || choice == "ra")
                        {
                            ChosenSeats.Clear();
                            SeatSelection(caller, auditorium, "", info, screen, callerType, locationId);
                        }
                        else
                        {
                            Console.WriteLine("Wrong input");
                        }
                    }
                }
                else
                {
                    ReservationFoodMenu.FoodOrderChecker(ReservationMovie.ChosenMovieId, seatNum, callerType);
                }

                return true;

            case ConsoleKey.Escape:
                return true;
        }

        return false;
    }

    public char[,] DrawAuditorium(int[] seatsRow, int locationId)
    {
        int rows = seatsRow.Length;
        int maxSeats = seatsRow.Max();

        char[,] auditorium = new char[rows, maxSeats];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < maxSeats; j++)
                auditorium[i, j] = ' ';

            int offset = (maxSeats - seatsRow[i]) / 2;

            for (int j = 0; j < seatsRow[i]; j++)
                auditorium[i, j + offset] = '●';
        }

        return auditorium;
    }
}