using AutoMapper;
using Abp.Application.Services.Dto;
using NIM.Entities;
using NIM.AccountantProfiles.Dto;

namespace NIM.AccountantProfiles.Dto
{
    public class AccountantMapProfile : Profile
    {
        public AccountantMapProfile()
        {
            CreateMap<AccountantProfile, AccountantProfileDto>();
            CreateMap<CreateAccountantProfileDto, AccountantProfile>();
            CreateMap<UpdateAccountantProfileDto, AccountantProfile>();
        }
    }
}
