using AdvancedCachingExample.Models;
using AdvancedCachingExample.Services;
using Microsoft.AspNetCore.Mvc;

namespace AdvancedCachingExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamResultsController : ControllerBase
    {
        private readonly ExamService _examService;
        private readonly CommentService _commentService;

        public ExamResultsController(ExamService examService, CommentService commentService)
        {
            _examService = examService;
            _commentService = commentService;
        }
 
        [HttpGet("result/{studentId}")]
        public async Task<ActionResult<ExamResult>> GetExamResult(int studentId)
        {
            var result = await _examService.GetExamResultAsync(studentId);
            if (result == null)
            {
                return NotFound("Exam result not found.");
            }
            return Ok(result);
        }

 
        [HttpPost("result/{studentId}")]
        public async Task<IActionResult> AddExamResult(int studentId, [FromBody] ExamResult result)
        {
            await _examService.AddExamResultAsync(studentId, result);
            return CreatedAtAction(nameof(GetExamResult), new { studentId = studentId }, result);
        }
 
        [HttpGet("comments/{examResultId}")]
        public async Task<ActionResult<List<Comment>>> GetComments(int examResultId)
        {
            var comments = await _commentService.GetCommentsAsync(examResultId);
            if (comments == null)
            {
                return NotFound("No comments found for this exam result.");
            }
            return Ok(comments);
        }

 
        [HttpPost("comments/{examResultId}")]
        public async Task<IActionResult> AddComment(int examResultId, [FromBody] Comment comment)
        {
            await _commentService.AddCommentAsync(examResultId, comment);
            return Ok(comment);
        }
    }
}
