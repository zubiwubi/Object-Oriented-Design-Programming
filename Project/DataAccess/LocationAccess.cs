using Microsoft.Data.Sqlite;

using Dapper;
public class LocationAccess
{
    private SqliteConnection _connection = new SqliteConnection($"Data Source=DataSources/project.db");

    private string Table = "Location";

    public void Write(LocationModel location)
    {
        string sql = $"INSERT INTO {Table} (address, description, maxSeatAmount) VALUES (@Address, @Description, @MaxSeatAmount)";
        _connection.Execute(sql, location);
    }

    public LocationModel? GetById(int id)
    {
        string sql = $"SELECT * FROM {Table} WHERE id = @Id";
        return _connection.QueryFirstOrDefault<LocationModel>(sql, new { Id = id });
    }

    public void Update(LocationModel location)
    {
        string sql = $"UPDATE {Table} SET address = @Address, description = @Description, maxSeatAmount = @MaxSeatAmount WHERE id = @Id";
        _connection.Execute(sql, location);
    }

    public void Delete(LocationModel location)
    {
        string sql = $"DELETE FROM {Table} WHERE id = @Id";
        _connection.Execute(sql, new { Id = location.Id });
    }



}