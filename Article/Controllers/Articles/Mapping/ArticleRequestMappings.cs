using ArticleApp.Business.Articles.Commands.Create;
using ArticleApp.Business.Articles.Commands.Update;
using ArticleApp.Business.Articles.Queries.Paginate;
using AutoMapper;

namespace ArticleApp.Controllers
{
    public class ArticleRequestMappings : Profile
    {
        public ArticleRequestMappings()
        {
            CreateMap<CreateArticleRequest, CreateArticleCommand>();
            CreateMap<UpdateArticleRequest, UpdateArticleCommand>();
            CreateMap<PagedArticleRequest, PagedArticleQuery>();
        }
    }
}
