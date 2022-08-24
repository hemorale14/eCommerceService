using System;

namespace ECommerceServices.Api.Author.Model
{
    public class Degree
    {
        public int DegreeId { get; set; }
        public string Name { get; set; }
        public string School { get; set; }
        public DateTime? GraduatedDate { get; set; }


        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public string DegreeGuid { get; set; }

    }
}
