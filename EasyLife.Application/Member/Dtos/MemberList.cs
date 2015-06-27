using Abp.Application.Services.Dto;
using System.Collections.Generic;

namespace EasyLife
{
    public class MemberList : IOutputDto
    {
        public List<MemberDto> MemberDtos { get; set; }

    }
}
