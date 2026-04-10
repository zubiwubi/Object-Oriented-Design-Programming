using Microsoft.Data.Sqlite;

using Dapper;

public class MovieAccess
{
    private SqliteConnection _connection = new SqliteConnection($"Data Source=DataSources/project.db");

    private string Table = "Movie";

    public void Write(MovieModel movie)
    {
        string sql = $"INSERT INTO {Table} (locationId, title, genre, description, date, startTime, endTime, duration,bBFC) VALUES (@LocationId, @Title, @Genre, @Description, @Date, @StartTime, @EndTime, @Duration,@BBFC)";
        _connection.Execute(sql, movie);
    }

    public List<MovieModel> GetAll()
    {
        string sql = $"SELECT * FROM {Table}";
        return _connection.Query<MovieModel>(sql).ToList();
    }

    public MovieModel? GetById(int id)
    {
        string sql = $"SELECT * FROM {Table} WHERE id = @Id";
        return _connection.QueryFirstOrDefault<MovieModel>(sql, new { Id = id });
    }

    public MovieModel? GetByTitle(string title)
    {
        string sql = $"SELECT * FROM {Table} WHERE title = @Title";
        return _connection.QueryFirstOrDefault<MovieModel>(sql, new { Title = title });
    }

    public MovieModel? GetByGenre(string genre)
    {
        string sql = $"SELECT * FROM {Table} WHERE genre = @Genre";
        return _connection.QueryFirstOrDefault<MovieModel>(sql, new { Genre = genre });
    }
    public MovieModel? GetByDate(string date)
    {
        string sql = $"SELECT * FROM {Table} WHERE date = @Date";
        return _connection.QueryFirstOrDefault<MovieModel>(sql, new { Date = date });
    }

    public void Update(MovieModel movie)
    {
        string sql = $"UPDATE {Table} SET email = @EmailAddress, password = @Password, fullname = @FullName WHERE id = @Id";
        _connection.Execute(sql, movie);
    }

    public void Delete(MovieModel movie)
    {
        string sql = $"DELETE FROM {Table} WHERE id = @Id";
        _connection.Execute(sql, new { Id = movie.Id });
    }



}