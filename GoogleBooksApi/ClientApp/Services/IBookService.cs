namespace GoogleBooksApi.ClientApp.Services
{
    /// <summary>
    /// Wrapper class used for testing 
    /// </summary>
    public interface IBookService
    {
      IVolumesResource Volumes { get; }
    }
}
