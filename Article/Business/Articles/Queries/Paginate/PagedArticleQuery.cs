using MediatR;

namespace ArticleApp.Business.Articles.Queries.Paginate
{
    public class PagedArticleQuery : IRequest<PagedArticleResponse>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; } = 10;
    }
}
