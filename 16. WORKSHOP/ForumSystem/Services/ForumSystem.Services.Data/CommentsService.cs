namespace ForumSystem.Services.Data
{
    using System.Linq;
    using System.Threading.Tasks;

    using ForumSystem.Data.Common.Repositories;
    using ForumSystem.Data.Models;

    public class CommentsService : ICommentsService
    {
        private readonly IDeletableEntityRepository<Comment> commentsReposytory;

        public CommentsService(IDeletableEntityRepository<Comment> commentsReposytory)
        {
            this.commentsReposytory = commentsReposytory;
        }

        public async Task Create(int postId, string userId, string content, int? parentId = null)
        {
            var comment = new Comment
            {
                PostId = postId,
                UserId = userId,
                Content = content,
                ParentId = parentId,
            };
            await this.commentsReposytory.AddAsync(comment);
            await this.commentsReposytory.SaveChangesAsync();
        }

        public bool IsInPostId(int commentId, int postId)
        {
            var commentPostId = this.commentsReposytory.All()
                .Where(x => x.Id == commentId)
                .Select(x => x.PostId).FirstOrDefault();

            return commentPostId == postId;
        }
    }
}
