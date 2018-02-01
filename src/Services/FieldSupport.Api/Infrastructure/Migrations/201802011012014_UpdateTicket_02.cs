namespace FieldSupport.Api.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTicket_02 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Engineers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AvailStatus = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Tickets", "Title", c => c.String(nullable: false, maxLength: 225));
            AddColumn("dbo.Tickets", "Description", c => c.String(nullable: false, maxLength: 1000));
            AddColumn("dbo.Tickets", "ExpiredUtc", c => c.DateTime(nullable: false));
            AddColumn("dbo.Tickets", "CanExpired", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tickets", "IsAssignToReaded", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tickets", "IsAssignToFinished", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tickets", "State", c => c.Int(nullable: false));
            AddColumn("dbo.Tickets", "Address_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Tickets", "AssignTo_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Tickets", "TicketType_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Tickets", "Owner_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Tickets", "MaintenanceArea_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Tickets", "MaintenanceAreaDetail_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Tickets", "MaintenanceGroup_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Tickets", "_CreatedUtc", c => c.DateTime(nullable: false));
            AddColumn("dbo.Tickets", "_CreatedBy", c => c.String());
            AddColumn("dbo.Tickets", "_CreatedAgent", c => c.String());
            AddColumn("dbo.Tickets", "_LastModifiedUtc", c => c.DateTime(nullable: false));
            AddColumn("dbo.Tickets", "_LastModifiedBy", c => c.String());
            AddColumn("dbo.Tickets", "_LastModifiedAgent", c => c.String());
            AddColumn("dbo.Tickets", "AssignTo_Id1", c => c.Int());
            CreateIndex("dbo.Tickets", "AssignTo_Id1");
            AddForeignKey("dbo.Tickets", "AssignTo_Id1", "dbo.Engineers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "AssignTo_Id1", "dbo.Engineers");
            DropIndex("dbo.Tickets", new[] { "AssignTo_Id1" });
            DropColumn("dbo.Tickets", "AssignTo_Id1");
            DropColumn("dbo.Tickets", "_LastModifiedAgent");
            DropColumn("dbo.Tickets", "_LastModifiedBy");
            DropColumn("dbo.Tickets", "_LastModifiedUtc");
            DropColumn("dbo.Tickets", "_CreatedAgent");
            DropColumn("dbo.Tickets", "_CreatedBy");
            DropColumn("dbo.Tickets", "_CreatedUtc");
            DropColumn("dbo.Tickets", "MaintenanceGroup_Id");
            DropColumn("dbo.Tickets", "MaintenanceAreaDetail_Id");
            DropColumn("dbo.Tickets", "MaintenanceArea_Id");
            DropColumn("dbo.Tickets", "Owner_Id");
            DropColumn("dbo.Tickets", "TicketType_Id");
            DropColumn("dbo.Tickets", "AssignTo_Id");
            DropColumn("dbo.Tickets", "Address_Id");
            DropColumn("dbo.Tickets", "State");
            DropColumn("dbo.Tickets", "IsAssignToFinished");
            DropColumn("dbo.Tickets", "IsAssignToReaded");
            DropColumn("dbo.Tickets", "CanExpired");
            DropColumn("dbo.Tickets", "ExpiredUtc");
            DropColumn("dbo.Tickets", "Description");
            DropColumn("dbo.Tickets", "Title");
            DropTable("dbo.Engineers");
        }
    }
}
