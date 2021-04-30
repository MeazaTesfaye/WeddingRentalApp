namespace WeddingRental.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatingView : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rating", "ItemId", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Rating", "ItemId");
        }
    }
}
