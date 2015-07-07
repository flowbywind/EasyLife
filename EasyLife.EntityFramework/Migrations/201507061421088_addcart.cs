namespace EasyLife.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class addcart : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.shopping_cart",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        goods_id = c.Int(nullable: false),
                        goods_name = c.String(unicode: false),
                        count = c.Int(nullable: false),
                        user_id = c.Int(nullable: false),
                        merchant_id = c.Int(nullable: false),
                        status = c.Int(nullable: false),
                        creator_user_id = c.Long(),
                        creation_time = c.DateTime(nullable: false, precision: 0),
                        last_modification_time = c.DateTime(precision: 0),
                        last_modifier_user_id = c.Long(),
                        deleter_user_id = c.Long(),
                        deletion_time = c.DateTime(precision: 0),
                        is_deleted = c.Boolean(nullable: false),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_ShoppingCart_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.category", "creation_time", c => c.DateTime(nullable: false, precision: 0));
            AlterColumn("dbo.category", "last_modification_time", c => c.DateTime(precision: 0));
            AlterColumn("dbo.category", "deletion_time", c => c.DateTime(precision: 0));
            AlterColumn("dbo.city", "creation_time", c => c.DateTime(nullable: false, precision: 0));
            AlterColumn("dbo.city", "last_modification_time", c => c.DateTime(precision: 0));
            AlterColumn("dbo.city", "deletion_time", c => c.DateTime(precision: 0));
            AlterColumn("dbo.goods", "creation_time", c => c.DateTime(nullable: false, precision: 0));
            AlterColumn("dbo.goods", "last_modification_time", c => c.DateTime(precision: 0));
            AlterColumn("dbo.goods", "deletion_time", c => c.DateTime(precision: 0));
            AlterColumn("dbo.member", "creation_time", c => c.DateTime(nullable: false, precision: 0));
            AlterColumn("dbo.member", "last_modification_time", c => c.DateTime(precision: 0));
            AlterColumn("dbo.member", "deletion_time", c => c.DateTime(precision: 0));
            AlterColumn("dbo.merchant", "creation_time", c => c.DateTime(nullable: false, precision: 0));
            AlterColumn("dbo.merchant", "last_modification_time", c => c.DateTime(precision: 0));
            AlterColumn("dbo.merchant", "deletion_time", c => c.DateTime(precision: 0));
            AlterColumn("dbo.tag", "icon", c => c.String(unicode: false));
            AlterColumn("dbo.tag", "creation_time", c => c.DateTime(nullable: false, precision: 0));
            AlterColumn("dbo.tag", "last_modification_time", c => c.DateTime(precision: 0));
            AlterColumn("dbo.tag", "deletion_time", c => c.DateTime(precision: 0));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tag", "deletion_time", c => c.DateTime());
            AlterColumn("dbo.tag", "last_modification_time", c => c.DateTime());
            AlterColumn("dbo.tag", "creation_time", c => c.DateTime(nullable: false));
            AlterColumn("dbo.tag", "icon", c => c.String());
            AlterColumn("dbo.merchant", "deletion_time", c => c.DateTime());
            AlterColumn("dbo.merchant", "last_modification_time", c => c.DateTime());
            AlterColumn("dbo.merchant", "creation_time", c => c.DateTime(nullable: false));
            AlterColumn("dbo.member", "deletion_time", c => c.DateTime());
            AlterColumn("dbo.member", "last_modification_time", c => c.DateTime());
            AlterColumn("dbo.member", "creation_time", c => c.DateTime(nullable: false));
            AlterColumn("dbo.goods", "deletion_time", c => c.DateTime());
            AlterColumn("dbo.goods", "last_modification_time", c => c.DateTime());
            AlterColumn("dbo.goods", "creation_time", c => c.DateTime(nullable: false));
            AlterColumn("dbo.city", "deletion_time", c => c.DateTime());
            AlterColumn("dbo.city", "last_modification_time", c => c.DateTime());
            AlterColumn("dbo.city", "creation_time", c => c.DateTime(nullable: false));
            AlterColumn("dbo.category", "deletion_time", c => c.DateTime());
            AlterColumn("dbo.category", "last_modification_time", c => c.DateTime());
            AlterColumn("dbo.category", "creation_time", c => c.DateTime(nullable: false));
            DropTable("dbo.shopping_cart",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_ShoppingCart_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
    }
}
