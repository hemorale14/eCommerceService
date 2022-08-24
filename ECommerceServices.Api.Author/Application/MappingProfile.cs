using AutoMapper;

namespace ECommerceServices.Api.Author.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Model.Author, AuthorDto>();
        }
    }
}
