using MediatR;

namespace ArticleApp.Business.Articles.Commands.Update
{
    public class UpdateArticleCommand : IRequest<long>
    {
        public long Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public DateTime? PublishedDate { get; set; }

    }

    public sealed class UpdateArticleResponse
    {
        public long Id { get; set; }
    }
}
