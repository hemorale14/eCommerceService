using AutoMapper;

namespace ECommerceServices.Api.Book.Application
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Model.Book, BookDto>();
        }
    }
}
