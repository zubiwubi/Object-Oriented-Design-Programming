using Microsoft.Data.Sqlite;
using Dapper;
using System.Reflection.Metadata.Ecma335;

public class MerchandiseAccess
{
    private SqliteConnection _connection = new SqliteConnection($"Data Source=DataSources/project.db");
    private string Table = "Merchandise";

    public List<MerchandiseModel> GetAllMerchandise()
    {
        string sql = $"Select * FROM {Table}"; 
        return _connection.Query<MerchandiseModel>(sql).ToList(); 
    }
    public void Add(MerchandiseModel merchandise)
    {
        string sql = $"INSERT INTO {Table} (Name, Description, Price, Type, Size) VALUES (@Name, @Description, @Price, @Type, @Size)";
        _connection.Execute(sql, merchandise);
    }
    public void Update(MerchandiseModel merchandise)
    {
        string sql = $"UPDATE {Table} SET Name = @Name, Description = @Description, Price = @Price, Type = @Type, Size = @Size,  WHERE id = @Id";
        _connection.Execute(sql, merchandise);
    }
    public void Delete(MerchandiseModel merchandise)
    {
        string sql = $"DELETE FROM {Table} WHERE id = @Id";
        _connection.Execute(sql, new { Id = merchandise.Id });
    }
    public List<MerchandiseModel> GetHoodies()
    {
        string sql = $"SELECT * FROM {Table} WHERE Type = @Type";
        return _connection.Query<MerchandiseModel>(sql, new { Type = "Hoodie"}).ToList(); 
    }

    public List<MerchandiseModel> GetTshirts()
    {
        string sql = $"SELECT * FROM {Table} WHERE Type = @Type";
        return _connection.Query<MerchandiseModel>(sql, new {Type = "T-shirt"} ).ToList(); 
    }

    public List<MerchandiseModel> GetAccessories()
    {
        string sql = $"SELECT * FROM {Table} WHERE Type = @Type";
        return _connection.Query<MerchandiseModel>(sql, new {Type = "Accessory"} ).ToList(); 
    }
    public List<MerchandiseModel> GetStickers()
    {
        string sql = $"SELECT * FROM {Table} WHERE Type = @Type";
        return _connection.Query<MerchandiseModel>(sql, new {Type = "Sticker"} ).ToList(); 
    }

    public List<MerchandiseModel> GetMugs()
    {
        string sql = $"SELECT * FROM {Table} WHERE Type = @Type"; 
        return _connection.Query<MerchandiseModel>(sql, new {Type = "Mug"} ).ToList(); 
    }

    public List<MerchandiseModel> GetPosters()
    {
        string sql = $"SELECT * FROM {Table} WHERE Type = @Type"; 
        return _connection.Query<MerchandiseModel>(sql, new {Type = "Poster"} ).ToList(); 
        
    }

}