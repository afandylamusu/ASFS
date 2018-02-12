namespace FieldSupport.Api.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Dev_1000_02 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Engineers", "_CreatedUtc", c => c.DateTime(nullable: false));
            AddColumn("dbo.Engineers", "_CreatedBy", c => c.String());
            AddColumn("dbo.Engineers", "_CreatedAgent", c => c.String());
            AddColumn("dbo.Engineers", "_LastModifiedUtc", c => c.DateTime(nullable: false));
            AddColumn("dbo.Engineers", "_LastModifiedBy", c => c.String());
            AddColumn("dbo.Engineers", "_LastModifiedAgent", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Engineers", "_LastModifiedAgent");
            DropColumn("dbo.Engineers", "_LastModifiedBy");
            DropColumn("dbo.Engineers", "_LastModifiedUtc");
            DropColumn("dbo.Engineers", "_CreatedAgent");
            DropColumn("dbo.Engineers", "_CreatedBy");
            DropColumn("dbo.Engineers", "_CreatedUtc");
        }
    }
}
