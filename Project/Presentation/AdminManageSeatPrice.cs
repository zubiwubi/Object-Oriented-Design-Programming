public class AdminManageSeatPrice
{
    static OverviewMapsSeats seatScreen = new OverviewMapsSeats();
    public static int AudNum;

    public static void SeatSelect()
    {
        while (true)
        {
            Console.WriteLine("Please enter the auditorium number where you want to change the prices (1, 2, 3):");

            if (int.TryParse(Console.ReadLine(), out AudNum) &&
                (AudNum == 1 || AudNum == 2 || AudNum == 3))
            {
                break;
            }

            Console.WriteLine("Invalid input. Try again.");
        }

        seatScreen.Render("Admin", AudNum, "Admin");
    }

    public static void printSeats(List<(int, int)> chosenSeats = null)
    {
        if (chosenSeats == null || chosenSeats.Count == 0)
            return;

        int typeSeat;

        Console.WriteLine("Chosen seats:");
        foreach (var seat in chosenSeats)
        {
            Console.WriteLine($"- {seat}");
        }

        Thread.Sleep(1000);

        while (true)
        {
            Console.WriteLine("To which type do you want to change the selected seats?\n1 = Basic, 2 = Standard, 3 = Premium");

            if (int.TryParse(Console.ReadLine(), out typeSeat) &&
                (typeSeat >= 1 && typeSeat <= 3))
            {
                break;
            }

            Console.WriteLine("Invalid type. Try again.");
        }

        var seatAccess = new SeatAccess();

        string type = typeSeat switch
        {
            1 => "basic",
            2 => "standard",
            3 => "premium",
            _ => "basic"
        };

        foreach (var seat in chosenSeats)
        {
            seatAccess.UpdateSeatType(AudNum, seat.Item1, seat.Item2, type);
        }

        AdminHomePage.Homepage();
    }
}