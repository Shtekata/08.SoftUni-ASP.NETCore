namespace ForumSystem.Services.Data
{
    using ForumSystem.Web.ViewModels.Posts;
    using System.Threading.Tasks;

    public interface IPostsService
    {
        Task<int> CreateAsync(PostDto dto);

        T GetById<T>(int id);
    }
}
