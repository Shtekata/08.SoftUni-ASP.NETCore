namespace ForumSystem.Web.Controllers
{
    using System.Threading.Tasks;

    using ForumSystem.Data.Models;
    using ForumSystem.Services.Data;
    using ForumSystem.Services.Mapping;
    using ForumSystem.Web.ViewModels.Posts;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class PostsController : BaseController
    {
        private readonly IPostsService postService;
        private readonly ICategoriesService categoriesService;
        private readonly UserManager<ApplicationUser> userManager;

        public PostsController(IPostsService postService, ICategoriesService categoriesService, UserManager<ApplicationUser> userManager)
        {
            this.postService = postService;
            this.categoriesService = categoriesService;
            this.userManager = userManager;
        }

        public IActionResult ById(int id)
        {
            var postViewModel = this.postService.GetById<PostViewModel>(id);
            if (postViewModel == null)
            {
                return this.NotFound();
            }

            return this.View(postViewModel);
        }

        [Authorize]
        public IActionResult Create()
        {
            var categories = this.categoriesService.GetAll<CategoryDropDownViewModel>();
            var viewModel = new PostCreateInputModel
            {
                Categories = categories,
            };
            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(PostCreateInputModel input)
        {
            // EDIT
            // var post =
            // if(!this.User.IsInRole("Admin") && this.... != post.User)
            // {
            //    return this.Unauthorized();
            // }

            // var post = AutoMapperConfig.MapperInstance.Map<Post>(input);
            if (!this.ModelState.IsValid)
            {
                input.Categories = this.categoriesService.GetAll<CategoryDropDownViewModel>();
                return this.View(input);
            }

            var user = await this.userManager.GetUserAsync(this.User);
            var postDto = AutoMapperConfig.MapperInstance.Map<PostDto>(input);
            postDto.UserId = user.Id;
            var postId = await this.postService.CreateAsync(postDto);
            this.TempData["InfoMessage"] = "ForumPostCreated!";
            return this.RedirectToAction(nameof(this.ById), new { id = postId });
        }
    }
}
