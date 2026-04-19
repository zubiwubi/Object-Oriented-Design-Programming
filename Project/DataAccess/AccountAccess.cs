using Microsoft.Data.Sqlite;
using Dapper;


public class AccountAccess
{
    private SqliteConnection _connection = new SqliteConnection($"Data Source=DataSources/project.db");
    private string Table = "Account";
    public void Write(AccountModel account)
    {
        string sql = $"INSERT INTO {Table} (FirstName, LastName, EmailAddress, Password, Type) VALUES (@FirstName, @LastName, @EmailAddress, @Password, @Type)";
        _connection.Execute(sql, account);
    }

    public AccountModel? GetByEmail(string email)
    {
        string sql = $"SELECT * FROM {Table} WHERE EmailAddress = @EmailAddress";
        return _connection.QueryFirstOrDefault<AccountModel>(sql, new { EmailAddress = email });
    }
    public AccountModel? GetPassword(string password)
    {
        string sql = $"SELECT * FROM {Table} WHERE Password = @Password";
        return _connection.QueryFirstOrDefault<AccountModel>(sql, new {Password = password});  
    }

    public void Update(AccountModel account)
    {
        string sql = $"UPDATE {Table} SET email = @EmailAddress, password = @Password, fullname = @FullName WHERE id = @Id";
        _connection.Execute(sql, account);
    }
    public void ChangePassword(long id, string password)
    {
        string sql = $"UPDATE {Table} SET Password = @Password WHERE id = @Id";
        _connection.Execute(sql, new {Id = id, Password = password});
    }

    public void Delete(AccountModel account)
    {
        string sql = $"DELETE FROM {Table} WHERE id = @Id";
        _connection.Execute(sql, new { Id = account.Id });
    }
} 