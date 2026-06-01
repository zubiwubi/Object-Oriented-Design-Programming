public class PriceSeatsLogic
{
    public static SeatAccess seatAccess = new SeatAccess();

    public static List<(int, int)> premiumSeatAud1 = seatAccess.GetSeatCoordinates(1, "premium");
    public static List<(int, int)> standardSeatAud1 = seatAccess.GetSeatCoordinates(1, "standard");
    public static List<(int, int)> premiumSeatAud2 = seatAccess.GetSeatCoordinates(2, "premium");
    public static List<(int, int)> standardSeatAud2 = seatAccess.GetSeatCoordinates(2, "standard");
    public static List<(int, int)> premiumSeatAud3 = seatAccess.GetSeatCoordinates(3, "premium");
    public static List<(int, int)> standardSeatAud3 = seatAccess.GetSeatCoordinates(3, "standard");

    public static List<(int, int)> GetPremium(int audNum) => audNum switch
    {
        1 => premiumSeatAud1,
        2 => premiumSeatAud2,
        3 => premiumSeatAud3,
        _ => throw new Exception("Invalid auditorium")
    };

    public static List<(int, int)> GetStandard(int audNum) => audNum switch
    {
        1 => standardSeatAud1,
        2 => standardSeatAud2,
        3 => standardSeatAud3,
        _ => throw new Exception("Invalid auditorium")
    };


    public double PriceSeatCalc(int locationId, int row, int col)
    {
        var seat = seatAccess
            .GetSeatsByLocation(locationId)
            .FirstOrDefault(s => s.Row == row && s.Col == col);

        if (seat == null)
            return 0.0;

        return seat.Type switch
        {
            "premium" => 38.99,
            "standard" => 29.99,
            "basic" => 9.99,
            _ => 9.99
        };
    }
}