namespace AdvancedCachingExample.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int ExamResultId { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public ExamResult ExamResult { get; set; }
    }
}
