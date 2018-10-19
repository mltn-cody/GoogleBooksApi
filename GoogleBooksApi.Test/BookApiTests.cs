using System;
using System.Collections.Generic;
using AutoMapper;
using Google.Apis.Books.v1.Data;
using GoogleBooksApi.ClientApp.Models;
using GoogleBooksApi.ClientApp.Services;
using GoogleBooksApi.Controllers;
using GoogleBooksApi.Test.Mappings;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using Xunit;

namespace GoogleBooksApi.Test
{
    public class BookApiTests
    {
        private readonly IBookApi _bookApi;
        private readonly IBookService _bookService;
        private readonly IListRequest _listRequest;
        private readonly BooksController _booksController;

        private static readonly List<Book> Books = new List<Book>()
        {
            new Book() {Authors =  new List<string>() {"Bob Hope"}, Title = "Effective C#", Subtitle = "50 Specific Ways to Improve Your C# Second Edition", PageCount = 328, Id = "98970", Image = ""},
            new Book() {Authors =  new List<string>(), Title = "Effective C#", Subtitle = "50 Specific Ways to Improve Your C# ", PageCount = 307, Description = "Study Book", Id = "23938", Image = ""},
            new Book() {Authors =  new List<string>(), Title = "More Effective C#", PageCount = 297, Description = "Study Book", Id = "32982837", Image = ""}
        };

        public BookApiTests()
        {
            var stubVolumesResource = Substitute.For<IVolumesResource>();
            _listRequest = Substitute.For<IListRequest>();
            stubVolumesResource.List(Arg.Any<string>()).Returns(_listRequest);
            _bookService = Substitute.For<IBookService>();
            _bookApi = new BookApi(_bookService);
            _bookService.Volumes
                .Returns(stubVolumesResource);

            Mapper.Initialize(x => x.AddProfile(typeof(MappingUnitTestConfiguration)));

            _listRequest.Execute().Returns(new Volumes()
            {
                Items = new List<Volume>()
                {
                    new Volume() {Id = Books[0].Id, VolumeInfo = Mapper.Map<Volume.VolumeInfoData>(Books[0])},
                    new Volume() {Id = Books[1].Id, VolumeInfo = Mapper.Map<Volume.VolumeInfoData>(Books[1])},
                    new Volume() {Id = Books[2].Id, VolumeInfo = Mapper.Map<Volume.VolumeInfoData>(Books[2])},
                }
            });

            _booksController = new BooksController(_bookApi);
        }

        [Fact]
        public void GetBooksServiceTest()
        {
            var result = _bookApi.Search(Arg.Any<string>(), Arg.Any<int>(), Arg.Any<int>()).Result;
            _bookService.Volumes.Received(1);
            _bookService.Volumes.List(Arg.Any<string>()).Received(1);
            _listRequest.Received(1).Execute();
            Assert.Equal(Books[0].Authors, result.Item2[0].Authors);
        }

        [Fact]
        public async System.Threading.Tasks.Task BookService_ThowException()
        {
            var msg = "Custom Internal Server Error";
            _bookService.Volumes.Throws(new Exception(msg));
            var exception = await Assert.ThrowsAsync<FriendlyUiException>(() => ( _booksController.Search("C#")));
            Assert.Equal("Search Failed!", exception.Message);
        }

    }
}
