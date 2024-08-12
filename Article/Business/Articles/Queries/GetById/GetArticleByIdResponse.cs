namespace ArticleApp.Business.Articles.Queries.GetById
{
    public class GetArticleByIdResponse
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PublishedDate { get; set; }
    }
}
