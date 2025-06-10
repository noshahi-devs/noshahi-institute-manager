using Abp.Application.Services.Dto;
using System;

namespace NIM.TeacherProfiles.Dto
{
    public class TeacherProfileDto : EntityDto<int>
    {
        public long UserId { get; set; }
        public string UserName { get; set; }
        public string CNIC { get; set; }
        public DateTime DateOfJoining { get; set; }
        public int CampusId { get; set; }
        public string CampusName { get; set; }
        public string Qualification { get; set; }
        public bool IsActive { get; set; }
    }
}
