using WebApiDemo.Common.Mapping;
using WebApiDemo.Data.Models;

namespace WebApiDemo.Models.ViewModels.Comments
{
    public class CommentCreateViewModel : IMapFrom<Comment>
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public int ArticleId { get; set; }

        public string ArticleName { get; set; }

        public string AuthorUserName { get; set; }
    }
}
