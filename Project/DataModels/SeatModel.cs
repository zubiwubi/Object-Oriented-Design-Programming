public class SeatModel
{
    public long Id { get; set; }
    public int LocationId { get; set; }
    public int SeatNumber { get; set; }
    public int Tier { get; set; }

    public SeatModel(long id, int locationId, int seatNumber, int tier)
    {
        Id = id;
        LocationId = locationId;
        SeatNumber = seatNumber;
        Tier = tier;
    }
}