using System;
using System.Collections.Generic;

namespace StudentManagmentSystem.Models
{
    public partial class Course
    {
        public Course()
        {
            StudentRegs = new HashSet<StudentReg>();
        }

        public int CourseId { get; set; }
        public string? CourseName { get; set; }
        public decimal? CourseFees { get; set; }

        public virtual ICollection<StudentReg> StudentRegs { get; set; }
    }
}
