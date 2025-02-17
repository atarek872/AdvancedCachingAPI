namespace AdvancedCachingExample.Models
{
    public class ExamResult
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string Subject { get; set; }
        public double Grade { get; set; }
        public DateTime Date { get; set; }
        public Student Student { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
