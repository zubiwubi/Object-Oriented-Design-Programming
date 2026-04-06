using System.Linq;

public class MakeMapLogic
{
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
                auditorium[i, j + spaces] = 'O';    // j + spaces = centered
            }
        }

        Console.WriteLine();

        return auditorium;
    }

    // print auditorium
        public void PrintAuditorium(string name , char[,] auditorium)
    {
        Console.WriteLine(name);

        for (int i = 0; i < auditorium.GetLength(0); i++)
        {
            for (int j = 0; j < auditorium.GetLength(1); j++)
            {
                Console.Write($"[{auditorium[i, j]}]");
            }
            Console.WriteLine();
        }
    }
}
