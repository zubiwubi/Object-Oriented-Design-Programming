using Microsoft.Data.Sqlite;
using Dapper;

public class MovieAccess
{
    private SqliteConnection _connection = new SqliteConnection($"Data Source=DataSources/project.db");

    private string Table = "Movie";

    public void Add(MovieModel movie)
    {
        string sql = $"INSERT INTO {Table} (LocationId, Title, Genre, Description, Date, StartTime, EndTime, Duration, BBFC, IsVisible) VALUES (@LocationId, @Title, @Genre, @Description, @Date, @StartTime, @EndTime, @Duration,@BBFC, @IsVisible)";
        _connection.Execute(sql, movie);
    }
    public void Update(MovieModel movie)
    {
        string sql = $"UPDATE {Table} SET LocationId = @LocationId, Title = @Title, Genre = @Genre, Description = @Description, Date = @Date, StartTime = @StartTime, EndTime = @EndTime, Duration = @Duration, BBFC = @BBFC WHERE id = @Id";
        _connection.Execute(sql, movie);
    }
    public void UpdateBool(MovieModel movie) 
    {
        string sql = $"UPDATE {Table} SET IsVisible = 0 WHERE id = @Id";
        _connection.Execute(sql, movie);
    }   
    public MovieModel? CheckMovieExists(MovieModel movie)
    {
        string sql = $"SELECT * FROM {Table} WHERE LocationId = @LocationId AND Title = @Title AND Genre = @Genre AND Description = @Description AND Date = @Date AND StartTime = @StartTime AND EndTime = @EndTime AND Duration = @Duration AND BBFC = @BBFC";
        return _connection.QueryFirstOrDefault<MovieModel>(sql, new {movie.LocationId, movie.Title, movie.Genre, movie.Description, movie.Date, movie.StartTime, movie.EndTime, movie.Duration, movie.BBFC});
    }

    public List<MovieModel> GetAllMovies()
    {
        string sql = $"SELECT * FROM {Table} WHERE IsVisible = 1";
        return _connection.Query<MovieModel>(sql).ToList();
    }


    public List<MovieModel> GetAll() 
    {
        string sql = $"SELECT * FROM {Table}";
        return _connection.Query<MovieModel>(sql).ToList();
    }

    public MovieModel? GetById(int? id)
    {
        string sql = $"SELECT * FROM {Table} WHERE id = @Id";
        return _connection.QueryFirstOrDefault<MovieModel>(sql, new { Id = id });
    }

}