using MediatR;

namespace ArticleApp.Business.Articles.Queries.GetById
{
    public class GetArticleByIdQuery : IRequest<GetArticleByIdResponse>
    {
        public long Id { get; set; }

        public GetArticleByIdQuery(long id)
        {
            Id = id;
        }
    }
}
