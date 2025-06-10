using Abp.Application.Services;
using Abp.Application.Services.Dto;
using NIM.TeacherProfiles.Dto;
using System.Threading.Tasks;

namespace NIM.TeacherProfiles
{
    public interface ITeacherProfileAppService : IApplicationService
    {
        Task<TeacherProfileDto> Get(int id);
        Task<PagedResultDto<TeacherProfileDto>> GetAll(PagedTeacherProfileResultRequestDto input);
        Task<TeacherProfileDto> Create(CreateTeacherProfileDto input);
        Task<TeacherProfileDto> Update(UpdateTeacherProfileDto input);
        Task Delete(int id);
        Task<TeacherProfileDto> CreateUserAndTeacherProfile(CreateUserAndTeacherProfileInput input);
    }
}
