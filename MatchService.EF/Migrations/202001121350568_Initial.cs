namespace MatchService.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Match",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Header = c.String(),
                        DateTime = c.DateTime(nullable: false),
                        StadiumId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PlaceAtMatch",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        SectorNumber = c.Int(nullable: false),
                        Match_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Match", t => t.Match_Id, cascadeDelete: true)
                .Index(t => t.Match_Id);
            
            CreateTable(
                "dbo.Reservation",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Start = c.DateTime(nullable: false),
                        End = c.DateTime(nullable: false),
                        PlaceAtMatchId = c.Int(nullable: false),
                        TicketId = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Stadium",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sector",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        DefaultPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Stadium_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Stadium", t => t.Stadium_Id, cascadeDelete: true)
                .Index(t => t.Stadium_Id);
            
            CreateTable(
                "dbo.Place",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        PriceMultiplier = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Sector_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sector", t => t.Sector_Id, cascadeDelete: true)
                .Index(t => t.Sector_Id);
            
            CreateTable(
                "dbo.Ticket",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        ReservationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PriceComponent",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Value = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Ticket_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ticket", t => t.Ticket_Id, cascadeDelete: true)
                .Index(t => t.Ticket_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PriceComponent", "Ticket_Id", "dbo.Ticket");
            DropForeignKey("dbo.Sector", "Stadium_Id", "dbo.Stadium");
            DropForeignKey("dbo.Place", "Sector_Id", "dbo.Sector");
            DropForeignKey("dbo.PlaceAtMatch", "Match_Id", "dbo.Match");
            DropIndex("dbo.PriceComponent", new[] { "Ticket_Id" });
            DropIndex("dbo.Place", new[] { "Sector_Id" });
            DropIndex("dbo.Sector", new[] { "Stadium_Id" });
            DropIndex("dbo.PlaceAtMatch", new[] { "Match_Id" });
            DropTable("dbo.PriceComponent");
            DropTable("dbo.Ticket");
            DropTable("dbo.Place");
            DropTable("dbo.Sector");
            DropTable("dbo.Stadium");
            DropTable("dbo.Reservation");
            DropTable("dbo.PlaceAtMatch");
            DropTable("dbo.Match");
        }
    }
}
