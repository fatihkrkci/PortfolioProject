using PortfolioProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProject.Controllers
{
    public class TestimonialController : Controller
    {
        DbMyPortfolioEntities context = new DbMyPortfolioEntities();

        public ActionResult TestimonialList()
        {
            var values = context.Testimonial.ToList();

            return View(values);
        }

        [HttpGet]
        public ActionResult CreateTestimonial()
        {
            List<SelectListItem> values = (from x in context.Portfolio.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.Title,
                                               Value = x.PortfolioID.ToString()
                                           }).ToList();
            ViewBag.PortfolioList = values;

            return View();
        }

        [HttpPost]
        public ActionResult CreateTestimonial(Testimonial testimonial)
        {
            context.Testimonial.Add(testimonial);
            context.SaveChanges();

            return RedirectToAction("TestimonialList");
        }

        public ActionResult DeleteTestimonial(int id)
        {
            var value = context.Testimonial.Find(id);
            context.Testimonial.Remove(value);
            context.SaveChanges();

            return RedirectToAction("TestimonialList");
        }

        [HttpGet]
        public ActionResult UpdateTestimonial(int id)
        {
            var value = context.Testimonial.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateTestimonial(Testimonial testimonial)
        {
            var value = context.Testimonial.Find(testimonial.TestimonialID);

            value.NameSurname = testimonial.NameSurname;
            value.Comment = testimonial.Comment;
            value.Star = testimonial.Star;
            value.PortfolioID = testimonial.PortfolioID;

            context.SaveChanges();

            return RedirectToAction("TestimonialList");
        }
    }
}