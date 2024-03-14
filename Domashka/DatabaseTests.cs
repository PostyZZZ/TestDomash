using System;
using System.Data;
using Microsoft.Data.Sqlite;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

public class DatabaseTests : IDisposable
{
    private readonly SqliteConnection _connection;
    private readonly string _databasePath;

    public DatabaseTests()
    {
        _databasePath = @"C:\SQL\Databasa.db";

        _connection = new SqliteConnection($"Data Source={_databasePath}");
        _connection.Open();

        using (var command = _connection.CreateCommand())
        {
            command.CommandText = "CREATE TABLE TestTable (Id INTEGER PRIMARY KEY, Name TEXT);";
            command.ExecuteNonQuery();
        }
    }

    public void Dispose()
    {
        _connection.Close();


    }

    [Fact]
    public void DatabaseConnectionIsSuccessful()
    {
        // Arrange
        using (var connection = new SqliteConnection($"Data Source={_databasePath}"))
        {
            connection.Open();

            // Act
            bool isConnectionSuccessful = connection.State == ConnectionState.Open;

            // Assert
            Assert.True(isConnectionSuccessful);
        }
    }
}