using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Google.Apis.Books.v1;
using Google.Apis.Books.v1.Data;
using Google.Apis.Requests;
using Google.Apis.Services;
using GoogleBooksApi.ClientApp.Models;
using GoogleBooksApi.ClientApp.Services;
using GoogleBooksApi.Controllers;
using NSubstitute;
using Xunit;

namespace GoogleBooksApi.Test
{
    public class BookControllerTests
    {
        private readonly BooksController _booksController;
        private static readonly List<Book> Books = new List<Book>()
        {
            new Book() {Title = "Effective C#", Subtitle = "50 Specific Ways to Improve Your C# Second Edition", PageCount = 328, Id = "98970", Image = ""},
            new Book() {Title = "Effective C#", Subtitle = "50 Specific Ways to Improve Your C# ", PageCount = 307, Description = "Study Book", Id = "23938", Image = ""},
            new Book() { Title = "More Effective C#", PageCount = 297, Description = "Study Book", Id = "32982837", Image = ""}
        };

        private readonly Tuple<int?, List<Book>> _bookList = new Tuple<int?, List<Book>>(3, Books);


        public BookControllerTests()
        {
            var bookApi = Substitute.For<IBookApi>();
            bookApi.Search(Arg.Any<string>(), Arg.Any<int>(), Arg.Any<int>()).ReturnsForAnyArgs(_bookList);
            _booksController = new BooksController(bookApi);
        }

        [Fact]
        public async void GetBooksControllerTest()
        {
            var result = await _booksController.Search("C#");
            Assert.Equal(3, result.Count());
        }


    }
}
