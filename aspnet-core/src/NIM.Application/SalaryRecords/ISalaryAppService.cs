using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System.Threading.Tasks;
using NIM.SalaryRecords.Dto;

namespace NIM.SalaryRecords
{
    public interface ISalaryAppService : IApplicationService
    {
        Task<SalaryRecordDto> Get(int id);
        Task<PagedResultDto<SalaryRecordDto>> GetAll(PagedSalaryRecordResultRequestDto input);
        Task<SalaryRecordDto> Create(CreateSalaryRecordDto input);
        Task<SalaryRecordDto> Update(UpdateSalaryRecordDto input);
        Task Delete(int id);
    }
}
