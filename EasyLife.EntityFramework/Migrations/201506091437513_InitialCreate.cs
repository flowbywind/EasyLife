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
                        cat_name = c.String(unicode: false),
                        cat_code = c.String(unicode: false),
                        status = c.Byte(nullable: false),
                        CreatorUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false, precision: 0),
                        LastModificationTime = c.DateTime(precision: 0),
                        LastModifierUserId = c.Long(),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(precision: 0),
                        IsDeleted = c.Boolean(nullable: false),
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
                        city_name = c.String(unicode: false),
                        pin_yin = c.String(unicode: false),
                        hot = c.String(unicode: false),
                        parent_id = c.Int(nullable: false),
                        first_char = c.Int(nullable: false),
                        CreatorUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false, precision: 0),
                        LastModificationTime = c.DateTime(precision: 0),
                        LastModifierUserId = c.Long(),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(precision: 0),
                        IsDeleted = c.Boolean(nullable: false),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_City_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.member",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        member_name = c.String(unicode: false),
                        member_sex = c.String(unicode: false),
                        member_birthday = c.String(unicode: false),
                        member_phone = c.String(unicode: false),
                        member_address = c.String(unicode: false),
                        status = c.Byte(nullable: false),
                        merchant_id = c.Int(),
                        CreatorUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false, precision: 0),
                        LastModificationTime = c.DateTime(precision: 0),
                        LastModifierUserId = c.Long(),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(precision: 0),
                        IsDeleted = c.Boolean(nullable: false),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Member_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.merchant", t => t.merchant_id)
                .Index(t => t.merchant_id);
            
            CreateTable(
                "dbo.merchant",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        merchant_name = c.String(unicode: false),
                        bank = c.String(unicode: false),
                        account = c.String(unicode: false),
                        city_id = c.Int(),
                        cat_id = c.Int(),
                        contact_name = c.String(unicode: false),
                        phone = c.String(unicode: false),
                        email = c.String(unicode: false),
                        status = c.Byte(nullable: false),
                        CreatorUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false, precision: 0),
                        LastModificationTime = c.DateTime(precision: 0),
                        LastModifierUserId = c.Long(),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(precision: 0),
                        IsDeleted = c.Boolean(nullable: false),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Merchant_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.category", t => t.cat_id)
                .ForeignKey("dbo.city", t => t.city_id)
                .Index(t => t.city_id)
                .Index(t => t.cat_id);
            
            CreateTable(
                "dbo.tag",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        tag_name = c.String(unicode: false),
                        tag_code = c.String(unicode: false),
                        merchant_id = c.Int(),
                        CreatorUserId = c.Long(),
                        CreationTime = c.DateTime(nullable: false, precision: 0),
                        LastModificationTime = c.DateTime(precision: 0),
                        LastModifierUserId = c.Long(),
                        DeleterUserId = c.Long(),
                        DeletionTime = c.DateTime(precision: 0),
                        IsDeleted = c.Boolean(nullable: false),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Tag_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.merchant", t => t.merchant_id)
                .Index(t => t.merchant_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tag", "merchant_id", "dbo.merchant");
            DropForeignKey("dbo.member", "merchant_id", "dbo.merchant");
            DropForeignKey("dbo.merchant", "city_id", "dbo.city");
            DropForeignKey("dbo.merchant", "cat_id", "dbo.category");
            DropIndex("dbo.tag", new[] { "merchant_id" });
            DropIndex("dbo.merchant", new[] { "cat_id" });
            DropIndex("dbo.merchant", new[] { "city_id" });
            DropIndex("dbo.member", new[] { "merchant_id" });
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
