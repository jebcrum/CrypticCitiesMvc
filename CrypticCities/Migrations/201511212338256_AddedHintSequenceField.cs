namespace CrypticCities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedHintSequenceField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CrypticCities", "HintSequence", c => c.String());
            AlterColumn("dbo.CrypticCities", "Clue", c => c.String(nullable: false));
            AlterColumn("dbo.CrypticCities", "Hint", c => c.String(nullable: false));
            AlterColumn("dbo.CrypticCities", "Answer", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CrypticCities", "Answer", c => c.String());
            AlterColumn("dbo.CrypticCities", "Hint", c => c.String());
            AlterColumn("dbo.CrypticCities", "Clue", c => c.String());
            DropColumn("dbo.CrypticCities", "HintSequence");
        }
    }
}
