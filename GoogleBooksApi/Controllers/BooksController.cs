using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace GoogleBooksApi.Controllers
{
    [Route("api/[controller]")]
    public class BooksController : Controller
    {
        private readonly IBookApi _bookApi;

        public BooksController(IBookApi bookApi)
        {
            _bookApi = bookApi;
        }

        [HttpGet("[action]")]
        public async Task<IEnumerable<Book>> Search(string query)
        {
            var result = await _bookApi.Search(query, 0, 10);
            return result.Item2;
        }
    }
}
