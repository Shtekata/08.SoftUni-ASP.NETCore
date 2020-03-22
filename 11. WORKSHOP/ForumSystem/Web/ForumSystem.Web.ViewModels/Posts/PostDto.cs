namespace ForumSystem.Web.ViewModels.Posts
{
    using ForumSystem.Services.Mapping;

    public class PostDto : IMapFrom<PostCreateInputModel>
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public int CategoryId { get; set; }

        public string UserId { get; set; }
    }
}
