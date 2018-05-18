namespace MasterData.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Dev_1001_02 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdditionalRatings",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        ApplicationID = c.Int(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                        CreatedBy = c.String(nullable: false, maxLength: 96),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.String(maxLength: 96),
                        ModifiedOn = c.DateTime(),
                        TimeStatus = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "timestamp"),
                        RowStatus = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 100),
                        CreatedBy = c.String(nullable: false, maxLength: 96),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.String(maxLength: 96),
                        ModifiedOn = c.DateTime(),
                        TimeStatus = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "timestamp"),
                        RowStatus = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.UserCategories",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Name = c.String(),
                        MenuID = c.Int(nullable: false),
                        CreatedBy = c.String(nullable: false, maxLength: 96),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedBy = c.String(maxLength: 96),
                        ModifiedOn = c.DateTime(),
                        TimeStatus = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "timestamp"),
                        RowStatus = c.Short(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.IncidentAreaGroup", "UserCategoriesID", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.IncidentAreaGroup", "UserCategoriesID");
            DropTable("dbo.UserCategories");
            DropTable("dbo.Menus");
            DropTable("dbo.AdditionalRatings");
        }
    }
}
