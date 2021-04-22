namespace WeddingRental.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateItemClass : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Item", "ItemAddress");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Item", "ItemAddress", c => c.String(nullable: false));
        }
    }
}
