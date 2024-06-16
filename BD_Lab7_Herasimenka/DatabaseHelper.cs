using System.Data.SqlClient;
using System.Configuration;

public class DatabaseHelper
{
    public static string CheckDatabaseConnection()
    {
        string connectionString = ConfigurationManager.ConnectionStrings["TrackDbConnection"].ConnectionString;

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT DB_NAME()", connection);
                string databaseName = (string)command.ExecuteScalar();
                return $"Connected to database: {databaseName}";
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }
    }
}
