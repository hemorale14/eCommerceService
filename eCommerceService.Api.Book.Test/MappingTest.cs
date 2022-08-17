using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace eCommerceService.Api.Book.Test
{
    public class MappingTest : Profile
    {
        public MappingTest() {
            CreateMap<ECommerceServices.Api.Book.Model.Book, ECommerceServices.Api.Book.Application.BookDto>();
        }
    }
}
