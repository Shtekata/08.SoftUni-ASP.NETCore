namespace WebApiDemo.Web.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using WebApiDemo.Models.InputModels.Coments;
    using WebApiDemo.Models.ViewModels.Comments;
    using WebApiDemo.Services;
    using WebApiDemo.Web.Infrastructure.Extensions;

    public class CommentsController : BaseController
    {
        private readonly ICommentService commentService;

        public CommentsController(ICommentService commentService)
        {
            this.commentService = commentService;
        }

        [HttpPost]
        [Route("/api/articles/{articleId}/[controller]")]
        public async Task<IActionResult> Create(int articleId, CommentCreateInputModel input)
        {
            var userId = this.User.GetId();
            var createdComment = await this.commentService.CreateAsynk<CommentCreateViewModel>(input, userId, articleId);

            return this.Created($"comments/{createdComment.Id}", createdComment);
        }

        // [HttpPost]
        // [Route("/api/articles/{articleName}/[controller]")]
        // public async Task<IActionResult> Create(string articleName, CommentCreateInputModel input)
        // {
        //    var userId = this.User.GetId();
        //    var createdComment = await this.commentService.CreateAsynk<CommentCreateViewModel>(input, userId, articleName);

        // return this.Created($"comments/{createdComment.Id}", createdComment);
        // }
    }
}
