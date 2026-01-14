

namespace FakeForum.Models
{
    public class FThread
    {
        public int ThreadId { get; set; }

        public string Title { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }

        public int UserId { get; set; }
            
        public string Body { get; set; } = string.Empty;

        public ICollection<Post> Posts { get; set; } = [];
        public AppUser? User { get; set; }




}
}
