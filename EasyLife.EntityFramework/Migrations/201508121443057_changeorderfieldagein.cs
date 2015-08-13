namespace EasyLife.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeorderfieldagein : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.order", "order_status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.order", "order_status");
        }
    }
}
