public class OrderModel
{
    public long Id { get; set; }
    public long? AccountId { get; set; }
    public int MovieId { get; set; }
    public int SeatId { get; set; }
    public string Date { get; set; }
    public string FileNameQRCode { get; set; }
    public int? PartySize { get; set; }

    public OrderModel(long id, long? accountId, int movieId, int seatId, string date, string fileNameQRCode, int? partySize)
    {
        Id = id;
        AccountId = accountId;
        MovieId = movieId;
        SeatId = seatId;
        Date = date;
        FileNameQRCode = fileNameQRCode;
        PartySize = partySize;
    }
    public OrderModel(long? accountId, int movieId, int seatId, string date, string fileNameQRCode, int? partySize)
    {
        AccountId = accountId;
        MovieId = movieId;
        SeatId = seatId;
        Date = date;
        FileNameQRCode = fileNameQRCode;
        PartySize = partySize;
    }
}

