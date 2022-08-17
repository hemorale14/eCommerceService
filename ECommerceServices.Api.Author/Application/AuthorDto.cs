using System;

namespace ECommerceServices.Api.Author.Application
{
    public class AuthorDto
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime? BornDate { get; set; }
        public string AuthorGuid { get; set; }
    }
}
