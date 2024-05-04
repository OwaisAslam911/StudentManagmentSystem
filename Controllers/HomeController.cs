using Microsoft.AspNetCore.Mvc;
using StudentManagmentSystem.Models;
using System.Diagnostics;

namespace StudentManagmentSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly SMSContext db;

        public HomeController(SMSContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
          var show=  db.StudentRegViewMode.ToList();
            return View(show);
        }
        [HttpGet]
        public IActionResult Form()
        {
            StudentRegViewMode UserData = new StudentRegViewMode()
            {
                StudentRegForm = new StudentReg(),
                CourseList = db.Courses.ToList()
            };
            
            return View(UserData);
        }
        [HttpPost]
        public IActionResult Form(StudentRegViewMode stdData)
        {
            var std =  stdData;
            StudentReg newstd = new StudentReg()
            {
               StudentName=  stdData.StudentRegForm.StudentName,
               StudentEmail= stdData.StudentRegForm.StudentEmail,
               StartDate= stdData.StudentRegForm.StartDate,
               CourseId= stdData.StudentRegForm.CourseId 
            };
            db.Add(newstd);
            db.SaveChanges();
            return RedirectToAction("Index");
            
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}