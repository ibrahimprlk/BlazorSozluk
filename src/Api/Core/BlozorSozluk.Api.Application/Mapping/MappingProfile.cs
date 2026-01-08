using AutoMapper;
using BlozorSozluk.Api.Domain.Models;
using BlozorSozluk.Common.ViewModels.Queries;

namespace BlozorSozluk.Api.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, LoginUserViewModel>()
                .ReverseMap();
        }
    }
}
