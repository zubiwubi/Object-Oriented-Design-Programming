public class OrderModel
{
    public long Id { get; set; }
    public long? CustomerId { get; set; }
    public int MovieId { get; set; }
    public int SeatId { get; set; }
    public string Date { get; set; }
    public string FileNameQRCode { get; set; }

    public OrderModel(long id, long? customerId, int movieId, int seatId, string date, string fileNameQRCode)
    {
        Id = id;
        CustomerId = customerId;
        MovieId = movieId;
        SeatId = seatId;
        Date = date;
        FileNameQRCode = fileNameQRCode;
    }
    public OrderModel(long? customerId, int movieId, int seatId, string date, string fileNameQRCode)
    {
        CustomerId = customerId;
        MovieId = movieId;
        SeatId = seatId;
        Date = date;
        FileNameQRCode = fileNameQRCode;
    }
}

