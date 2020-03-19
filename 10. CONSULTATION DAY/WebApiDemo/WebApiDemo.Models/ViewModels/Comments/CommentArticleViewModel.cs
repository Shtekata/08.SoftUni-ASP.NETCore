using WebApiDemo.Common.Mapping;
using WebApiDemo.Data.Models;

namespace WebApiDemo.Models.ViewModels.Comments
{
    public class CommentArticleViewModel : IMapFrom<Comment>
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public string AuthorId { get; set; }

        public string AuthorUsername { get; set; }
    }
}
