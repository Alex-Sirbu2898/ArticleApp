using ArticleApp.Business.Articles.Queries.GetAll;
using ArticleApp.Data;
using AutoMapper;

namespace ArticleApp.Business.Articles.Queries.Paginate
{
    public sealed class PageArticleMapping : Profile
    {
        public PageArticleMapping()
        {
            CreateMap<List<Article>, PagedArticleResponse>()
                 .ForMember(x => x.Articles, y => y.MapFrom(x => x));
        }
    }
}
