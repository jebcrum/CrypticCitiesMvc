namespace CrypticCities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedVotes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Votes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CrypticCityId = c.Int(nullable: false),
                        IsApproved = c.Boolean(nullable: false),
                        User = c.String(),
                        IPAddress = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CrypticCities", t => t.CrypticCityId, cascadeDelete: true)
                .Index(t => t.CrypticCityId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Votes", "CrypticCityId", "dbo.CrypticCities");
            DropIndex("dbo.Votes", new[] { "CrypticCityId" });
            DropTable("dbo.Votes");
        }
    }
}
