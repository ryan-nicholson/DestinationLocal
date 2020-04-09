namespace DestinationLocal.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rating",
                c => new
                    {
                        RatingId = c.Int(nullable: false, identity: true),
                        Grade = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                        Comment = c.String(),
                        BarId = c.Int(),
                        StayDate = c.DateTime(),
                        HotelId = c.Int(),
                        StayDate1 = c.DateTime(),
                        DestinationId = c.Int(),
                        StayDate2 = c.DateTime(),
                        Name = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.RatingId)
                .ForeignKey("dbo.Hotel", t => t.HotelId, cascadeDelete: true)
                .ForeignKey("dbo.Destination", t => t.DestinationId, cascadeDelete: false)
                .ForeignKey("dbo.Bar", t => t.BarId, cascadeDelete: true)
                .ForeignKey("dbo.ApplicationUser", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.BarId)
                .Index(t => t.HotelId)
                .Index(t => t.DestinationId);
            
            CreateTable(
                "dbo.Bar",
                c => new
                    {
                        BarId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Rating = c.Int(nullable: false),
                        Comment = c.String(nullable: false, maxLength: 2000),
                        ServesFood = c.Boolean(nullable: false),
                        DestinationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BarId)
                .ForeignKey("dbo.Destination", t => t.DestinationId, cascadeDelete: false)
                .Index(t => t.DestinationId);
            
            CreateTable(
                "dbo.Destination",
                c => new
                    {
                        DestinationId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        City = c.String(nullable: false),
                        State = c.String(),
                        Country = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.DestinationId);
            
            CreateTable(
                "dbo.Hotel",
                c => new
                    {
                        HotelId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Rating = c.Int(nullable: false),
                        Comment = c.String(nullable: false, maxLength: 2000),
                        DestinationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.HotelId)
                .ForeignKey("dbo.Destination", t => t.DestinationId, cascadeDelete: false)
                .Index(t => t.DestinationId);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                        IdentityRole_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Rating", "UserId", "dbo.ApplicationUser");
            DropForeignKey("dbo.Rating", "BarId", "dbo.Bar");
            DropForeignKey("dbo.Bar", "DestinationId", "dbo.Destination");
            DropForeignKey("dbo.Rating", "DestinationId", "dbo.Destination");
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.Rating", "HotelId", "dbo.Hotel");
            DropForeignKey("dbo.Hotel", "DestinationId", "dbo.Destination");
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Hotel", new[] { "DestinationId" });
            DropIndex("dbo.Bar", new[] { "DestinationId" });
            DropIndex("dbo.Rating", new[] { "DestinationId" });
            DropIndex("dbo.Rating", new[] { "HotelId" });
            DropIndex("dbo.Rating", new[] { "BarId" });
            DropIndex("dbo.Rating", new[] { "UserId" });
            DropTable("dbo.IdentityRole");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.Hotel");
            DropTable("dbo.Destination");
            DropTable("dbo.Bar");
            DropTable("dbo.Rating");
        }
    }
}
