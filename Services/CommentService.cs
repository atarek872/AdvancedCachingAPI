using AdvancedCachingExample.Data;
using AdvancedCachingExample.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace AdvancedCachingExample.Services
{
    public class CommentService
    {
        private readonly IMemoryCache _cache;
        private readonly ApplicationDbContext _context;
        private readonly ILogger<CommentService> _logger;

        public CommentService(IMemoryCache cache, ApplicationDbContext context, ILogger<CommentService> logger)
        {
            _cache = cache;
            _context = context;
            _logger = logger;
        }
 
        public async Task<List<Comment>> GetCommentsAsync(int examResultId)
        {
            var cacheKey = $"exam_result_{examResultId}_comments";

            if (!_cache.TryGetValue(cacheKey, out List<Comment> comments))
            {
                _logger.LogInformation($"Cache miss for exam result {examResultId} comments, fetching from database.");
                comments = await _context.Comments
                    .Where(c => c.ExamResultId == examResultId)
                    .ToListAsync();

                if (comments != null)
                {
 
                    _cache.Set(cacheKey, comments, TimeSpan.FromMinutes(10));
                }
            }
            else
            {
                _logger.LogInformation($"Cache hit for exam result {examResultId} comments.");
            }

            return comments;
        }
 
        public async Task AddCommentAsync(int examResultId, Comment comment)
        {
            comment.ExamResultId = examResultId;
            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();

 
            _cache.Remove($"exam_result_{examResultId}_comments");

            _logger.LogInformation($"Added comment for exam result {examResultId}.");
        }
    }
}
