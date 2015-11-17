namespace CrypticCities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CrypticCities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Clue = c.String(),
                        Hint = c.String(),
                        Answer = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CrypticCities");
        }
    }
}
