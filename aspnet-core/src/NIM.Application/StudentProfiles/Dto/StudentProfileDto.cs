using System;
using Abp.Application.Services.Dto;

namespace NIM.StudentProfiles.Dto
{
    public class StudentProfileDto : EntityDto<int>
    {
        public long UserId { get; set; }
        public int CampusId { get; set; }
        public string RollNumber { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public DateTime? LeaveDate { get; set; }
        public string CNIC { get; set; }
        public bool IsActive { get; set; }
        public int ClassId { get; set; }
        public int SectionId { get; set; }
    }
}
