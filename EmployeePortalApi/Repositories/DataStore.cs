using EmployeePortalApi.Models;

namespace EmployeePortalApi.Repositories;

public static class DataStore
{
    public static List<User> Users { get; set; } = new()
    {
        new User { Id = 1, Username = "Admin", Role = "Admin" }
    };

    public static List<Post> Posts { get; set; } = new()
    {
        new Post { Id = 1, Title = "Welcome Post", Content = "Hello everyone!", Author = "Admin", Timestamp = DateTime.Now.AddMinutes(-10), Likes = 2, Dislikes = 0 }
    };

    public static List<Comment> Comments { get; set; } = new()
    {
        new Comment { Id = 1, PostId = 1, Author = "User1", Content = "Great post!", Timestamp = DateTime.Now.AddMinutes(-5) }
    };
}
