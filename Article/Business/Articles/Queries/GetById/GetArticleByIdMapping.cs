using ArticleApp.Data;
using AutoMapper;

namespace ArticleApp.Business.Articles.Queries.GetById
{
    public sealed class GetArticleByIdMapping : Profile
    {
        public GetArticleByIdMapping()
        {
            CreateMap<Article, GetArticleByIdResponse>();
        }
    }
}
