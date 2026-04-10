using Microsoft.Data.Sqlite;

using Dapper;
public class SeatAccess
{
    private SqliteConnection _connection = new SqliteConnection($"Data Source=DataSources/project.db");

    private string Table = "Seat";

    public void Write(SeatModel seat)
    {
        string sql = $"INSERT INTO {Table} (locationId, seatNumber, tier) VALUES (@LocationId, @SeatNumber, @Tier)";
        _connection.Execute(sql, seat);
    }


    public SeatModel? GetByID(int id)
    {
        string sql = $"SELECT * FROM {Table} WHERE id = @Id";
        return _connection.QueryFirstOrDefault<SeatModel>(sql, new { Id = id });
    }
    public SeatModel? GetBySeatNumber(int seatNumber)
    {
        string sql = $"SELECT * FROM {Table} WHERE seatNumber = @SeatNumber";
        return _connection.QueryFirstOrDefault<SeatModel>(sql, new { seatNumber = seatNumber });
    }
    public List<SeatModel?> GetByTier(int tier)
    {
        string sql = $"SELECT * FROM {Table} WHERE tier = @Tier";
        return [_connection.QueryFirstOrDefault<SeatModel>(sql, new { Tier = tier })];
    }

    public void Update(SeatModel seat)
    {
        string sql = $"UPDATE {Table} SET locationId = @LocationId, seatNumber = @SeatNumber, tier = @Tier WHERE id = @Id";
        _connection.Execute(sql, seat);
    }

    public void Delete(SeatModel seat)
    {
        string sql = $"DELETE FROM {Table} WHERE id = @Id";
        _connection.Execute(sql, new { Id = seat.Id });
    }

}