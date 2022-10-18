using FluentMigrator;
using SqlKata;

namespace Infrastructure.DbBuild;

[Obsolete]
[Migration(1)]
public class Migration_1 : Migration
{
    //Create db with FluentMigrartor
    
    // https://dotnetcorecentral.com/blog/fluentmigrator/
    // https://dotnetcorecentral.com/blog/how-to-use-sqlite-with-dapper/
    public override void Up()
    {

        Create.Table("Boxes")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("Contents").AsString()
            .WithColumn("Width").AsDouble()
            .WithColumn("Height").AsDouble()
            .WithColumn("Depth").AsDouble()
            .WithColumn("Weight").AsDouble();

    }

    public override void Down()
    {
        if (Database.TableExists("Boxes"))
            Delete.Table("Boxes");
    }
}