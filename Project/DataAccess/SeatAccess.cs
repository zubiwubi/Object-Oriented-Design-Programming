using Microsoft.Data.Sqlite;

using Dapper;
public class SeatAccess
{
    private SqliteConnection _connection = new SqliteConnection($"Data Source=DataSources/project.db");

    private string Table = "Seats";


    public void UpdateSeatType(int locationId, int row, int col, string type)
    {
        string sql = @"
        UPDATE Seats
        SET Type = @Type
        WHERE LocationId = @LocationId
        AND Row = @Row
        AND Col = @Col";

        _connection.Execute(sql, new
        {
            LocationId = locationId,
            Row = row,
            Col = col,
            Type = type
        });
    }

    public List<(int Row, int Col)> GetSeatCoordinates(int locationId, string type)
    {
        string sql = @"
        SELECT Row, Col
        FROM Seats
        WHERE LocationId = @LocationId
        AND Type = @Type";

        return _connection.Query<(int Row, int Col)>(sql, new { LocationId = locationId, Type = type })
                          .ToList();
    }

    public List<SeatModel> GetSeatsByLocation(int locationId)
    {
        string sql = @"
        SELECT *
        FROM Seats
        WHERE LocationId = @LocationId";

        return _connection.Query<SeatModel>(sql, new { LocationId = locationId }).ToList();
    }


}