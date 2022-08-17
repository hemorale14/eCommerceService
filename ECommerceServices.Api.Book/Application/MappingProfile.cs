using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
