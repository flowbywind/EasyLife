namespace EasyLife.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class addorder : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.order",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        merchant_id = c.Int(nullable: false),
                        member_name = c.String(unicode: false),
                        member_id = c.Int(nullable: false),
                        member_address = c.String(unicode: false),
                        phone = c.String(unicode: false),
                        city_name = c.String(unicode: false),
                        city_id = c.Int(nullable: false),
                        district_id = c.Int(nullable: false),
                        district_name = c.String(unicode: false),
                        community_id = c.Int(nullable: false),
                        community_name = c.String(unicode: false),
                        get_goods_date = c.DateTime(nullable: false, precision: 0),
                        get_goods_begin_time = c.Int(nullable: false),
                        get_goods_end_time = c.Int(nullable: false),
                        order_date = c.DateTime(nullable: false, precision: 0),
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
                    { "DynamicFilter_Order_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.order_detail",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        order_id = c.Int(nullable: false),
                        shoppingcart_id = c.Int(nullable: false),
                        goods_id = c.Int(nullable: false),
                        goods_name = c.String(unicode: false),
                        goods_pic = c.String(unicode: false),
                        count = c.Int(nullable: false),
                        user_id = c.Int(nullable: false),
                        merchant_id = c.Int(nullable: false),
                        price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        discount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        discount_price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        save_money = c.Decimal(nullable: false, precision: 18, scale: 2),
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
                    { "DynamicFilter_OrderDetail_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.order_detail",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_OrderDetail_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.order",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Order_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
    }
}
