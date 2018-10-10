using Google.Apis.Books.v1;

namespace GoogleBooksApi.Controllers
{
    public interface IBookService
    {
        VolumesResource Volumes { get; }
    }
}