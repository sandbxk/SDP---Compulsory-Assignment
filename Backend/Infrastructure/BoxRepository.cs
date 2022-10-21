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
            ZHeight = t.ZHeight,
            XWidth = t.XWidth,
            YLength = t.YLength,
            Weight = t.Weight
        };
        
        string sql = "INSERT INTO Boxes (Contents, ZHeight, XWidth, YLength, Weight) " +
                     "VALUES (@Contents, @ZHeight, @XWidth, @YLength, @Weight); " +
                     "SELECT last_insert_rowid();";
        
        /* Did not work as intended, the compiled sql did seemingly not have the right placeholders.
         Expected @p1, @p2, @p3, @p4, @p5 but got @Contents, @Height, @Width, @BoxDepth, @Weight. Requires further investigation.
        var compiler = new SqliteCompiler();
        var query = new Query("Boxes").AsInsert(data);
        SqlResult sqlResult = compiler.Compile(query);
        var compiledSql = sqlResult.Sql += "; SELECT last_insert_rowid();";
        */
        
        var result = _dapperr.Query<int>(sql, new DynamicParameters(data));
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
        
        string sql = "DELETE FROM Boxes WHERE Id = @Id";
        
        var result = _dapperr.Execute(sql, new DynamicParameters(data));
        
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
            
            string sql = "SELECT * FROM Boxes WHERE Name LIKE @Name";
            
            var result = _dapperr.Query<Box>(sql, new DynamicParameters(data));
            return result;
        }
    }

    public Box Single(long id)
    {
        string sql = "SELECT * FROM Boxes WHERE Id = @Id";
        
        var data = new
        {
            Id = id
        };
        
        var result = _dapperr.Query<Box>(sql, new DynamicParameters(data));
        return result.First();
    }

    public Box Update(long id, Box model)
    {
       
        var data = new
        {
            Id = id,
            Contents = model.Contents,
            ZHeight = model.ZHeight,
            XWidth = model.XWidth,
            YLength = model.YLength,
            Weight = model.Weight
        };

        
        string sql = "UPDATE Boxes SET Contents = @Contents, ZHeight = @ZHeight, XWidth = @XWidth, YLength = @YLength, Weight = @Weight WHERE Id = @Id";
        /* Did not work as intended, the compiled sql did seemingly not have the right placeholders.
        var compiler = new SqliteCompiler();
        var query = new Query("Boxes").AsUpdate(data).Where("Id", id);
        SqlResult sqlResult = compiler.Compile(query);
        */
        
        var result = _dapperr.Execute(sql, new DynamicParameters(data));
        if (result != 1)
        {
            throw new Exception("Could not update box");
        }
        
        return model;
    }


    public void BuildDB()
    {
        using var conn = _dbConnectionFactory.CreateConnection();

        var sql = @"
            DROP TABLE IF EXISTS Boxes;

            CREATE TABLE IF NOT EXISTS Boxes (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Contents TEXT NOT NULL,
                ZHeight DOUBLE NOT NULL,
                XWidth DOUBLE NOT NULL,
                YLength DOUBLE NOT NULL,
                Weight DOUBLE NOT NULL
            );
        ";
        _dapperr.Execute(sql, new DynamicParameters());
    }
}