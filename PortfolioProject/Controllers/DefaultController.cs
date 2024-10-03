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
            return View();
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
    }
}