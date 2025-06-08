using System;
using Abp.Application.Services.Dto;

namespace NIM.AccountantProfiles.Dto
{
    public class AccountantProfileDto : EntityDto<int>
    {
        public long UserId { get; set; }
        public int CampusId { get; set; }
        public string CNIC { get; set; }
        public DateTime DateOfJoining { get; set; }
        public bool IsActive { get; set; }
    }
}
