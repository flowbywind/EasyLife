namespace EasyLife.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updategoodtable : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.goods", name: "goods_Id", newName: "Id");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.goods", name: "Id", newName: "goods_Id");
        }
    }
}
