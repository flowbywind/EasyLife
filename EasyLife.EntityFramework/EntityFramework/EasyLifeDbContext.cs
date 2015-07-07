using Abp.EntityFramework;
using EasyLife.Core;
using System.Data.Common;
using System.Data.Entity;
using EasyLife.Core.ShoppingCart;

namespace EasyLife.EntityFramework
{
    public class EasyLifeDbContext : AbpDbContext
    {
        //TODO: Define an IDbSet for each Entity...
        public virtual IDbSet<Category> Category { get; set; }

        public virtual IDbSet<City> City { get; set; }

        public virtual IDbSet<Merchant> Merchant { get; set; }

        public virtual IDbSet<Tag> Tag { get; set; }

        public virtual IDbSet<Member> Member { get; set; }

        /// <summary>
        /// 商品表
        /// </summary>
        public virtual IDbSet<Goods> Goods { get; set; }

        public virtual IDbSet<ShoppingCart> ShoppingCart { get; set; }

        public EasyLifeDbContext()
            : base("Default")
        {

        }

        public EasyLifeDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        //This constructor is used in tests
        public EasyLifeDbContext(DbConnection connection)
            : base(connection, true)
        {

        }

    }
}
