using Google.Apis.Books.v1;

namespace GoogleBooksApi.Controllers
{
    /// <summary>
    /// Wrapper class used for testing 
    /// </summary>
    public interface IBookService
    {
        VolumesResource Volumes { get; }
    }
}
