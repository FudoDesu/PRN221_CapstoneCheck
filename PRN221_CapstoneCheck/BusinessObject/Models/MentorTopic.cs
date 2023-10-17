using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class MentorTopic
    {
        public MentorTopic()
        {
            StudentGroups = new HashSet<StudentGroup>();
        }

        public int? MentorId { get; set; }
        public int? SubMentorId { get; set; }
        public int? TopicId { get; set; }
        public int Id { get; set; }

        public virtual Mentor? Mentor { get; set; }
        public virtual Mentor? SubMentor { get; set; }
        public virtual Topic? Topic { get; set; }
        public virtual ICollection<StudentGroup> StudentGroups { get; set; }
    }
}
