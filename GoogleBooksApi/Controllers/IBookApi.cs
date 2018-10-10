using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoogleBooksApi.Controllers
{
    public interface IBookApi
    {
        Task<Tuple<int?, List<Book>>> Search(string query, int offset, int count);
    }
}