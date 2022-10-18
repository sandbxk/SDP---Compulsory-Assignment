using Dapper;

namespace Infrastructure.DbBuild;

[Obsolete("Use DbBuild instead")]
public static class Database
{

    [Obsolete]
    public static void EnsureDatabase(string name)
    {
        var parameters = new DynamicParameters();
        parameters.Add("name", name);
        using var connection = new DbConnectionFactory().CreateConnection();
        
        var records = connection.Query(
            "SELECT name FROM sqlite_master WHERE name =(@name) AND name not like 'sqlite?_%' escape '?'".Insert(0, name),
            parameters);
        if (!records.Any())
        {
            connection.Execute($"CREATE DATABASE {name}");
        }
    }
    
    [Obsolete]
    public static void RecreateDatabase(string name)
    {
        var parameters = new DynamicParameters();
        parameters.Add("name", name);
        using var connection = new DbConnectionFactory().CreateConnection();

        connection.Execute($"DROP DATABASE IF EXISTS {name}");
        connection.Execute($"CREATE DATABASE {name}");
    }
    
    public static bool TableExists(string name)
    {
        var parameters = new DynamicParameters();
        parameters.Add("name", name);
        using var connection = new DbConnectionFactory().CreateConnection();
        var records = connection.Query("SELECT * FROM sqlite_master WHERE name = @name",
            parameters);

        return records.Any();
    }
    
}