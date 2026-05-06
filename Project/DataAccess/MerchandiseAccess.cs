using Microsoft.Data.Sqlite;
using Dapper;
using System.Reflection.Metadata.Ecma335;


public class MerchandiseAccess
{
    private SqliteConnection _connection = new SqliteConnection($"Data Source=DataSources/project.db");
    private string Table = "Merchandise";

    public void Write() { }
    public void Update() { }
    public void Delete() { }
    public void GetByType() { }


}