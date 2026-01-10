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

            CreateMap<CreateEntryCommand, Entry>()
           .ReverseMap();

            CreateMap<CreateEntryCommentCommand, EntryComment>()
                .ReverseMap();

            // Bu ViewModel'de CommentCount alani Entry'de olmadigi icin bu alani otomatik set edemeyeceginden EntryComments altindaki Count bilgisini set etmesi gerektigini soyledik.
            CreateMap<Entry, GetEntriesViewModel>()
                .ForMember(x => x.CommentCount, y => y.MapFrom(z => z.EntryComments.Count));


        }
    }
}
