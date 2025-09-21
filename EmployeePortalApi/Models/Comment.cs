using System;

namespace EmployeePortalApi.Models
{
    using System.Text.Json.Serialization;

    public class Comment
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public string Author { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; }

        [JsonIgnore]   // <- prevents circular reference
        public Post? Post { get; set; }
    }

}
