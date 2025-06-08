using AutoMapper;
using NIM.Entities;

namespace NIM.Tests.Dto
{
    public class TestMapProfile : Profile
    {
        public TestMapProfile()
        {
            CreateMap<Test, TestDto>();
            CreateMap<CreateTestDto, Test>();
            CreateMap<UpdateTestDto, Test>();
        }
    }
}
