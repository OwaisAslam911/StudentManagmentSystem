using System;
using System.Collections.Generic;

namespace StudentManagmentSystem.Models
{
    public partial class StudentReg
    {
        public int StudentId { get; set; }
        public string? StudentName { get; set; }
        public string? StudentEmail { get; set; }
        public DateTime? StartDate { get; set; }
        public int? CourseId { get; set; }

        public virtual Course? Course { get; set; }
    }
}
