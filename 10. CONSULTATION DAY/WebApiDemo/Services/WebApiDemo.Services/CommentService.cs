namespace WebApiDemo.Services
{
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using WebApiDemo.Common.Mapping;
    using WebApiDemo.Data.Common.Repositories;
    using WebApiDemo.Data.Models;
    using WebApiDemo.Models.InputModels.Coments;

    public class CommentService : ICommentService
    {
        private readonly IDeletableEntityRepository<Comment> commentRepository;
        private readonly IDeletableEntityRepository<Article> articleRepository;

        public CommentService(IDeletableEntityRepository<Comment> commentRepository, IDeletableEntityRepository<Article> articleRepository)
        {
            this.commentRepository = commentRepository;
            this.articleRepository = articleRepository;
        }

        public async Task<T> CreateAsynk<T>(CommentCreateInputModel model, string userId, int articleId)
        {
            // var articleId = this.articleRepository
            //    .AllAsNoTracking()
            //    .Where(x => x.Name == model.ArticleName)
            //    .Where(x => x.Id == model.ArticleId)
            //    .Select(x => x.Id)
            //    .FirstOrDefault();
            var comment = new Comment
            {
                Content = model.Content,
                ArticleId = articleId,
                AuthorId = userId,
            };

            this.commentRepository.Add(comment);
            await this.commentRepository.SaveChangesAsync();

            var createdComment = await this.commentRepository
                .AllAsNoTracking()
                .Where(x => x.Id == comment.Id)
                .To<T>()
                .SingleAsync();

            return createdComment;
        }

        public async Task<T> CreateAsynk<T>(CommentCreateInputModel model, string userId, string articleName)
        {
            var articleId = this.articleRepository
               .AllAsNoTracking()
               .Where(x => x.Name == articleName)
               .Select(x => x.Id)
               .FirstOrDefault();

            var comment = new Comment
            {
                Content = model.Content,
                ArticleId = articleId,
                AuthorId = userId,
            };

            this.commentRepository.Add(comment);
            await this.commentRepository.SaveChangesAsync();

            var createdComment = await this.commentRepository
                .AllAsNoTracking()
                .Where(x => x.Id == comment.Id)
                .To<T>()
                .SingleAsync();

            return createdComment;
        }
    }
}
