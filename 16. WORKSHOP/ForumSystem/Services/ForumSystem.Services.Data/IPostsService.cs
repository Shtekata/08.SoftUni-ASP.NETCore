namespace ForumSystem.Services.Data
{
    using System.Threading.Tasks;

    using ForumSystem.Web.ViewModels.Posts;

    public interface IPostsService
    {
        Task<int> CreateAsync(PostDto dto);

        T GetById<T>(int id);
    }
}
