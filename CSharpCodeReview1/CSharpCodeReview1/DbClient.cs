using Microsoft.Data.SqlClient;

namespace CSharpCodeReview1;

public class DbClient
{
    private string _connectionString;
    private SqlConnection _sqlConnection;
    
    public DbClient(string connectionString)
    {
        _connectionString = connectionString;
    }

    public void openDbConnection()
    {
        _sqlConnection = new SqlConnection(_connectionString);
        _sqlConnection.Open();
    }

    public void closeDbConnection()
    {
        _sqlConnection.Close();
    }

    public int runCommand(string sql)
    {
        var command = new SqlCommand(sql, _sqlConnection);
        var result = command.ExecuteNonQuery();

        return result;
    }
}