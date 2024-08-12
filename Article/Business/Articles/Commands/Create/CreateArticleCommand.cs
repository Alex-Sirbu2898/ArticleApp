using MediatR;

namespace ArticleApp.Business.Articles.Commands.Create
{
    public class CreateArticleCommand : IRequest<long>
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime PublishedDate { get; set; }

    }

    public sealed class CreateArticleResponse
    {
        public long Id { get; set; }
    }
}
