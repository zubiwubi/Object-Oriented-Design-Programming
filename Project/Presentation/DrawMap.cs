/*
        //  (ZAAL NAAM)  
        //     ● ● ●   ● ● ●
        //     ● ● ● ● ● ● ●
        //     ● ● ●   ● ● ●

        //     ════════════════
        //     │   SCREEN     │
        //     ════════════════
*/
public class DrawMap
{
    PriceSeatsLogic priceSeats = new();
    int currentRow = 0;
    int currentCol = 0;

    // start position
    public void StartPosition(char[,] auditorium)
    {
        // loop through the whole map
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
    // seat selection
    public void SeatSelection(string caller, char[,] auditorium, string name, string info, string screen, string callerType)
    {
        while (true)
        {
            Display.ClearScreen();
            // header
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.WriteLine($" {name} ");
            Console.ResetColor();

            // // legenda
            // Console.WriteLine("\nLegend:");
            // Console.WriteLine(
            //     "Red       =   Unavailable\n" +
            //     "Grey      =   Available\n" +
            //     "Green     =   Selected\n\n"
            //     );

            // MAP
            // loop through the map
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

                    double price = priceSeats.PriceSeatCalc(name, i, j);

                    if (price == 38.99)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else if (price == 29.99)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }

                    Console.Write(" ● ");
                    Console.ResetColor();
                }
                Console.WriteLine();
            }

            // scherm printen
            Console.WriteLine();
            Console.WriteLine(screen);

            // informatie
            Console.WriteLine();
            Console.WriteLine(info);
            if (caller == "")
            {
                Console.WriteLine();
                Console.WriteLine($"Press enter to return to main menu");
                Console.ReadKey();
                return;
            }

            if (caller == "reserve")
            {
                Console.WriteLine("Use the Arrows to move");
                Console.WriteLine("Press Enter to confirm | Escape to return\n");
                bool exit = SeatSelectionArrow(auditorium, name, callerType);
                if (exit)
                    return;
            }

        }
    }

    public bool SeatSelectionArrow(char[,] auditorium, string name, string callerType = "")
    {
        Console.WriteLine();
        double priceSeat = priceSeats.PriceSeatCalc(name, currentRow, currentCol);
        Console.WriteLine($"Price current seat: {priceSeat}");

        // input 
        var key = Console.ReadKey(true).Key;
        switch (key)
        {
            // seat selection with arrow keys
            case ConsoleKey.UpArrow:
                int newRow = currentRow - 1;
                if (newRow >= 0 && auditorium[newRow, currentCol] == '●')
                {
                    currentRow = newRow;
                }
                break;

            case ConsoleKey.DownArrow:
                int newRow2 = currentRow + 1;
                if (newRow2 < auditorium.GetLength(0) && auditorium[newRow2, currentCol] == '●')
                {
                    currentRow = newRow2;
                }
                break;

            case ConsoleKey.LeftArrow:
                int newCol = currentCol - 1;
                if (newCol >= 0 && auditorium[currentRow, newCol] == '●')
                {
                    currentCol = newCol;
                }
                break;

            case ConsoleKey.RightArrow:
                int newCol2 = currentCol + 1;
                if (newCol2 < auditorium.GetLength(1) && auditorium[currentRow, newCol2] == '●')
                {
                    currentCol = newCol2;
                }
                break;

            // confirm
            case ConsoleKey.Enter:
                int seatNum = int.Parse($"{currentCol}{currentRow}");
                Console.WriteLine($"Your chosen seat is:\nColumn: {currentCol} Row: {currentRow}");
                Console.WriteLine($"Press enter to continue");
                Console.ReadKey();
                ReservationFoodMenu.FoodOrderChecker(ReservationMovie.ChosenMovieId, seatNum, callerType); // REDIRECT TO FOOD ORDER
                //Payment.Order(ReservationMovie.ChosenMovieId, seatNum, callerType);
                return true;

            // exit
            case ConsoleKey.Escape:
                return true;
        }
        return false;
    }

    // draw auditorium
    public char[,] DrawAuditorium(int[] seatsRow)
    {
        // beslissing van de rijen en kolommen
        int rows = seatsRow.Length;
        int maxSeats = seatsRow.Max();

        char[,] auditorium = new char[rows, maxSeats];  // maxSeats = breedste rij

        for (int i = 0; i < rows; i++)
        {
            // leeg maken
            for (int j = 0; j < maxSeats; j++)
            {
                auditorium[i, j] = ' ';     // leeg
            }

            int spaces = (maxSeats - seatsRow[i]) / 2;

            for (int j = 0; j < seatsRow[i]; j++)
            {
                auditorium[i, j + spaces] = '●';    // j + spaces = centered
            }
        }

        Console.WriteLine();

        return auditorium;
    }
}
