using ArticleApp.Data;
using AutoMapper;
using MediatR;

namespace ArticleApp.Business.Articles.Queries.Paginate
{
    public sealed class PagedArticlesHandler : IRequestHandler<PagedArticleQuery, PagedArticleResponse>
    {
        private readonly IQueryService<Article> _articleQueryService;
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public PagedArticlesHandler(ApplicationDbContext dbContext, IQueryService<Article> employeeQueryService, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _articleQueryService = employeeQueryService;
        }

        public async Task<PagedArticleResponse> Handle(PagedArticleQuery request, CancellationToken cancellationToken)
        {
            var pagedResult = await _articleQueryService.GetArticlesPaginated(request.PageNumber,request.PageSize,cancellationToken);

            return _mapper.Map<PagedArticleResponse>(pagedResult);
        }
    }
}
