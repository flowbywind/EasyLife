using Abp.Domain.Repositories;
using System.Linq;

namespace EasyLife
{
    public interface IMemberRepository : IRepository<Member, int>
    {
        IQueryable<Member> GetMembersByMemberID(int merchantid, int pageNumber, int pageSize, out int totalCount);
    }
}
