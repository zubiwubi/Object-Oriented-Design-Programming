public class OrderModel
{
    public long Id { get; set; }
    public long? CustomerId { get; set; }
    public int MovieId { get; set; }
    public int SeatId { get; set; }
    public int? OrderedExtrasId { get; set; }
    public string Date { get; set; }
    public string FileNameQRCode { get; set; }
    public int? PartySize { get; set; }

    public OrderModel(long id, long? customerId, int movieId, int seatId, int? orderedExtrasId, string date, string fileNameQRCode, int? partySize)
    {
        Id = id;
        CustomerId = customerId;
        MovieId = movieId;
        SeatId = seatId;
        OrderedExtrasId = orderedExtrasId;
        Date = date;
        FileNameQRCode = fileNameQRCode;
        PartySize = partySize;
    }
    public OrderModel(long? customerId, int movieId, int seatId, int? orderedExtrasId, string date, string fileNameQRCode, int? partySize)
    {
        CustomerId = customerId;
        MovieId = movieId;
        SeatId = seatId;
        OrderedExtrasId = orderedExtrasId;
        Date = date;
        FileNameQRCode = fileNameQRCode;
        PartySize = partySize;
    }
}

