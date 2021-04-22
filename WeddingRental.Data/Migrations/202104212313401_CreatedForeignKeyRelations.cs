namespace WeddingRental.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedForeignKeyRelations : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Item", "RaterId", c => c.Int());
            AddColumn("dbo.Rental", "UserId", c => c.Int());
            AddColumn("dbo.Rental", "ItemId", c => c.Int());
            CreateIndex("dbo.Item", "RaterId");
            CreateIndex("dbo.Rental", "UserId");
            CreateIndex("dbo.Rental", "ItemId");
            AddForeignKey("dbo.Item", "RaterId", "dbo.Rating", "RaterId");
            AddForeignKey("dbo.Rental", "ItemId", "dbo.Item", "ItemId");
            AddForeignKey("dbo.Rental", "UserId", "dbo.User", "UserId");
            DropColumn("dbo.Item", "Brand");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Item", "Brand", c => c.String(nullable: false));
            DropForeignKey("dbo.Rental", "UserId", "dbo.User");
            DropForeignKey("dbo.Rental", "ItemId", "dbo.Item");
            DropForeignKey("dbo.Item", "RaterId", "dbo.Rating");
            DropIndex("dbo.Rental", new[] { "ItemId" });
            DropIndex("dbo.Rental", new[] { "UserId" });
            DropIndex("dbo.Item", new[] { "RaterId" });
            DropColumn("dbo.Rental", "ItemId");
            DropColumn("dbo.Rental", "UserId");
            DropColumn("dbo.Item", "RaterId");
        }
    }
}
