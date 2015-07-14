namespace EasyLife.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatetag : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.tag", "icon", c => c.String(maxLength: 50, storeType: "nvarchar"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tag", "icon", c => c.String(unicode: false));
        }
    }
}
