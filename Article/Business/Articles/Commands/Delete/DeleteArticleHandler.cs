using ArticleApp.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ArticleApp.Business.Articles.Commands.Delete
{
    public class DeleteArticleHandler : IRequestHandler<DeleteArticleCommand, int?>
    {

        private readonly ApplicationDbContext _applicationDbContext;

        public DeleteArticleHandler(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public async Task<int?> Handle(DeleteArticleCommand command, CancellationToken cancellationToken)
        {
            var article = await _applicationDbContext.Articles.SingleOrDefaultAsync(x => x.Id == command.Id, cancellationToken);

            if (article == null)
                return -1;

            _applicationDbContext.Articles.Remove(article);
            await _applicationDbContext.SaveChangesAsync();

            return 204;
        }
    }
}
