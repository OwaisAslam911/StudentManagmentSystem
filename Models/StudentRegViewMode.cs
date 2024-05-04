namespace StudentManagmentSystem.Models
{
    public class StudentRegViewMode
    {
        public StudentReg StudentRegForm { get; set; }

        public IEnumerable<Course> CourseList { get; set; }
    }
}
