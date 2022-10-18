using Application.Interfaces;
using Dapper;
using Domain;
using Infrastructure.DbBuild;
using Infrastructure.Interfaces;
using SqlKata;
using SqlKata.Compilers;


namespace Infrastructure;

public class BoxRepository : IBoxRepository
{
    
    //Use sqlKata to query the database
    // https://sqlkata.com/docs/execution/setup
    // https://medium.com/geekculture/using-dapper-and-sqlkata-in-net-core-for-high-performance-application-716d5fd43210

    private readonly IDapperr _dapperr;
    private DbConnectionFactory _dbConnectionFactory;
    
    public BoxRepository(IDapperr dapper)
    {
        _dapperr = dapper;
        _dbConnectionFactory = new DbConnectionFactory();
    }
    
    
    public IEnumerable<Box> All()
    {
        using var conn = _dbConnectionFactory.CreateConnection();

        var compiler = new SqliteCompiler();
        var query = new Query("Boxes").Select("*");
        SqlResult sqlResult = compiler.Compile(query);
        
        var result = _dapperr.Query<Box>(sqlResult.Sql, new DynamicParameters());
        return result;
    }

    public Box Create(Box t)
    {
        using var conn = _dbConnectionFactory.CreateConnection();
        var data = new
        {
            Contents = t.Contents,
            Height = t.Height,
            Width = t.Width,
            Depth = t.Depth,
            Weight = t.Weight
        };
        
        
        var compiler = new SqliteCompiler();
        var query = new Query("Boxes").AsInsert(data);
        SqlResult sqlResult = compiler.Compile(query);
        var sql = sqlResult.Sql += "; SELECT last_insert_rowid();";
        
        var result = _dapperr.Query<int>(sqlResult.Sql, new DynamicParameters(data));
        t.Id = result.First();

        return t;
    }

    public bool Delete(int id)
    {
        using var conn = _dbConnectionFactory.CreateConnection();
        var data = new
        {
            Id = id
        };
        
        var compiler = new SqliteCompiler();
        var query = new Query("Boxes").AsDelete().Where("Id", id);
        SqlResult sqlResult = compiler.Compile(query);
        
        var result = _dapperr.Execute(sqlResult.Sql, new DynamicParameters(data));
        
        return result > 0;
    }

    public IEnumerable<Box> SearchByName(string tName)
    {
        using (var conn = _dbConnectionFactory.CreateConnection())
        {
            var data = new
            {
                Name = tName
            };
            
            var compiler = new SqliteCompiler();
            var query = new Query("Boxes").Select("*").WhereLike("Name", tName);
            SqlResult sqlResult = compiler.Compile(query);
            
            var result = _dapperr.Query<Box>(sqlResult.Sql, new DynamicParameters(data));
            return result;
        }
    }

    public Box Single(long id)
    {
        using var conn = _dbConnectionFactory.CreateConnection();
        var data = new
        {
            Id = id
        };

        var compiler = new SqliteCompiler();
        var query = new Query("Boxes").Select("1").Where("Id", id);
        SqlResult sqlResult = compiler.Compile(query);
        
        var result = _dapperr.Query<Box>(sqlResult.Sql, new DynamicParameters(data));
        return result.First();
    }

    public Box Update(long id, Box model)
    {
        using var conn = _dbConnectionFactory.CreateConnection();
        var data = new
        {
            Id = id,
            Contents = model.Contents,
            Height = model.Height,
            Width = model.Width,
            Depth = model.Depth,
            Weight = model.Weight
        };

        var compiler = new SqliteCompiler();
        var query = new Query("Boxes").AsUpdate(data).Where("Id", id);
        SqlResult sqlResult = compiler.Compile(query);
        
        var result = _dapperr.Execute(sqlResult.Sql, new DynamicParameters(data));
        if (result != 1)
        {
            throw new Exception("Could not update box");
        }
        
        return model;
    }


    public void BuildDB()
    {
        var migrate = new Migration_1();
        migrate.Down();
        migrate.Up();
    }
}