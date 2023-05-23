namespace AssessmentUser.Models
{
    public class Batch
    {
        public int BatchId { get; set; }
        public string BatchName { get; set; }
        public string Trainer { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Now;
        public int CourseId { get; set; }

        // Navigation property for Course
        public Course Course { get; set; }
    }
}
