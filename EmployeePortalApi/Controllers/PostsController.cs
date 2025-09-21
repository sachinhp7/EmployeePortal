using EmployeePortalApi.Data;
using EmployeePortalApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeePortalApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostsController : ControllerBase
    {
        private readonly EmployeePortalContext _context;

        public PostsController(EmployeePortalContext context)
        {
            _context = context;
        }

        // GET api/posts?author=John&sort=recent
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Post>>> GetPosts(string? author, string? sort)
        {
            var query = _context.Posts.Include(p => p.Comments).AsQueryable();

            if (!string.IsNullOrEmpty(author))
                query = query.Where(p => p.Author == author);

            query = sort == "likes" ? query.OrderByDescending(p => p.Likes) : query.OrderByDescending(p => p.Timestamp);

            var posts = await query.ToListAsync();
            return posts;
        }


        // POST api/posts
        [HttpPost]
        public async Task<ActionResult<Post>> CreatePost(Post post)
        {
            post.Timestamp = DateTime.Now;
            post.Likes = 0;
            post.Dislikes = 0;

            _context.Posts.Add(post);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPosts), new { id = post.Id }, post);
        }

        // PUT api/posts/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePost(int id, Post updatedPost)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post == null) return NotFound();

            // Ownership check (replace with auth user)
            string currentUser = "admin";
            if (post.Author != currentUser)
                return Forbid("You can only update your own posts.");

            post.Title = updatedPost.Title;
            post.Content = updatedPost.Content;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE api/posts/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post == null) return NotFound();

            string currentUser = "admin"; // Replace with auth user
            if (post.Author != currentUser /* && currentUserRole != "Admin" */)
                return Forbid("You can only delete your own posts.");

            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST api/posts/{id}/like
        [HttpPost("{id}/like")]
        public async Task<IActionResult> LikePost(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post == null) return NotFound();

            post.Likes += 1;
            await _context.SaveChangesAsync();

            return Ok(post);
        }

        // POST api/posts/{id}/dislike
        [HttpPost("{id}/dislike")]
        public async Task<IActionResult> DislikePost(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post == null) return NotFound();

            post.Dislikes += 1;
            await _context.SaveChangesAsync();

            return Ok(post);
        }
    }
}
