using Abp.Domain.Repositories;
using EasyLife.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyLife
{
    public interface IMerchantRepository : IRepository<Merchant, int>
    {
    }
}
