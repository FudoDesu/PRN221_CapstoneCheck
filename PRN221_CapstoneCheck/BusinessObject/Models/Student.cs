using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Student
    {
        public Student()
        {
            StudentSubjects = new HashSet<StudentSubject>();
        }

        public string? Name { get; set; }
        public string? Email { get; set; }
        public int? SemesterId { get; set; }
        public string? Password { get; set; }
        public int? Status { get; set; }
        public int Id { get; set; }
        public int? GroupId { get; set; }

        public virtual StudentGroup? Group { get; set; }
        public virtual Semester? Semester { get; set; }
        public virtual ICollection<StudentSubject> StudentSubjects { get; set; }
    }
}
