namespace EasyLife.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removegoodsname : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.shopping_cart", "goods_name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.shopping_cart", "goods_name", c => c.String(unicode: false));
        }
    }
}
