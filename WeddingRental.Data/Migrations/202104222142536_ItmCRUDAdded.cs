namespace WeddingRental.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ItmCRUDAdded : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Item", "RaterId", "dbo.Rating");
            DropIndex("dbo.Item", new[] { "RaterId" });
            AddColumn("dbo.Item", "OwnerId", c => c.Guid(nullable: false));
            DropColumn("dbo.Item", "RaterId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Item", "RaterId", c => c.Int());
            DropColumn("dbo.Item", "OwnerId");
            CreateIndex("dbo.Item", "RaterId");
            AddForeignKey("dbo.Item", "RaterId", "dbo.Rating", "RaterId");
        }
    }
}
