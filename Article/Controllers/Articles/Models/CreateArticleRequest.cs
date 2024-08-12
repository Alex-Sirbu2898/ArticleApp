namespace ArticleApp.Controllers
{
    public class CreateArticleRequest
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PublishedDate { get; set; }
    }
}
