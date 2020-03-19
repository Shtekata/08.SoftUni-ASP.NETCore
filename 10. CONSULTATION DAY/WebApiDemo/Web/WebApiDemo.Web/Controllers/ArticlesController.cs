namespace WebApiDemo.Web.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using WebApiDemo.Models.InputModels.Articles;
    using WebApiDemo.Models.ViewModels.Articles;
    using WebApiDemo.Services;
    using WebApiDemo.Web.Infrastructure.Extensions;

    public class ArticlesController : BaseController
    {
        private readonly IArticleService articleService;

        public ArticlesController(IArticleService articleService)
        {
            this.articleService = articleService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(ArticleCreateInputModel inputModel)
        {
            var userId = this.User.GetId();
            var createdArticle = await this.articleService.CreateAsync<ArticleCreateViewModel>(inputModel, userId);

            return this.Created($"articles/{createdArticle.Id}", createdArticle);
        }

        public async Task<IActionResult> GetAll()
        {
            var articles = await this.articleService.GetAllAsync<ArticleViewModel>();

            return this.Ok(articles);
        }

        [Route("{articleId}")]
        public async Task<IActionResult> Get(int articleId)
        {
            var article = await this.articleService.GetAsync<ArticleDetailsViewModel>(articleId);

            if (article == null)
            {
                return this.NotFound();
            }

            return this.Ok(article);
        }
    }
}
