using System.Collections.Generic;
using WebApiDemo.Common.Mapping;
using WebApiDemo.Data.Models;
using WebApiDemo.Models.ViewModels.Comments;

namespace WebApiDemo.Models.ViewModels.Articles
{
    public class ArticleDetailsViewModel : IMapFrom<Article>
    {
        public ArticleDetailsViewModel()
        {
            this.Comments = new HashSet<CommentArticleViewModel>();
        }

        public string Name { get; set; }

        public string Content { get; set; }

        public string AuthorId { get; set; }

        public string AuthorUsername { get; set; }

        public IEnumerable<CommentArticleViewModel> Comments { get; set; }
    }
}
