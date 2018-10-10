using Google.Apis.Books.v1;
using Google.Apis.Services;

namespace GoogleBooksApi.Controllers
{
    /// <summary>
    /// Wrapper Class on google BooksService to facilitate testing. 
    /// </summary>
    public class GoogleApiBookService : IBookService
    {
        private readonly BooksService _booksService;

        public GoogleApiBookService(string apiKey)
        {
            _booksService = new BooksService(new BaseClientService.Initializer()
            {
                ApiKey = apiKey,
                ApplicationName = this.GetType().ToString()
            });
        }

        public VolumesResource Volumes => _booksService.Volumes;
    }
}