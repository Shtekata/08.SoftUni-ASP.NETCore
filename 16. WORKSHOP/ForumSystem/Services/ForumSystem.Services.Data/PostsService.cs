namespace ForumSystem.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using ForumSystem.Data.Common.Repositories;
    using ForumSystem.Data.Models;
    using ForumSystem.Services.Mapping;
    using ForumSystem.Web.ViewModels.Posts;
    using Microsoft.EntityFrameworkCore;

    public class PostsService : IPostsService
    {
        private readonly IDeletableEntityRepository<Post> postRepository;

        public PostsService(IDeletableEntityRepository<Post> postRepository)
        {
            this.postRepository = postRepository;
        }

        public async Task<int> CreateAsync(PostDto dto)
        {
            var post = new Post
            {
                CategoryId = dto.CategoryId,
                Content = dto.Content,
                Title = dto.Title,
                UserId = dto.UserId,
            };

            await this.postRepository.AddAsync(post);
            await this.postRepository.SaveChangesAsync();
            return post.Id;
        }

        public IEnumerable<T> GetByCategoryId<T>(int categoryId, int? take = null, int skip = 0)
        {
            var query = this.postRepository.All()
                .OrderByDescending(x => x.CreatedOn)
                .Where(x => x.CategoryId == categoryId)
                .Skip(skip);
            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }

            return query.To<T>().ToList();
        }

        public T GetById<T>(int id)
        {
            var post = this.postRepository.All()
                .Where(x => x.Id == id)

                // .AsQueryable()
                .To<T>()
                .FirstOrDefault();
            return post;
        }

        public int GetCountByCategoryId(int categoryId)
        {
            return this.postRepository.All()
                .Count(x => x.CategoryId == categoryId);
        }
    }
}
