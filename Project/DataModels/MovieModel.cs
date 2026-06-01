public class MovieModel
{
    public long Id { get; set; }
    public int LocationId { get; set; }
    public string Title { get; set; }
    public string Genre { get; set; }
    public string Description { get; set; }
    public string Date { get; set; }
    public string StartTime { get; set; }
    public string EndTime { get; set; }
    public string Duration { get; set; }
    public int BBFC { get; set; }
    public bool IsVisible {get; set;} = true; 

    public MovieModel() { }
    public MovieModel(long id, int locationId, string title, string genre, string description, string date, string startTime, string endTime, string duration, int bBFC)
    {
        Id = id;
        LocationId = locationId;
        Title = title;
        Genre = genre;
        Description = description;
        Date = date;
        StartTime = startTime;
        EndTime = endTime;
        Duration = duration;
        BBFC = bBFC;
    }

    public MovieModel(int locationId, string title, string genre, string description, string date, string startTime, string endTime, string duration, int bBFC)
    {
        LocationId = locationId;
        Title = title;
        Genre = genre;
        Description = description;
        Date = date;
        StartTime = startTime;
        EndTime = endTime;
        Duration = duration;
        BBFC = bBFC;
    }
}