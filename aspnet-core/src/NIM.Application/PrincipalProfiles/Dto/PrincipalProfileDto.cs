using System;
using Abp.Application.Services.Dto;

namespace NIM.PrincipalProfiles.Dto
{
    public class PrincipalProfileDto : EntityDto<int>
    {
        public long UserId { get; set; }
        public string UserName { get; set; }
        public int CampusId { get; set; }
        public string CampusName { get; set; }
        public string CNIC { get; set; }
        public DateTime DateOfJoining { get; set; }
        public bool IsActive { get; set; }
    }
}
