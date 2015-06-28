namespace EasyLife.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editcategoryid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.goods", "tag_id", c => c.Int(nullable: false));
            DropColumn("dbo.goods", "category_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.goods", "category_id", c => c.Int(nullable: false));
            DropColumn("dbo.goods", "tag_id");
        }
    }
}
