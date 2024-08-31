using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class SubjectsController : Controller
    {
        private readonly School db = new School();

        public ActionResult Create()
        {
            try
            {
                ViewBag.TeacherId = new SelectList(db.Teachers, "Id", "Name");
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Subject subject)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Subjects.Add(subject);
                    db.SaveChanges();
                    TempData["SuccessMessage"] = "Record saved successfully.";

                    // Clear the form after successful save
                    ModelState.Clear();
                    subject = new Subject();

                    // Repopulate the dropdown list
                    ViewBag.TeacherId = new SelectList(db.Teachers, "Id", "Name");
                    return View(subject);
                }

                // Repopulate the dropdown list in case of an error
                ViewBag.TeacherId = new SelectList(db.Teachers, "Id", "Name", subject.TeacherId);
                return View(subject);
            }
            catch (Exception ex)
            {
                // Repopulate the dropdown list in case of an error
                ViewBag.TeacherId = new SelectList(db.Teachers, "Id", "Name", subject.TeacherId);
                ViewBag.ErrorMessage = ex.Message;
                return View(subject);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
