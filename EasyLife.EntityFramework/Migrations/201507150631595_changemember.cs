namespace EasyLife.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changemember : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.member", "member_email", c => c.String(maxLength: 50, storeType: "nvarchar"));
            AlterColumn("dbo.member", "member_birthday", c => c.DateTime(nullable: false, precision: 0));
            AlterColumn("dbo.member", "member_address", c => c.String(maxLength: 200, storeType: "nvarchar"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.member", "member_address", c => c.String(maxLength: 50, storeType: "nvarchar"));
            AlterColumn("dbo.member", "member_birthday", c => c.String(maxLength: 50, storeType: "nvarchar"));
            DropColumn("dbo.member", "member_email");
        }
    }
}
