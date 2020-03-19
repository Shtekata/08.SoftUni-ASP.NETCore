using WebApiDemo.Common.Mapping;
using WebApiDemo.Data.Models;

namespace WebApiDemo.Models.ViewModels.Articles
{
    public class ArticleCreateViewModel : IMapFrom<Article>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Content { get; set; }

        public string AuthorId { get; set; }

        public string AuthorUsername { get; set; }
    }
}
