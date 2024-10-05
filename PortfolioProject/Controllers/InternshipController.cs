using PortfolioProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProject.Controllers
{
    public class InternshipController : Controller
    {
        DbMyPortfolioEntities context = new DbMyPortfolioEntities();

        public ActionResult InternshipList()
        {
            var values = context.Internship.ToList();

            return View(values);
        }

        [HttpGet]
        public ActionResult CreateInternship()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateInternship(Internship internship)
        {
            context.Internship.Add(internship);
            context.SaveChanges();

            return RedirectToAction("InternshipList");
        }

        public ActionResult DeleteInternship(int id)
        {
            var value = context.Internship.Find(id);
            context.Internship.Remove(value);
            context.SaveChanges();

            return RedirectToAction("InternshipList");
        }

        [HttpGet]
        public ActionResult UpdateInternship(int id)
        {
            var value = context.Internship.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateInternship(Internship internship)
        {
            var value = context.Internship.Find(internship.InternshipID);

            value.CompanyName = internship.CompanyName;
            value.StartDate = internship.StartDate;
            value.EndDate = internship.EndDate;
            value.Position = internship.Position;
            value.Description = internship.Description;
            value.SupervisorName = internship.SupervisorName;
            value.SupervisorEmail = internship.SupervisorEmail;
            context.SaveChanges();

            return RedirectToAction("InternshipList");
        }
    }
}