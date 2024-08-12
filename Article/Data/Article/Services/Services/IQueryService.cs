namespace ArticleApp.Data
{
    public interface IQueryService<T>
    {
        Task<T> GetById(long id,CancellationToken cancellationToken);
        Task<List<T>> GetAll();
        Task<List<Article>> GetArticlesPaginated(int pageNumber, int pageSize, CancellationToken cancellationToken);
    }
}
