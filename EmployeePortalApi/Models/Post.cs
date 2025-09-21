using System;
using System.Collections.Generic;

namespace EmployeePortalApi.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }

        public ICollection<Comment> Comments { get; set; } = new List<Comment>(); // <-- Initialize
    }


}
