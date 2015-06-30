namespace EasyLife.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.category",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        cat_name = c.String(maxLength: 50, storeType: "nvarchar"),
                        cat_code = c.String(maxLength: 20, storeType: "nvarchar"),
                        status = c.Byte(nullable: false),
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
                    { "DynamicFilter_Category_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.city",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        city_name = c.String(maxLength: 50, storeType: "nvarchar"),
                        pin_yin = c.String(maxLength: 20, storeType: "nvarchar"),
                        hot = c.Byte(nullable: false),
                        parent_id = c.Int(),
                        first_char = c.String(maxLength: 10, storeType: "nvarchar"),
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
                    { "DynamicFilter_City_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.goods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        name = c.String(maxLength: 50, storeType: "nvarchar"),
                        goods_pic = c.String(maxLength: 500, storeType: "nvarchar"),
                        price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        discount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        discount_price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        save_money = c.Decimal(nullable: false, precision: 18, scale: 2),
                        tag_id = c.Int(nullable: false),
                        status = c.Byte(nullable: false),
                        merchant_id = c.Int(nullable: false),
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
                    { "DynamicFilter_Goods_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.member",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        member_name = c.String(maxLength: 50, storeType: "nvarchar"),
                        member_sex = c.Byte(nullable: false),
                        member_birthday = c.String(maxLength: 50, storeType: "nvarchar"),
                        member_phone = c.String(maxLength: 50, storeType: "nvarchar"),
                        member_address = c.String(maxLength: 50, storeType: "nvarchar"),
                        status = c.Byte(nullable: false),
                        merchant_id = c.Int(nullable: false),
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
                    { "DynamicFilter_Member_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.merchant",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        merchant_name = c.String(maxLength: 50, storeType: "nvarchar"),
                        bank = c.String(maxLength: 50, storeType: "nvarchar"),
                        account = c.String(maxLength: 50, storeType: "nvarchar"),
                        city_id = c.Int(nullable: false),
                        cat_id = c.Int(nullable: false),
                        contact_name = c.String(maxLength: 50, storeType: "nvarchar"),
                        phone = c.String(maxLength: 50, storeType: "nvarchar"),
                        email = c.String(maxLength: 50, storeType: "nvarchar"),
                        status = c.Byte(nullable: false),
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
                    { "DynamicFilter_Merchant_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tag",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        tag_name = c.String(maxLength: 50, storeType: "nvarchar"),
                        tag_code = c.String(maxLength: 50, storeType: "nvarchar"),
                        merchant_id = c.Int(nullable: false),
                        status = c.Byte(nullable: false),
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
                    { "DynamicFilter_Tag_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tag",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Tag_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.merchant",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Merchant_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.member",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Member_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.goods",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Goods_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.city",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_City_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
            DropTable("dbo.category",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Category_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
    }
}
