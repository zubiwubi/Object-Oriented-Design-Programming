using Microsoft.Data.Sqlite;

using Dapper;
using System.Runtime.CompilerServices;

public class OrderedExtrasAccess
{
    private SqliteConnection _connection = new SqliteConnection($"Data Source=DataSources/project.db");

    private string Table = "\"OrderedExtras\"";

    public int Write(OrderedExtrasModel order)
    {
        string sql = $"INSERT INTO {Table} (orderId, foodId, foodQuantity, drinkId, drinkQuantity , merchandiseId, merchandiseQuantity) VALUES (@OrderId, @FoodId, @FoodQuantity,@DrinkId,@DrinkQuantity, @MerchandiseId, @MerchandiseQuantity);SELECT last_insert_rowid();";
        return _connection.QuerySingle<int>(sql, order);
    }

    public OrderedExtrasModel? GetById(int? id)
    {
        string sql = $"SELECT * FROM {Table} WHERE id = @Id";
        return _connection.QueryFirstOrDefault<OrderedExtrasModel>(sql, new { Id = id });
    }

    public OrderedExtrasModel? GetByOrderId(long? orderId)
    {
        string sql = $"SELECT * FROM {Table} WHERE orderId = @OrderId";
        return _connection.QueryFirstOrDefault<OrderedExtrasModel>(sql, new { OrderId = orderId });
    }
    public List<OrderedExtrasModel>? GetAllByOrderId(long? orderId)
    {
        string sql = $"SELECT * FROM {Table} WHERE orderId = @OrderId";
        return _connection.Query<OrderedExtrasModel>(sql, new { OrderId = orderId }).AsList();
    }

    public List<OrderedExtrasModel>? GetAll()
    {
        string sql = $"SELECT * FROM {Table}";
        return _connection.Query<OrderedExtrasModel>(sql).AsList();
    }

    public void Update(OrderedExtrasModel order)
    {
        string sql = $"UPDATE {Table} SET orderId = @OrderId, foodId = @FoodId, foodQuantity=@FoodQuantity, drinkId = @DrinkId, drinkQuantity = @DrinkQuantity, merchandiseId = @MerchandiseId, merchandiseQuantity = @MerchandiseQuantity WHERE id = @Id";
        _connection.Execute(sql, order);
    }
    public void Delete(OrderedExtrasModel order)
    {
        string sql = $"DELETE FROM {Table} WHERE id = @Id";
        _connection.Execute(sql, new { Id = order.Id });
    }



}