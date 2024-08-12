using ArticleApp.Data;
using AutoMapper;
using MediatR;

namespace ArticleApp.Business.Articles.Queries.GetById
{
    public sealed class GetArticleByIdHandler : IRequestHandler<GetArticleByIdQuery, GetArticleByIdResponse>
    {
        private readonly IQueryService<Data.Article> _articleQueryService;
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetArticleByIdHandler(ApplicationDbContext dbContext, IQueryService<Data.Article> articleQueryService, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _articleQueryService = articleQueryService;
        }

        public async Task<GetArticleByIdResponse> Handle(GetArticleByIdQuery request, CancellationToken cancellationToken)
        {
            var article = await _articleQueryService.GetById(request.Id, cancellationToken);

            return _mapper.Map<GetArticleByIdResponse>(article);
        }
    }
}
