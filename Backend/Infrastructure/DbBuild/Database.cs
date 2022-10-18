﻿using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;

namespace Infrastructure.DbBuild;

public static class Database
{

    public static void EnsureDatabase(string name)
    {
        var parameters = new DynamicParameters();
        parameters.Add("name", name);
        using var connection = new DbConnectionFactory().CreateConnection();
        
        var records = connection.Query("SELECT * FROM sys.databases WHERE name = @name",
            parameters);
        if (!records.Any())
        {
            connection.Execute($"CREATE DATABASE {name}");
        }
    }
    
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
        var records = connection.Query("SELECT * FROM sys.tables WHERE name = @name",
            parameters);

        return records.Any();
    }
    
}