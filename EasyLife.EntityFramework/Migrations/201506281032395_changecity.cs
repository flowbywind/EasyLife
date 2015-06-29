namespace EasyLife.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changecity : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.city", name: "CreatorUserId", newName: "creator_user_id");
            RenameColumn(table: "dbo.city", name: "CreationTime", newName: "creation_time");
            RenameColumn(table: "dbo.city", name: "LastModificationTime", newName: "last_modification_time");
            RenameColumn(table: "dbo.city", name: "LastModifierUserId", newName: "last_modifier_user_id");
            RenameColumn(table: "dbo.city", name: "DeleterUserId", newName: "deleter_user_id");
            RenameColumn(table: "dbo.city", name: "DeletionTime", newName: "deletion_time");
            RenameColumn(table: "dbo.city", name: "IsDeleted", newName: "is_deleted");
            AlterColumn("dbo.city", "pin_yin", c => c.String(maxLength: 20, storeType: "nvarchar"));
            AlterColumn("dbo.city", "hot", c => c.Byte(nullable: false));
            AlterColumn("dbo.city", "parent_id", c => c.Int());
            AlterColumn("dbo.city", "first_char", c => c.String(maxLength: 10, storeType: "nvarchar"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.city", "first_char", c => c.Int(nullable: false));
            AlterColumn("dbo.city", "parent_id", c => c.Int(nullable: false));
            AlterColumn("dbo.city", "hot", c => c.String(unicode: false));
            AlterColumn("dbo.city", "pin_yin", c => c.String(unicode: false));
            RenameColumn(table: "dbo.city", name: "is_deleted", newName: "IsDeleted");
            RenameColumn(table: "dbo.city", name: "deletion_time", newName: "DeletionTime");
            RenameColumn(table: "dbo.city", name: "deleter_user_id", newName: "DeleterUserId");
            RenameColumn(table: "dbo.city", name: "last_modifier_user_id", newName: "LastModifierUserId");
            RenameColumn(table: "dbo.city", name: "last_modification_time", newName: "LastModificationTime");
            RenameColumn(table: "dbo.city", name: "creation_time", newName: "CreationTime");
            RenameColumn(table: "dbo.city", name: "creator_user_id", newName: "CreatorUserId");
        }
    }
}
