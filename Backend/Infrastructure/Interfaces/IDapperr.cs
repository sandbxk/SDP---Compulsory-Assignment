using System.Data;
using Dapper;

namespace Infrastructure.Interfaces;

public interface IDapperr
{
    IEnumerable<T> Query<T>(string sql, DynamicParameters dp, CommandType commandType = CommandType.Text);
    int Execute(string sql, DynamicParameters dp, CommandType commandType = CommandType.Text);
    
}