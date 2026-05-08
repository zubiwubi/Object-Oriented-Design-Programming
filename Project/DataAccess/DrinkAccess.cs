using Microsoft.Data.Sqlite;

using Dapper;

public class DrinkAccess
{
    private SqliteConnection _connection = new SqliteConnection($"Data Source=DataSources/project.db");

    private string Table = "Drink";

    public List<DrinkModel> GetAll()
    {
        string sql = $"SELECT * FROM {Table}";
        return _connection.Query<DrinkModel>(sql).ToList();
    }

    public void Write(DrinkModel drink)
    {
        string sql = $"INSERT INTO {Table} (name, description, size, price, type, islounge) VALUES (@Name, @Description,@Size, @Price, @Type, @isLounge)";
        _connection.Execute(sql, drink);
    }

    public DrinkModel? GetById(int id)
    {
        string sql = $"SELECT * FROM {Table} WHERE id = @Id";
        return _connection.QueryFirstOrDefault<DrinkModel>(sql, new { Id = id });
    }

    public void Update(DrinkModel drink)
    {
        string sql = $"UPDATE {Table} SET name = @Name, description = @Description, size  = @Size, price = @Price, type = @Type, islounge = @isLounge WHERE id = @Id";
        _connection.Execute(sql, drink);
    }

    public void Delete(DrinkModel drink)
    {
        string sql = $"DELETE FROM {Table} WHERE id = @Id";
        _connection.Execute(sql, new { Id = drink.Id });
    }
}