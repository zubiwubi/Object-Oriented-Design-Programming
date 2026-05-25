public class SeatModel
{
    public long Id { get; set; }
    public int LocationId { get; set; }
    public int Row { get; set; }
    public int Col { get; set; }
    public string Type { get; set; }

    public SeatModel(long id, int locationId, int row, int col, string type)
    {
        Id = id;
        LocationId = locationId;
        Row = row;
        Col = col;
        Type = type;
    }
    public SeatModel(int locationId, int row, int col, string type)
    {
        LocationId = locationId;
        Row = row;
        Col = col;
        Type = type;
    }

    public SeatModel()
    {

    }
}
