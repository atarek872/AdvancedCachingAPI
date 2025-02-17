using AdvancedCachingExample.Data;
using AdvancedCachingExample.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace AdvancedCachingExample.Services
{
    public class ExamService
    {
        private readonly IMemoryCache _cache;
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ExamService> _logger;

        public ExamService(IMemoryCache cache, ApplicationDbContext context, ILogger<ExamService> logger)
        {
            _cache = cache;
            _context = context;
            _logger = logger;
        }
 
        public async Task<ExamResult> GetExamResultAsync(int studentId)
        {
            var cacheKey = $"student_{studentId}_exam_result";

            if (!_cache.TryGetValue(cacheKey, out ExamResult result))
            {
                _logger.LogInformation($"Cache miss for student {studentId} exam result, fetching from database.");
                result = await _context.ExamResults
                    .Include(e => e.Comments)
                    .FirstOrDefaultAsync(e => e.StudentId == studentId);

                if (result != null)
                {
                    _cache.Set(cacheKey, result, TimeSpan.FromMinutes(10));
                }
            }
            else
            {
                _logger.LogInformation($"Cache hit for student {studentId} exam result.");
            }

            return result;
        }

         public async Task AddExamResultAsync(int studentId, ExamResult result)
        {
            result.StudentId = studentId;
            _context.ExamResults.Add(result);
            await _context.SaveChangesAsync();

            _cache.Remove($"student_{studentId}_exam_result");

            _logger.LogInformation($"Added exam result for student {studentId}.");
        }
    }

}
