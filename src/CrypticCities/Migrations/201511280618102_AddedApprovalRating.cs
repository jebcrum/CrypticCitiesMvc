namespace CrypticCities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedApprovalRating : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CrypticCities", "ApprovalRating", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CrypticCities", "ApprovalRating");
        }
    }
}
