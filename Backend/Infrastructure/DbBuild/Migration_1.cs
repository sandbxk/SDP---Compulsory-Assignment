using FluentMigrator;

namespace Infrastructure.DbBuild;

public class Migration_1 : Migration
{
    public override void Up()
    {
        Delete.Table("Boxes");
    }

    public override void Down()
    {
        Create.Table("Boxes")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("Content").AsString();

    }
}