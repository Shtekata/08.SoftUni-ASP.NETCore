namespace ForumSystem.Web.Controllers
{
    using System;

    using ForumSystem.Services.Data;
    using ForumSystem.Web.ViewModels.Categories;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    public class CategoriesController : BaseController
    {
        private const int ItemsPerPage = 3;

        private readonly ICategoriesService categoriesService;
        private readonly IPostsService postsService;
        private readonly ILogger<CategoriesController> logger;
        private readonly IHttpContextAccessor http;

        public CategoriesController(ICategoriesService categoriesService, IPostsService postsService, ILogger<CategoriesController> logger, IHttpContextAccessor http)
        {
            this.categoriesService = categoriesService;
            this.postsService = postsService;
            this.logger = logger;
            this.http = http;
        }

        public IActionResult ByName(string name, int id = 1)
        {
            this.logger.LogDebug(id.ToString());

            var viewModel = this.categoriesService.GetByName<CategoryViewModel>(name);
            if (viewModel == null)
            {
                return this.NotFound();
            }

            viewModel.ForumPosts = this.postsService.GetByCategoryId<PostInCategoryViewModel>(viewModel.Id, ItemsPerPage, (id - 1) * ItemsPerPage);

            var count = this.postsService.GetCountByCategoryId(viewModel.Id);
            viewModel.PagesCount = (int)Math.Ceiling((double)count / ItemsPerPage);
            if (viewModel.PagesCount == 0)
            {
                viewModel.PagesCount = 1;
            }

            viewModel.CurrentPage = id;

            return this.View(viewModel);
        }
    }
}
