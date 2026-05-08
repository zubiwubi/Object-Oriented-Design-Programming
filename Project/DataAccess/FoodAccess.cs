using Microsoft.Data.Sqlite;

using Dapper;

public class FoodAccess
{
    private SqliteConnection _connection = new SqliteConnection($"Data Source=DataSources/project.db");

    private string Table = "Food";

    public List<FoodModel> GetAll()
    {
        string sql = $"SELECT * FROM {Table}";
        return _connection.Query<FoodModel>(sql).ToList();
    }

    public void Write(FoodModel food)
    {
        string sql = $"INSERT INTO {Table} (name, description, price, type, islounge) VALUES (@Name, @Description, @Price, @Type, @isLounge)";
        _connection.Execute(sql, food);
    }

    public FoodModel? GetById(int id)
    {
        string sql = $"SELECT * FROM {Table} WHERE id = @Id";
        return _connection.QueryFirstOrDefault<FoodModel>(sql, new { Id = id });
    }

    public void Update(FoodModel food)
    {
        string sql = $"UPDATE {Table} SET name = @Name, description = @Description, price = @Price, type = @Type, islounge = @isLounge  WHERE id = @Id";
        _connection.Execute(sql, food);
    }

    public void Delete(FoodModel food)
    {
        string sql = $"DELETE FROM {Table} WHERE id = @Id";
        _connection.Execute(sql, new { Id = food.Id });
    }



}