using System.Collections.Generic;

namespace GoogleBooksApi.Controllers
{
    /// <summary>
    /// Books Model
    /// </summary>
    public class Book
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Subtitle { get; set; }
        public string Description { get; set; }
        public int? PageCount { get; set; }
        public IList<string> Authors { get; set; }
        public string InfoLink { get; set; }
        public string Publisher { get; set; }
        public string Image { get; set; }
    }
}