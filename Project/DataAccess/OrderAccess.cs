using Microsoft.Data.Sqlite;

using Dapper;

public class OrderAccess
{
    private SqliteConnection _connection = new SqliteConnection($"Data Source=DataSources/project.db");

    private string Table = "\"Order\"";

    public int Write(OrderModel order)
    {
        string sql = $"INSERT INTO {Table} (accountId, movieId, seatId, date , partySize) VALUES (@AccountId, @MovieId, @SeatId,@Date, @PartySize);SELECT last_insert_rowid();";
        return _connection.QuerySingle<int>(sql, order);
    }

    public OrderModel? GetById(long id)
    {
        string sql = $"SELECT * FROM {Table} WHERE id = @Id";
        return _connection.QueryFirstOrDefault<OrderModel>(sql, new { Id = id });
    }

    public List<OrderModel> GetByAccountId(long accountId)
    {
        string sql = $"SELECT * FROM {Table} WHERE accountId = @AccountId";
        return _connection.Query<OrderModel>(sql, new { AccountId = accountId }).AsList();
    }

    public List<OrderModel> GetByMovieId(long movieId)
    {
        string sql = $"SELECT * FROM {Table} WHERE movieId = @MovieId";
        return _connection.Query<OrderModel>(sql, new { MovieId = movieId }).AsList();
    }

    public List<OrderModel> GetAllOrders()
    {
        string sql = $"SELECT * FROM {Table}";
        return _connection.Query<OrderModel>(sql).AsList();
    }

    public void Update(OrderModel order)
    {
        string sql = $"UPDATE {Table} SET accountId = @AccountId, movieId = @MovieId, date = @Date, partySize = @PartySize WHERE id = @Id";
        _connection.Execute(sql, order);
    }

    public void Delete(OrderModel order)
    {
        string sql = $"DELETE FROM {Table} WHERE id = @Id";
        _connection.Execute(sql, new { Id = order.Id });
    }



}