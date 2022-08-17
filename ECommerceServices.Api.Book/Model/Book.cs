using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerceServices.Api.Book.Model
{
    public class Book
    {
        public Guid? BookId { get; set; }
        public string Title { get; set; }
        public DateTime? PublishDate { get; set; }
        public Guid? AuthorGuid { get; set; }
    }
}
