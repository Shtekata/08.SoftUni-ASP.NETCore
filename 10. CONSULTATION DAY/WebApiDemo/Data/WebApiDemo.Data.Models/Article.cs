namespace WebApiDemo.Data.Models
{
    using System.Collections.Generic;

    using WebApiDemo.Data.Common.Models;

    public class Article : BaseDeletableModel<int>
    {
        public Article()
        {
            this.Comments = new HashSet<Comment>();
        }

        public string Name { get; set; }

        public string Content { get; set; }

        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public virtual IEnumerable<Comment> Comments { get; set; }
    }
}
