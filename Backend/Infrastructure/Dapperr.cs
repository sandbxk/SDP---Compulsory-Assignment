using System.Data;
using Dapper;
using Infrastructure.Interfaces;
using Microsoft.Data.Sqlite;

namespace Infrastructure;

public class Dapperr : IDapperr
{
    //https://referbruv.com/blog/integrating-dapper-with-aspnet-core-a-comparison-with-ef-core/
    
    
    public int Execute(string sql, DynamicParameters dp, CommandType commandType = CommandType.Text)
    {
        int result;

        // get connection
        using IDbConnection connection = new DbConnectionFactory().CreateConnection();

        if (connection.State == ConnectionState.Closed)
            connection.Open();

        try
        {
            // start transaction
            using var transaction = connection.BeginTransaction();

            try
            {
                // execute command within transaction
                result = connection.Execute(sql, dp, transaction);

                // commit changes
                transaction.Commit();
            }
            catch (Exception)
            {
                // rollback if exception
                transaction.Rollback();
                throw;
            }
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            // finally close connection
            if (connection.State == ConnectionState.Open)
                connection.Close();
        }

        return result;
    }

    public IEnumerable<T> Query<T>(string sql, DynamicParameters dp, CommandType commandType = CommandType.Text)
    {
        using IDbConnection db = new DbConnectionFactory().CreateConnection();

        if (db.State == ConnectionState.Closed)
            db.Open();

        try
        {
            return db.Query<T>(sql, dp, commandType: commandType);
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {
            if (db.State == ConnectionState.Open)
                db.Close();
        }
    }
}