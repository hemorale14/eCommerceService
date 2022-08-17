using ECommerceServices.Api.ShoppingCart.RemoteInterface;
using ECommerceServices.Api.ShoppingCart.RemoteModel;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ECommerceServices.Api.ShoppingCart.RemoteService
{
    public class BookService : IBookService
    {
        private readonly IHttpClientFactory _httpClient;
        private readonly ILogger<BookService> _logger;

        public BookService(IHttpClientFactory httpClient, ILogger<BookService> logger) {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<(bool result, RemoteBook Book, string ErrorMessage)> GetBook(Guid BookId)
        {
            try
            {
                var client = _httpClient.CreateClient("Books");
                var response = await client.GetAsync($"api/Book/{BookId}");
                if (response.IsSuccessStatusCode) {
                    var content = await response.Content.ReadAsStringAsync();
                    var option = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                    var objBook = JsonSerializer.Deserialize<RemoteBook>(content, option);
                    return (true, objBook, null);
                }
                return (false, null, response.ReasonPhrase);
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex.ToString());
                return (false, null, ex.Message);
            }
        }
    }
}
