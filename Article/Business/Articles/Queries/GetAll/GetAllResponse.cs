using ArticleApp.Data;

namespace ArticleApp.Business.Articles.Queries.GetAll
{
    public class GetAllResponse
    {
        public List<Data.Article>? Articles { get; set; }
    }
}
