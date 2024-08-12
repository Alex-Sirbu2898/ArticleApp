namespace ArticleApp.Controllers
{
    public class PagedArticleRequest
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
