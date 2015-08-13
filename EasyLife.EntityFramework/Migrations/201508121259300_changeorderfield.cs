namespace EasyLife.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeorderfield : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.order_detail", "member_id", c => c.Int(nullable: false));
            DropColumn("dbo.order_detail", "user_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.order_detail", "user_id", c => c.Int(nullable: false));
            DropColumn("dbo.order_detail", "member_id");
        }
    }
}
