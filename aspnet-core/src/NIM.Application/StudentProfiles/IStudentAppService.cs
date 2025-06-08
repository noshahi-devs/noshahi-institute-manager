using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System.Threading.Tasks;
using NIM.StudentProfiles.Dto;

namespace NIM.StudentProfiles
{
    public interface IStudentAppService : IApplicationService
    {
        Task<StudentProfileDto> Get(int id);
        Task<PagedResultDto<StudentProfileDto>> GetAll(PagedStudentProfileResultRequestDto input);
        Task<StudentProfileDto> Create(CreateStudentProfileDto input);
        Task<StudentProfileDto> Update(UpdateStudentProfileDto input);
        Task Delete(int id);
        Task<StudentProfileDto> CreateStudentAndUserAsync(CreateStudentAndUserInput input);
    }
}
