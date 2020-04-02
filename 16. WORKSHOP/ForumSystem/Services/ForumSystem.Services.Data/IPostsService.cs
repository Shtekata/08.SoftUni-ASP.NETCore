namespace ForumSystem.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using ForumSystem.Web.ViewModels.Posts;

    public interface IPostsService
    {
        Task<int> CreateAsync(PostDto dto);

        T GetById<T>(int id);

        IEnumerable<T> GetByCategoryId<T>(int categoryId, int? take = null, int skip = 0);

        int GetCountByCategoryId(int categoryId);
    }
}
