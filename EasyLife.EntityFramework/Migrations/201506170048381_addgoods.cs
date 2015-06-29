namespace EasyLife.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class addgoods : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.goods",
                c => new
                    {
                        goods_Id = c.Int(nullable: false, identity: true),
                        name = c.String(maxLength: 150, storeType: "nvarchar"),
                        goods_pic = c.String(maxLength: 150, storeType: "nvarchar"),
                        price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        discount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        discount_price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        save_money = c.Decimal(nullable: false, precision: 18, scale: 2),
                        category_id = c.Int(nullable: false),
                        status = c.Int(nullable: false),
                        merchant_id = c.Int(nullable: false),
                        creator_userId = c.Long(),
                        creation_time = c.DateTime(nullable: false, precision: 0),
                        last_modification_time = c.DateTime(precision: 0),
                        last_modifier_userId = c.Long(),
                        deleter_userId = c.Long(),
                        deletion_time = c.DateTime(precision: 0),
                        is_deleted = c.Boolean(nullable: false),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Goods_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.goods_Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.goods",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_Goods_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
    }
}
