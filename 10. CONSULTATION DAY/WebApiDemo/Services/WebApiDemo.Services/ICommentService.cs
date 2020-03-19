namespace WebApiDemo.Services
{
    using System.Threading.Tasks;

    using WebApiDemo.Models.InputModels.Coments;

    public interface ICommentService
    {
        Task<T> CreateAsynk<T>(CommentCreateInputModel model, string userId, int articleId);

        Task<T> CreateAsynk<T>(CommentCreateInputModel model, string userId, string articleName);
    }
}
