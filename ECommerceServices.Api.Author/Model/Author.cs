using System;
using System.Collections.Generic;

namespace ECommerceServices.Api.Author.Model
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime? BornDate { get; set; }
        public ICollection<Degree> DegreeList { get; set; }
        public string AuthorGuid { get; set; }
    }
}
