using Microsoft.Data.Sqlite;

using Dapper;

public class AccountsAccess
{
    private SqliteConnection _connection = new SqliteConnection($"Data Source=DataSources/project.db");

    private string Table = "Accounts";

    public void Write(AccountModel account)
    {
        string sql = $"INSERT INTO {Table} (firstName, lastName, emailAddress, password,type) VALUES (@FirstName, @LastName,@EmailAddress,@Password,@Type)";
        _connection.Execute(sql, account);
    }

    public AccountModel? GetByEmail(string email)
    {
        string sql = $"SELECT * FROM {Table} WHERE email = @Email";
        return _connection.QueryFirstOrDefault<AccountModel>(sql, new { Email = email });
    }

    public void Update(AccountModel account)
    {
        string sql = $"UPDATE {Table} SET firstName=@FirstName, lastName=@LastName emailAddress = @EmailAddress, password = @Password, type = @Type WHERE id = @Id";
        _connection.Execute(sql, account);
    }

    public void Delete(AccountModel account)
    {
        string sql = $"DELETE FROM {Table} WHERE id = @Id";
        _connection.Execute(sql, new { Id = account.Id });
    }



}