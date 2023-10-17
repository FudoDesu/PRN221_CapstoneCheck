using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class StudentGroup
    {
        public StudentGroup()
        {
            Students = new HashSet<Student>();
        }

        public int? NumberOfStudent { get; set; }
        public int? TopicId { get; set; }
        public int Id { get; set; }
        public int LeaderId { get; set; }

        public virtual MentorTopic? Topic { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
