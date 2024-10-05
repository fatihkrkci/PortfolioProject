using PortfolioProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProject.Controllers
{
    public class AboutController : Controller
    {
        DbMyPortfolioEntities context = new DbMyPortfolioEntities();

        public ActionResult Index()
        {
            var values = context.About.FirstOrDefault();

            return View(values);
        }

        [HttpPost]
        public ActionResult Index(About about)
        {
            var value = context.About.Find(about.AboutID);
            value.Title = about.Title;
            value.Description = about.Description;
            value.ImageUrl = about.ImageUrl;
            
            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}