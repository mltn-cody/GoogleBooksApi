using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GoogleBooksApi.ClientApp.Models;

namespace GoogleBooksApi.ClientApp.Services
{
    /// <summary>
    /// BookApi used to stub Search Method
    /// </summary>
    public interface IBookApi
    {
        /// <summary>
        /// Search Google Books API
        /// </summary>
        /// <param name="query">Query string</param>
        /// <param name="offset">Todo: Use for pagination </param>
        /// <param name="count">the number of records to return</param>
        /// <returns></returns>
        Task<Tuple<int?, List<Book>>> Search(string query, int offset = 0, int count = 10);
    }
}
