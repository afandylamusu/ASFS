namespace Astra.Infrastructure.Audit.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EntityAudits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EntityName = c.String(nullable: false, maxLength: 128),
                        Key = c.Int(nullable: false),
                        ByUser = c.String(nullable: false, maxLength: 128),
                        Action = c.String(nullable: false, maxLength: 16),
                        RevisionStampUtc = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.EntityAudits");
        }
    }
}
