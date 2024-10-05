using PortfolioProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProject.Controllers
{
    public class DefaultController : Controller
    {
        DbMyPortfolioEntities context = new DbMyPortfolioEntities();

        public ActionResult Index()
        {
            List<SelectListItem> values = (from x in context.Category.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryID.ToString()
                                           }).ToList();
            ViewBag.Categories = values;

            return View();
        }

        [HttpPost]
        public ActionResult Index(Contact contact)
        {
            contact.SendDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            contact.IsRead = false;

            context.Contact.Add(contact);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        public PartialViewResult PartialHead()
        {
            return PartialView();
        }

        public PartialViewResult PartialScripts()
        {
            return PartialView();
        }

        public PartialViewResult PartialNavbar()
        {
            return PartialView();
        }

        public PartialViewResult PartialHeader()
        {
            ViewBag.Title = context.Profile.Select(x => x.Title).FirstOrDefault();
            ViewBag.Description = context.Profile.Select(x => x.Description).FirstOrDefault();
            ViewBag.Address= context.Profile.Select(x => x.Address).FirstOrDefault();
            ViewBag.Email= context.Profile.Select(x => x.Email).FirstOrDefault();
            ViewBag.Phone= context.Profile.Select(x => x.Phone).FirstOrDefault();
            ViewBag.Github= context.Profile.Select(x => x.Github).FirstOrDefault();
            ViewBag.ImageUrl= context.Profile.Select(x => x.ImageUrl).FirstOrDefault();

            return PartialView();
        }

        public PartialViewResult PartialAbout()
        {
            var values = context.About.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialExperience()
        {
            var values = context.Experience.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialSkill()
        {
            var values = context.Skill.Where(x => x.Status == true).ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialFooter()
        {
            return PartialView();
        }

        public PartialViewResult PartialEducation()
        {
            var values = context.Education.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialService()
        {
            var values = context.Service.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialPortfolio()
        {
            var values = context.Portfolio.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialTestimonial()
        {
            var values = context.Testimonial.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialInternship()
        {
            var values = context.Internship.ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialSocialMediaHeader()
        {
            var values = context.SocialMedia.Where(x => x.Status == true).ToList();
            return PartialView(values);
        }

        public PartialViewResult PartialSocialMediaFooter()
        {
            var values = context.SocialMedia.Where(x => x.Status == true).ToList();
            return PartialView(values);
        }
    }
}