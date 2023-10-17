using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Topic
    {
        public Topic()
        {
            MentorTopics = new HashSet<MentorTopic>();
        }

        public string? Name { get; set; }
        public int Id { get; set; }

        public virtual ICollection<MentorTopic> MentorTopics { get; set; }
    }
}
