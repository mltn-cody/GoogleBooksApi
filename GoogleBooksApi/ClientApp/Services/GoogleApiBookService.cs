using Google.Apis.Books.v1;
using Google.Apis.Books.v1.Data;
using Google.Apis.Services;

namespace GoogleBooksApi.ClientApp.Services
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

      public IVolumesResource Volumes
      {
        get
        {
          var volumesResourceStub = new VolumesResourceStub(_booksService.Volumes);
          return volumesResourceStub;
        }
      }

    }

  public interface IVolumesResource
  {
    IListRequest List(string query);
  }

  public interface IListRequest
  {
    long? MaxResults { get; set; }
    long? StartIndex { get; set; }
    Volumes Execute();
  }

  public class VolumesResourceStub : IVolumesResource
  {
    private readonly VolumesResource _volumesResource;

    public VolumesResourceStub()
    {

    }
    public VolumesResourceStub(VolumesResource resource)
    {
      _volumesResource = resource;
    }

    public IListRequest List(string query)
    {
      var request = _volumesResource.List(query);
      var stub = new ListRequestStub(request);
      return stub;
    }
  }

  public class ListRequestStub : IListRequest
  {
    private readonly VolumesResource.ListRequest _listRequest;
    public long? MaxResults { get; set; }
    public long? StartIndex { get; set; }

    public ListRequestStub()
    {

    }

    public ListRequestStub(VolumesResource.ListRequest listRequest)
    {
      _listRequest = listRequest;
    }

    public Volumes Execute()
    {
      return _listRequest.Execute();
    }
  }
}
