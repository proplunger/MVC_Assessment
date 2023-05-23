using System.ComponentModel.DataAnnotations.Schema;

namespace AssessmentUser.Models
{
    public class Request
    {
        public int Id { get; set; }

        public User UserId { get; set; }

        public Batch BatchId { get; set; }
        
    }
}
