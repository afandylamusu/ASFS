namespace FieldSupport.Api.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Dev_1000 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(nullable: false, maxLength: 20),
                        Title = c.String(nullable: false, maxLength: 225),
                        Description = c.String(nullable: false, maxLength: 1000),
                        ExpiredUtc = c.DateTime(nullable: false),
                        CanExpired = c.Boolean(nullable: false),
                        State = c.Int(nullable: false),
                        Address_Id = c.Int(nullable: false),
                        AssignTo_Id = c.Int(),
                        TicketType_Id = c.Int(nullable: false),
                        Owner_Id = c.Int(nullable: false),
                        Area_Id = c.Int(nullable: false),
                        AreaDetail_Id = c.Int(nullable: false),
                        Group_Id = c.Int(nullable: false),
                        _CreatedUtc = c.DateTime(nullable: false),
                        _CreatedBy = c.String(),
                        _CreatedAgent = c.String(),
                        _LastModifiedUtc = c.DateTime(nullable: false),
                        _LastModifiedBy = c.String(),
                        _LastModifiedAgent = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.Address_Id)
                .ForeignKey("dbo.MaintenanceAreas", t => t.Area_Id)
                .ForeignKey("dbo.MaintenanceAreaDetails", t => t.AreaDetail_Id)
                .ForeignKey("dbo.Engineers", t => t.AssignTo_Id)
                .ForeignKey("dbo.MaintenanceGroups", t => t.Group_Id)
                .ForeignKey("dbo.Customers", t => t.Owner_Id)
                .ForeignKey("dbo.TicketTypes", t => t.TicketType_Id)
                .Index(t => t.Address_Id)
                .Index(t => t.AssignTo_Id)
                .Index(t => t.TicketType_Id)
                .Index(t => t.Owner_Id)
                .Index(t => t.Area_Id)
                .Index(t => t.AreaDetail_Id)
                .Index(t => t.Group_Id);
            
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 128),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MaintenanceAreas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MaintenanceAreaDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Area_Id = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MaintenanceAreas", t => t.Area_Id, cascadeDelete: true)
                .Index(t => t.Area_Id);
            
            CreateTable(
                "dbo.Engineers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AvailStatus = c.Int(nullable: false),
                        Employee_Id = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MaintenanceGroups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Employee_Id = c.Int(nullable: false),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TicketTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "TicketType_Id", "dbo.TicketTypes");
            DropForeignKey("dbo.Tickets", "Owner_Id", "dbo.Customers");
            DropForeignKey("dbo.Tickets", "Group_Id", "dbo.MaintenanceGroups");
            DropForeignKey("dbo.Tickets", "AssignTo_Id", "dbo.Engineers");
            DropForeignKey("dbo.Tickets", "AreaDetail_Id", "dbo.MaintenanceAreaDetails");
            DropForeignKey("dbo.MaintenanceAreaDetails", "Area_Id", "dbo.MaintenanceAreas");
            DropForeignKey("dbo.Tickets", "Area_Id", "dbo.MaintenanceAreas");
            DropForeignKey("dbo.Tickets", "Address_Id", "dbo.Addresses");
            DropIndex("dbo.MaintenanceAreaDetails", new[] { "Area_Id" });
            DropIndex("dbo.Tickets", new[] { "Group_Id" });
            DropIndex("dbo.Tickets", new[] { "AreaDetail_Id" });
            DropIndex("dbo.Tickets", new[] { "Area_Id" });
            DropIndex("dbo.Tickets", new[] { "Owner_Id" });
            DropIndex("dbo.Tickets", new[] { "TicketType_Id" });
            DropIndex("dbo.Tickets", new[] { "AssignTo_Id" });
            DropIndex("dbo.Tickets", new[] { "Address_Id" });
            DropTable("dbo.TicketTypes");
            DropTable("dbo.Customers");
            DropTable("dbo.MaintenanceGroups");
            DropTable("dbo.Engineers");
            DropTable("dbo.MaintenanceAreaDetails");
            DropTable("dbo.MaintenanceAreas");
            DropTable("dbo.Addresses");
            DropTable("dbo.Tickets");
        }
    }
}
