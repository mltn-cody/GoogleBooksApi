using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GoogleBooksApi.ClientApp.Models;
using GoogleBooksApi.ClientApp.Services;
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
        public async Task<IEnumerable<Book>> Search(string query, int offset=0)
        {
            try
            {
                if (string.IsNullOrEmpty(query)) return null;
                var result = await _bookApi.Search(query,offset);
                return result.Item2;
            }
            catch (Exception ex)
            {
                // Todo: do some stuff to track the message in ELK or some other logging system..
                throw new FriendlyUiException("Search Failed!");
            }
        }


    }

    public class FriendlyUiException : Exception
    {
        public FriendlyUiException(string message) 
            : base(message)
        {
            
        }
    }
}
