using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Controllers;
using WebApplication2.Models;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string searchString)
        {

            using (var db = new School())
            {
                var studentData = from student in db.Students
                                  join subject in db.Subjects on student.Class equals subject.Class
                                  join teacher in db.Teachers on subject.TeacherId equals teacher.Id
                                  select new StudentDetails
                                  {
                                      StudentId = student.Id,
                                      StudentName = student.Name,
                                      StudentClass = student.Class,
                                      StudentRoll = student.RollNumber,
                                      StudentAge = student.Age,
                                      StudentImage = student.Image,
                                      TeacherName = teacher.Name,
                                      StudentSubject = subject.Name,
                                      // Add other necessary fields here
                                  };
                if (!string.IsNullOrEmpty(searchString))
                {
                    studentData = studentData.Where(s => s.StudentName.Contains(searchString));
                }
                return View(studentData.ToList());
            }
        }
    }
}