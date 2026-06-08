public class OrderModel
{
    public long Id { get; set; }
    public long? AccountId { get; set; }
    public int? MovieId { get; set; }
    public string? Seat { get; set; }
    public string? Date { get; set; }
    public string FileNameQRCode { get; set; }
    public int? PartySize { get; set; }

    public OrderModel(long id, long? accountId, int? movieId, string? seat, string? date, int? partySize)
    {
        Id = id;
        AccountId = accountId;
        MovieId = movieId;
        Seat = seat;
        Date = date;
        PartySize = partySize;
    }
    public OrderModel(long? accountId, int? movieId, string? seat, string? date, int? partySize)
    {
        AccountId = accountId;
        MovieId = movieId;
        Seat = seat;
        Date = date;
        PartySize = partySize;
    }
    public OrderModel() { }
}

