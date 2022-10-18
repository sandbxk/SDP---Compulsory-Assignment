using System.Data;
using Microsoft.Data.Sqlite;

namespace Infrastructure;


public interface IDbConnectionFactory
{
    IDbConnection CreateConnection();
}

public class DbConnectionFactory : IDbConnectionFactory
{
    private const string _CONNECTIONSTRING = "Data Source=Infrastructure/db.db";

    public DbConnectionFactory()
    {
        if (!File.Exists("Infrastructure/db.db"))
        {
            if (!Directory.Exists("Infrastructure"))
            {
                Directory.CreateDirectory("Infrastructure");
            }
            File.Create("Infrastructure/db.db");
        }
    }

    public IDbConnection CreateConnection()
    {
        return new SqliteConnection(_CONNECTIONSTRING);
    }

    public override string ToString()
    {
        return _CONNECTIONSTRING;
    }
}
