namespace ArticleApp.Controllers
{
    public class UpdateArticleRequest
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public DateTime? PublishedDate { get; set; }
    }
}
