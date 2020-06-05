namespace CrypticCities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTrackingFieldsForCC : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CrypticCities", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.CrypticCities", "DateUpdated", c => c.DateTime(nullable: false));
            AddColumn("dbo.CrypticCities", "CreatedById", c => c.String(maxLength: 128));
            AddColumn("dbo.CrypticCities", "UpdatedById", c => c.String(maxLength: 128));
            CreateIndex("dbo.CrypticCities", "CreatedById");
            CreateIndex("dbo.CrypticCities", "UpdatedById");
            AddForeignKey("dbo.CrypticCities", "CreatedById", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.CrypticCities", "UpdatedById", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CrypticCities", "UpdatedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.CrypticCities", "CreatedById", "dbo.AspNetUsers");
            DropIndex("dbo.CrypticCities", new[] { "UpdatedById" });
            DropIndex("dbo.CrypticCities", new[] { "CreatedById" });
            DropColumn("dbo.CrypticCities", "UpdatedById");
            DropColumn("dbo.CrypticCities", "CreatedById");
            DropColumn("dbo.CrypticCities", "DateUpdated");
            DropColumn("dbo.CrypticCities", "DateCreated");
        }
    }
}
