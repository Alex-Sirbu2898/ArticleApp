using ArticleApp.Data;
using MediatR;

namespace ArticleApp.Business.Articles.Commands.Create
{
    public sealed class CreateArticleHandler : IRequestHandler<CreateArticleCommand, long>
    {
        private ApplicationDbContext _dbContext;

        public CreateArticleHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<long> Handle(CreateArticleCommand request, CancellationToken cancellationToken)
        {

            var article = new Article()
            {
                Title = request.Title,
                Content = request.Content,
                PublishedDate = request.PublishedDate.ToUniversalTime(),
            };

            await _dbContext.AddAsync(article, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return article.Id;
        }



    }


}

