namespace FakeForum.Models
{
    public class Post
    {
        public int Id { get; set; }
        
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public int ThreadId { get; set; }

        public int UserId { get; set; }

        public int Likes { get; set; } = 0;

        public FThread? Thread { get; set; }
        public AppUser? User { get; set; }

    }
}
