using ECommerceServices.Api.ShoppingCart.RemoteModel;
using System;
using System.Threading.Tasks;

namespace ECommerceServices.Api.ShoppingCart.RemoteInterface
{
    public interface IBookService
    {
        Task<(bool result, RemoteBook Book, string ErrorMessage)> GetBook(Guid BookId);
    }
}
