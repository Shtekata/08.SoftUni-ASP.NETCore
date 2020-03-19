namespace WebApiDemo.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using WebApiDemo.Models.InputModels.Articles;

    public interface IArticleService
    {
        Task<T> CreateAsync<T>(ArticleCreateInputModel model, string userId);

        Task<IEnumerable<T>> GetAllAsync<T>();

        Task<T> GetAsync<T>(int articleId);
    }
}
