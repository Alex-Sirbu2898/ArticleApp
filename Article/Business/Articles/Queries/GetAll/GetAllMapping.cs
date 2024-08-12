using ArticleApp.Data;
using AutoMapper;

namespace ArticleApp.Business.Articles.Queries.GetAll
{
    public sealed class GetAllMapping : Profile
    {
        public GetAllMapping()
        {
            CreateMap<List<Article>, GetAllResponse>()
                .ForMember(x => x.Articles, y => y.MapFrom(x => x));
        }
    }
}
