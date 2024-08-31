using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class StudentsController : Controller
    {
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student student, HttpPostedFileBase imageFile)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var db = new School())
                    {
                        if (imageFile != null && imageFile.ContentLength > 0)
                        {
                            var fileName = Path.GetFileName(imageFile.FileName);
                            var path = Path.Combine(Server.MapPath("~/Images"), fileName);
                            imageFile.SaveAs(path);
                            student.Image = "/Images/" + fileName;
                        }

                        db.Students.Add(student);
                        db.SaveChanges();
                        TempData["SuccessMessage"] = "Record saved successfully.";
                        return View(student);
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View(student);
            }
            return View(student);
        }
    }
}