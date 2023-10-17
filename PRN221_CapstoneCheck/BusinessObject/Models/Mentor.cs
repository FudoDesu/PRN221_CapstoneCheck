using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Mentor
    {
        public Mentor()
        {
            MentorTopicMentors = new HashSet<MentorTopic>();
            MentorTopicSubMentors = new HashSet<MentorTopic>();
        }

        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public int Id { get; set; }

        public virtual ICollection<MentorTopic> MentorTopicMentors { get; set; }
        public virtual ICollection<MentorTopic> MentorTopicSubMentors { get; set; }
    }
}
