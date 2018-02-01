namespace FieldSupport.Api.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update01 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tickets", "Code", c => c.String(nullable: false, maxLength: 20));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Tickets", "Code");
        }
    }
}
