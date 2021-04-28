namespace WeddingRental.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Foreighnkey : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Item", "UserId", c => c.Int());
            AddColumn("dbo.Item", "RaterId", c => c.Int());
            AddColumn("dbo.Item", "Star", c => c.Double(nullable: false));
            AddColumn("dbo.Item", "Brand", c => c.String());
            CreateIndex("dbo.Item", "UserId");
            CreateIndex("dbo.Item", "RaterId");
            AddForeignKey("dbo.Item", "RaterId", "dbo.Rating", "RaterId");
            AddForeignKey("dbo.Item", "UserId", "dbo.User", "UserId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Item", "UserId", "dbo.User");
            DropForeignKey("dbo.Item", "RaterId", "dbo.Rating");
            DropIndex("dbo.Item", new[] { "RaterId" });
            DropIndex("dbo.Item", new[] { "UserId" });
            DropColumn("dbo.Item", "Brand");
            DropColumn("dbo.Item", "Star");
            DropColumn("dbo.Item", "RaterId");
            DropColumn("dbo.Item", "UserId");
        }
    }
}
