using Microsoft.Data.Sqlite;
using Dapper;
using System.Reflection.Metadata.Ecma335;

public class MerchandiseAccess
{
    private SqliteConnection _connection = new SqliteConnection($"Data Source=DataSources/project.db");
    private string Table = "Merchandise";

    public void Add(MerchandiseModel merchandise)
    {
        string sql = $"INSERT INTO {Table} (Name, Description, Price, Type, Size, IsVisible) VALUES (@Name, @Description, @Price, @Type, @Size, @IsVisible)";
        _connection.Execute(sql, merchandise);
    }
    public void Update(MerchandiseModel merchandise)
    {
        string sql = $"UPDATE {Table} SET Name = @Name, Description = @Description, Price = @Price, Type = @Type, Size = @Size  WHERE id = @Id";
        _connection.Execute(sql, merchandise);
    }
    public void UpdateBool(MerchandiseModel merchandise)
    {
        string sql = $"UPDATE {Table} SET IsVisible = 0 WHERE id = @Id";
        _connection.Execute(sql, merchandise);
    } //  this is instead of 'deleting' the item, we make them invisible due to FK limitations

    public MerchandiseModel? CheckMerchExist(MerchandiseModel merchandise)
    {
        string sql = $"SELECT * FROM {Table} WHERE Name = @Name AND Description = @Description AND Price = @Price AND Type = @Type AND Size = @Size";
        return _connection.QueryFirstOrDefault<MerchandiseModel>(sql, new {merchandise.Name, merchandise.Description, merchandise.Price, merchandise.Type, merchandise.Size});
    }



    public List<MerchandiseModel> GetAllMerchandise()
    {
        string sql = $"SELECT * FROM {Table} WHERE IsVisible = 1";
        return _connection.Query<MerchandiseModel>(sql).ToList(); 
    }

    public MerchandiseModel? GetById(long? id)
    {
        string sql = $"SELECT * FROM {Table} WHERE id = @Id";
        return _connection.QueryFirstOrDefault<MerchandiseModel>(sql, new { Id = id });
    }
    // getting items per type 
    public List<MerchandiseModel> GetHoodies()
    {
        string sql = $"SELECT * FROM {Table} WHERE Type = @Type AND IsVisible = 1";
        return _connection.Query<MerchandiseModel>(sql, new { Type = "Hoodie"}).ToList(); 
    }

    public List<MerchandiseModel> GetTshirts()
    {
        string sql = $"SELECT * FROM {Table} WHERE Type = @Type AND IsVisible = 1";
        return _connection.Query<MerchandiseModel>(sql, new {Type = "T-shirt"} ).ToList(); 
    }

    public List<MerchandiseModel> GetAccessories()
    {
        string sql = $"SELECT * FROM {Table} WHERE Type = @Type AND IsVisible = 1";
        return _connection.Query<MerchandiseModel>(sql, new {Type = "Accessory"} ).ToList(); 
    }
    public List<MerchandiseModel> GetStickers()
    {
        string sql = $"SELECT * FROM {Table} WHERE Type = @Type AND IsVisible = 1";
        return _connection.Query<MerchandiseModel>(sql, new {Type = "Sticker"} ).ToList(); 
    }

    public List<MerchandiseModel> GetMugs()
    {
        string sql = $"SELECT * FROM {Table} WHERE Type = @Type AND IsVisible = 1"; 
        return _connection.Query<MerchandiseModel>(sql, new {Type = "Mug"} ).ToList(); 
    }

    public List<MerchandiseModel> GetPosters()
    {
        string sql = $"SELECT * FROM {Table} WHERE Type = @Type AND IsVisible = 1"; 
        return _connection.Query<MerchandiseModel>(sql, new {Type = "Poster"} ).ToList(); 
        
    }
}