using Microsoft.Data.Sqlite;

using Dapper;

public class OrderAccess
{
    private SqliteConnection _connection = new SqliteConnection($"Data Source=DataSources/project.db");

    private string Table = "\"Order\"";

    public int Write(OrderModel order)
    {
        string sql = $"INSERT INTO {Table} (customerId, movieId, seatId, orderedExtrasId, date , fileNameQRCode, partySize) VALUES (@CustomerId, @MovieId, @SeatId,@OrderedExtrasId,@Date, @FileNameQRCode, @PartySize);SELECT last_insert_rowid();";
        return _connection.QuerySingle<int>(sql, order);
    }

    public OrderModel? GetById(int id)
    {
        string sql = $"SELECT * FROM {Table} WHERE id = @Id";
        return _connection.QueryFirstOrDefault<OrderModel>(sql, new { Id = id });
    }

    public OrderModel? GetByCustomerId(int customerId)
    {
        string sql = $"SELECT * FROM {Table} WHERE customerId = @CustomerId";
        return _connection.QueryFirstOrDefault<OrderModel>(sql, new { CustomerId = customerId });
    }

    public void Update(OrderModel order)
    {
        string sql = $"UPDATE {Table} SET customerId = @CustomerId, movieId = @MovieId, orderedExtrasId=@OrderedExtrasId, date = @Date, fileNameQRCode = @FileNameQRCode, partySize = @PartySize WHERE id = @Id";
        _connection.Execute(sql, order);
    }

    public void Delete(OrderModel order)
    {
        string sql = $"DELETE FROM {Table} WHERE id = @Id";
        _connection.Execute(sql, new { Id = order.Id });
    }



}