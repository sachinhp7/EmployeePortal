using EmployeePortalApi.Data;
using EmployeePortalApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class CommentsController : ControllerBase
{
    private readonly EmployeePortalContext _context;
    public CommentsController(EmployeePortalContext context) => _context = context;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Comment>>> GetComments(int postId)
    {
        return await _context.Comments
            .Where(c => c.PostId == postId)
            .ToListAsync();
    }

   [HttpPost]
public async Task<ActionResult<Comment>> AddComment([FromBody] Comment comment)
{
    if (string.IsNullOrEmpty(comment.Author) || string.IsNullOrEmpty(comment.Content))
        return BadRequest("Author and Content are required.");

    comment.Timestamp = DateTime.UtcNow;
    _context.Comments.Add(comment);
    await _context.SaveChangesAsync();

    return CreatedAtAction(nameof(GetComments), new { postId = comment.PostId }, comment);
}

}
