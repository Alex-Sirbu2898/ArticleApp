using ArticleApp.Data;
using Microsoft.EntityFrameworkCore;

namespace Regnology.Data
{
    public sealed class ArticleQueryService : IQueryService<Article>
    {
        private readonly ApplicationDbContext _context;

        public ArticleQueryService(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }


        private IQueryable<Article> GetQuery()
        {
            return _context.Articles.AsNoTracking();
        }

        public async Task<Article> GetById(long id, CancellationToken cancellationToken)
        {
            return await this.GetQuery().Where(x => x.Id == id).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<long> GetCount(CancellationToken cancellationToken)
        {
            return await this._context.Articles.CountAsync(cancellationToken);
        }

        public async Task<List<Article>> GetAll()
        {
            return  await GetQuery().ToListAsync();
        }

        public async Task<List<Article>> GetArticlesPaginated(int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            var query = GetQuery();

            query = query.Skip((pageNumber - 1) * pageSize)
                         .Take(pageSize);

            return await query.ToListAsync(cancellationToken);
        }

    }
}
