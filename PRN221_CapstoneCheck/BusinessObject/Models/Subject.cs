using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Subject
    {
        public Subject()
        {
            StudentSubjects = new HashSet<StudentSubject>();
        }

        public string? Name { get; set; }
        public int Id { get; set; }
        public int IsPrerequisite { get; set; }

        public virtual ICollection<StudentSubject> StudentSubjects { get; set; }
    }
}
