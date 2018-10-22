using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoogleBooksApi.ClientApp.Models;

namespace GoogleBooksApi.ClientApp.Services
{
    /// <summary>
    /// Wrapper on Google Books Api
    /// </summary>
    public class BookApi : IBookApi
    {
        private readonly IBookService _booksService;

        public BookApi(IBookService bookClientService)
        {
          _booksService = bookClientService;
        }

    /// <summary>
    /// Search Google Books API
    /// </summary>
    /// <param name="query">Query string</param>
    /// <param name="offset"> </param>
    /// <param name="count">the number of records to return</param>
    /// <returns></returns>
    public async Task<Tuple<int?, List<Book>>> Search(string query, int offset, int count)
        {
            return await Task.Run(() =>
            {
                try
                {
                    var listquery = _booksService.Volumes.List(query);
                    listquery.MaxResults = count;
                    listquery.StartIndex = offset;
                    var res = listquery.Execute();
                     
                    var books = res.Items?.Select(b => new Book
                    {
                        Id = b.Id,
                        Title = b.VolumeInfo.Title,
                        Authors =  b.VolumeInfo.Authors,
                        Publisher = b.VolumeInfo.Publisher,
                        InfoLink =  b.VolumeInfo.InfoLink,
                        Subtitle = b.VolumeInfo.Subtitle,
                        Description = b.VolumeInfo.Description,
                        PageCount = b.VolumeInfo.PageCount,
                        Image = b.VolumeInfo.ImageLinks?.Thumbnail

                    }).ToList();
                    return new Tuple<int?, List<Book>>(res.TotalItems, books);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            });

        }
    }
}
