using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class Semester
    {
        public Semester()
        {
            Students = new HashSet<Student>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }
        public int Year { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
