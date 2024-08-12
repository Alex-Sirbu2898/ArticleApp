using MediatR;

namespace ArticleApp.Business.Articles.Commands.Delete
{
    public class DeleteArticleCommand : IRequest<int?>
    {
        public long Id { get; set; }

        public DeleteArticleCommand(long id)
        {
            Id = id;
        }
    }
}
