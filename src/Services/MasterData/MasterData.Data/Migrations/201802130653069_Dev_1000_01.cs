namespace MasterData.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Dev_1000_01 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Label = c.String(nullable: false, maxLength: 64),
                        RefId = c.Int(nullable: false),
                        RefTypeName = c.String(maxLength: 128),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Menus");
        }
    }
}
