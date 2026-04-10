using Microsoft.Data.Sqlite;

using Dapper;
public class CustomerAccess
{
    private SqliteConnection _connection = new SqliteConnection($"Data Source=DataSources/project.db");

    private string Table = "Customer";

    public void Write(CustomerModel customerAccount)
    {
        string sql = $"INSERT INTO {Table} (firstName, lastName, emailAddress,dateOfBirth,phoneNumber) VALUES (@FirstName, @LastName,@EmailAddress,@DateOfBirth,@PhoneNumber)";
        _connection.Execute(sql, customerAccount);
    }

    public CustomerModel? GetByEmail(string email)
    {
        string sql = $"SELECT * FROM {Table} WHERE emailAddress = @EmailAddress";
        return _connection.QueryFirstOrDefault<CustomerModel>(sql, new { Email = email });
    }

    public void Update(CustomerModel customerAccount)
    {
        string sql = $"UPDATE {Table} SET firstName = @FirstName, lastName = @LastName, emailAddress = @EmailAddress, dateOfBirth = @DateOfBirth, phoneNumber = @PhoneNumber WHERE id = @Id";
        _connection.Execute(sql, customerAccount);
    }

    public void Delete(CustomerModel customerAccount)
    {
        string sql = $"DELETE FROM {Table} WHERE id = @Id";
        _connection.Execute(sql, new { Id = customerAccount.Id });
    }



}