namespace WebApiDemo.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using WebApiDemo.Common.Mapping;
    using WebApiDemo.Data.Common.Repositories;
    using WebApiDemo.Data.Models;
    using WebApiDemo.Models.InputModels.Articles;

    public class ArticleService : IArticleService
    {
        private readonly IDeletableEntityRepository<Article> articleRepository;

        public ArticleService(IDeletableEntityRepository<Article> articleRepository)
        {
            this.articleRepository = articleRepository;
        }

        public async Task<T> CreateAsync<T>(ArticleCreateInputModel model, string userId)
        {
            var article = new Article
            {
                Name = model.Name,
                Content = model.Content,
                AuthorId = userId,
            };

            this.articleRepository.Add(article);
            await this.articleRepository.SaveChangesAsync();

            var articleViewModel = await this.articleRepository
               .AllAsNoTracking()
               .Where(x => x.Id == article.Id)
               .To<T>()
               .SingleAsync();

            return articleViewModel;
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>()
        {
            var articles = await this.articleRepository
                .AllAsNoTracking()
                .To<T>()
                .ToArrayAsync();

            return articles;
        }

        public async Task<T> GetAsync<T>(int articleId)
        {
            var article = await this.articleRepository
                .AllAsNoTracking()
                .Where(x => x.Id == articleId)
                .To<T>()
                .SingleOrDefaultAsync();

            return article;
        }
    }
}
