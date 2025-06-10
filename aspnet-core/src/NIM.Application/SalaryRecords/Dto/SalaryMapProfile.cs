using AutoMapper;
using NIM.Entities;

namespace NIM.SalaryRecords.Dto
{
    public class SalaryMapProfile : Profile
    {
        public SalaryMapProfile()
        {
            CreateMap<SalaryRecord, SalaryRecordDto>();
            CreateMap<CreateSalaryRecordDto, SalaryRecord>();
            CreateMap<UpdateSalaryRecordDto, SalaryRecord>();
        }
    }
}
