namespace Prosigliere.Challenge.Domain.Posts.GetPostById
{
    public class GetPostByIdResult
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public IList<GetPostByIdCommentResult> Comments { get; set; }
    }
}
