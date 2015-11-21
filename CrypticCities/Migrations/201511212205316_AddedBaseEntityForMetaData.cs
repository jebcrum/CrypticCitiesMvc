namespace CrypticCities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedBaseEntityForMetaData : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CrypticCities", "CreatedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.CrypticCities", "UpdatedById", "dbo.AspNetUsers");
            DropIndex("dbo.CrypticCities", new[] { "CreatedById" });
            DropIndex("dbo.CrypticCities", new[] { "UpdatedById" });
            AddColumn("dbo.CrypticCities", "UserCreated", c => c.String());
            AddColumn("dbo.CrypticCities", "DateModified", c => c.DateTime());
            AddColumn("dbo.CrypticCities", "UserModified", c => c.String());
            AlterColumn("dbo.CrypticCities", "DateCreated", c => c.DateTime());
            DropColumn("dbo.CrypticCities", "DateUpdated");
            DropColumn("dbo.CrypticCities", "CreatedById");
            DropColumn("dbo.CrypticCities", "UpdatedById");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CrypticCities", "UpdatedById", c => c.String(maxLength: 128));
            AddColumn("dbo.CrypticCities", "CreatedById", c => c.String(maxLength: 128));
            AddColumn("dbo.CrypticCities", "DateUpdated", c => c.DateTime(nullable: false));
            AlterColumn("dbo.CrypticCities", "DateCreated", c => c.DateTime(nullable: false));
            DropColumn("dbo.CrypticCities", "UserModified");
            DropColumn("dbo.CrypticCities", "DateModified");
            DropColumn("dbo.CrypticCities", "UserCreated");
            CreateIndex("dbo.CrypticCities", "UpdatedById");
            CreateIndex("dbo.CrypticCities", "CreatedById");
            AddForeignKey("dbo.CrypticCities", "UpdatedById", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.CrypticCities", "CreatedById", "dbo.AspNetUsers", "Id");
        }
    }
}
