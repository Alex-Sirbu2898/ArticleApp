using ArticleApp.Data;
using AutoMapper;
using MediatR;

namespace ArticleApp.Business.Articles.Queries.GetAll
{
    public sealed class GetAllHandler : IRequestHandler<GetAllQuery, GetAllResponse>
    {
        private readonly IQueryService<Data.Article> _articleQueryService;
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetAllHandler(ApplicationDbContext dbContext, IQueryService<Data.Article> articleQueryService, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _articleQueryService = articleQueryService;
        }

        public async Task<GetAllResponse> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {
            var articles = await _articleQueryService.GetAll();

            return _mapper.Map<GetAllResponse>(articles);
        }
    }
}
