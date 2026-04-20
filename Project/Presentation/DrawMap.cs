/*
        //  (ZAAL NAAM)  
        //     ● ● ●   ● ● ●
        //     ● ● ● ● ● ● ●
        //     ● ● ●   ● ● ●

        //     ════════════════
        //     │   SCREEN     │
        //     ════════════════
*/

using System.Data.Common;

public class DrawMap
{
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
    public void SeatSelection(char[,] auditorium, string name, string info, string screen)
    {
        while (true)
        {
            Console.Clear();

            Console.WriteLine(name);
            Console.WriteLine();

            // MAP
            // loop through the map
            for (int i = 0; i < auditorium.GetLength(0); i++)
            {
                for (int j = 0; j < auditorium.GetLength(1); j++)
                {
                    if (i == currentRow && j == currentCol)
                    {
                        Console.Write(" X ");
                    }
                    else
                    {
                        Console.Write($" {auditorium[i, j]} ");
                    }
                }
                Console.WriteLine();
            }

            // scherm printen
            Console.WriteLine();
            Console.WriteLine(screen);

            // informatie
            Console.WriteLine();
            Console.WriteLine(info);

            // instructies                
            Console.WriteLine();
            Console.WriteLine("Use the arrows to move");
            Console.WriteLine("Press Enter to confirm | Escape to return");

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
                    Console.WriteLine($"Press enter to continue to payment");
                    Console.ReadKey();
                    Payment.Order(ReservationMovie.ChosenMovieId, seatNum);
                    return;

                // exit
                case ConsoleKey.Escape:
                    return;
            }
        }
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

    // print auditorium
    public void PrintAuditorium(string name, char[,] auditorium)
    {
        Console.WriteLine(name);

        for (int i = 0; i < auditorium.GetLength(0); i++)
        {
            for (int j = 0; j < auditorium.GetLength(1); j++)
            {
                Console.Write($" {auditorium[i, j]} ");
            }
            Console.WriteLine();
        }
    }
}
