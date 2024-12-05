using System;
using System.Data;
using Npgsql;

public class DatabaseHelper
{
    private readonly string _connectionString;

    public DatabaseHelper(string connectionStringName)
    {
        _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
    }

    public DataTable ExecuteQuery(string query)
    {
        using (var conn = new NpgsqlConnection(_connectionString))
        {
            conn.Open();
            using (var cmd = new NpgsqlCommand(query, conn))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    var dataTable = new DataTable();
                    dataTable.Load(reader);
                    return dataTable;
                }
            }
        }
    }

    public void ExecuteNonQuery(string query)
    {
        using (var conn = new NpgsqlConnection(_connectionString))
        {
            conn.Open();
            using (var cmd = new NpgsqlCommand(query, conn))
            {
                cmd.ExecuteNonQuery();
            }
        }
    }
}
