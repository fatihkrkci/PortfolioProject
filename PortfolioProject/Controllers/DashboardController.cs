using PortfolioProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProject.Controllers
{
    public class DashboardController : Controller
    {
        DbMyPortfolioEntities context = new DbMyPortfolioEntities();

        public ActionResult Index()
        {
            ViewBag.EducationCount = context.Education.Count();
            ViewBag.SkillCount = context.Skill.Count();
            ViewBag.ExperienceCount = context.Experience.Count();
            ViewBag.ServiceCount = context.Service.Count();
            ViewBag.SocialMediaCount = context.SocialMedia.Count();
            ViewBag.MessageCount = context.Contact.Count();

            return View();
        }
    }
}