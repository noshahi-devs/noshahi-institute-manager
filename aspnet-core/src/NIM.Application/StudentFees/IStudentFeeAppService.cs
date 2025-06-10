using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System.Threading.Tasks;
using NIM.StudentFees.Dto;

namespace NIM.StudentFees
{
    public interface IStudentFeeAppService : IApplicationService
    {
        Task<StudentFeeDto> Get(int id);
        Task<PagedResultDto<StudentFeeDto>> GetAll(PagedStudentFeeResultRequestDto input);
        Task<StudentFeeDto> Create(CreateStudentFeeDto input);
        Task<StudentFeeDto> Update(UpdateStudentFeeDto input);
        Task Delete(int id);
    }
}
