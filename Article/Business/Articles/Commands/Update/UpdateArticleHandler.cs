using ArticleApp.Data;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ArticleApp.Business.Articles.Commands.Update
{
    public class UpdateArticleHandler : IRequestHandler<UpdateArticleCommand, long>
    {
        private ApplicationDbContext _dbContext;

        public UpdateArticleHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<long> Handle(UpdateArticleCommand request, CancellationToken cancellationToken)
        {
            var dbEntity = await _dbContext.Articles.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (dbEntity == null)
            {
                // Throw an appropriate exception or handle it according to your application's needs
                throw new Exception($"Article with ID {request.Id} not found.");
            }

            if (!string.IsNullOrEmpty(request.Title))
            {
                dbEntity.Title = request.Title;
            }

            if (!string.IsNullOrEmpty(request.Content))
            {
                dbEntity.Content = request.Content;
            }

            if (request.PublishedDate != null)
            {
                dbEntity.PublishedDate = request.PublishedDate.Value.ToUniversalTime();
            }

            _dbContext.Update(dbEntity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return dbEntity.Id;
        }
    }
}
