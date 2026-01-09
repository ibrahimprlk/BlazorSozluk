using AutoMapper;
using BlozorSozluk.Api.Domain.Models;
using BlozorSozluk.Common.ViewModels.Queries;
using BlozorSozluk.Common.ViewModels.RequestModels;

namespace BlozorSozluk.Api.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            ShouldMapMethod = method =>
           !method.DeclaringType!.FullName!.StartsWith("System.Linq");

            CreateMap<User, LoginUserViewModel>()
                .ReverseMap();


            //CreateMap<User, CreateUserCommand>()
            //   .ReverseMap();

            CreateMap<CreateUserCommand, User>()
              .ReverseMap();

            CreateMap<User, UpdateUserCommand>()
             .ReverseMap();
        }
    }
}
