using AutoMapper;
using ECommerceServices.Api.Book.Application;
using ECommerceServices.Api.Book.Persistence;
using GenFu;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace eCommerceService.Api.Book.Test
{
    public class BookServiceTest
    {
        private IEnumerable<ECommerceServices.Api.Book.Model.Book> GetDataTest()
        {
            A.Configure<ECommerceServices.Api.Book.Model.Book>()
                 .Fill(b => b.Title).AsArticleTitle()
                 .Fill(b => b.AuthorGuid, () => { return Guid.NewGuid(); });
            var list = A.ListOf<ECommerceServices.Api.Book.Model.Book>(30);
            list[0].BookId = Guid.Empty;
            return list;
        }

        private Mock<BookContext> GetContext()
        {
            var dataTest = GetDataTest().AsQueryable();
            var dbSet = new Mock<DbSet<ECommerceServices.Api.Book.Model.Book>>();
            dbSet.As<IQueryable<ECommerceServices.Api.Book.Model.Book>>().Setup(db => db.Provider).Returns(dataTest.Provider);
            dbSet.As<IQueryable<ECommerceServices.Api.Book.Model.Book>>().Setup(db => db.Expression).Returns(dataTest.Expression);
            dbSet.As<IQueryable<ECommerceServices.Api.Book.Model.Book>>().Setup(db => db.ElementType).Returns(dataTest.ElementType);
            dbSet.As<IQueryable<ECommerceServices.Api.Book.Model.Book>>().Setup(db => db.GetEnumerator()).Returns(dataTest.GetEnumerator());

            dbSet.As<IAsyncEnumerable<ECommerceServices.Api.Book.Model.Book>>()
                .Setup(b => b.GetAsyncEnumerator(new System.Threading.CancellationToken()))
                .Returns(new AsyncEnumerator<ECommerceServices.Api.Book.Model.Book>(dataTest.GetEnumerator()));

            dbSet.As<IQueryable<ECommerceServices.Api.Book.Model.Book>>()
                .Setup(x => x.Provider)
                .Returns(new AsyncQueryProvider<ECommerceServices.Api.Book.Model.Book>(dataTest.Provider));
            var context = new Mock<BookContext>();
            context.Setup(c => c.Book).Returns(dbSet.Object);
            return context;
        }
        [Fact]
        public async void GetBookById()
        {

            var mockContext = GetContext();
            var mapConfig = new MapperConfiguration(cfg => cfg.AddProfile(new MappingTest()));
            var mapper = mapConfig.CreateMapper();

            var request = new QueryFilter.BookUnic();
            request.BookId = Guid.Empty;

            var managerHandler = new QueryFilter.ManageHandler(mockContext.Object, mapper);
            var book = await managerHandler.Handle(request, new System.Threading.CancellationToken());
            Assert.NotNull(book);
            Assert.True(book.BookId == Guid.Empty);
        }

        [Fact]
        public async void GetBooks()
        {
            //Test continuous integration 
            //System.Diagnostics.Debugger.Launch();
            //Emular 
            var mockContext = GetContext();
            var mapConfig = new MapperConfiguration(cfg => cfg.AddProfile(new MappingTest()));
            var mapper = mapConfig.CreateMapper();

            //intanciar al Manage
            var manageHandler = new Query.ManageHandler(mockContext.Object, mapper);
            Query.BookList bookList = new Query.BookList();
            var list = await manageHandler.Handle(bookList, new System.Threading.CancellationToken());
            Assert.True(list.Any());
        }

        [Fact]
        public async void SaveBook()
        {

            ///System.Diagnostics.Debugger.Launch();

            //base de datos en memoria
            var options = new DbContextOptionsBuilder<BookContext>()
                .UseInMemoryDatabase(databaseName: "bookstore")
                .Options;

            var context = new BookContext(options);

            var request = new New.Execute() { AuthorGuid = Guid.Empty, PublishDate = DateTime.Now, Title = "Book service Test" };
            var manageHandler = new New.ManageHandler(context);
            var result = await manageHandler.Handle(request, new System.Threading.CancellationToken());

            Assert.True(result != null);
        }
    }
}
