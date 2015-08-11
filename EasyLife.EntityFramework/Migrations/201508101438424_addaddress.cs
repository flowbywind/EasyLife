namespace EasyLife.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class addaddress : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MemberAddress",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
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
                        is_default = c.Int(nullable: false),
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
                    { "DynamicFilter_MemberAddress_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MemberAddress",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "DynamicFilter_MemberAddress_SoftDelete", "EntityFramework.DynamicFilters.DynamicFilterDefinition" },
                });
        }
    }
}
