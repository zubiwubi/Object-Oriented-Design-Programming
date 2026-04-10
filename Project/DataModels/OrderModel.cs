public class OrderModel
{
    public long Id { get; set; }
    public int CustomerId { get; set; }
    public int MovieId { get; set; }
    public int SeatId { get; set; }
    public int DrinkId { get; set; }
    public int FoodId { get; set; }
    public string Date { get; set; }
    public string FileNameQRCode { get; set; }

    public OrderModel(long id, int customerId, int movieId, int seatId, int drinkId, int foodId, string date, string fileNameQRCode)
    {
        Id = id;
        CustomerId = customerId;
        MovieId = movieId;
        SeatId = seatId;
        DrinkId = drinkId;
        FoodId = foodId;
        Date = date;
        FileNameQRCode = fileNameQRCode;
    }
}

