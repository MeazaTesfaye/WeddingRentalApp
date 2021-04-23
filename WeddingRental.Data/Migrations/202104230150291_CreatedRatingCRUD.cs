namespace WeddingRental.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedRatingCRUD : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rating", "OwnerId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Rating", "OwnerId");
        }
    }
}
