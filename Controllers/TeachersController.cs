using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class TeachersController : Controller
    {
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Teacher teacher,  HttpPostedFileBase imageFile)
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
                            teacher.Image = "/Images/" + fileName;
                        }

                        db.Teachers.Add(teacher);
                        db.SaveChanges();
                        TempData["SuccessMessage"] = "Record saved successfully.";
                        return View(teacher);
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View(teacher);
            }

            return View(teacher);
        }
    }
}