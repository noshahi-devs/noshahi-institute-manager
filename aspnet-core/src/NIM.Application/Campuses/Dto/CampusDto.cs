using Abp.Application.Services.Dto;
using NIM.Entities; // Make sure this using is at the top

namespace NIM.Campuses.Dto
{
    public class CampusDto : EntityDto<int>
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }
}