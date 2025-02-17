namespace AdvancedCachingExample.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ExamResult> ExamResults { get; set; }
    }
}
