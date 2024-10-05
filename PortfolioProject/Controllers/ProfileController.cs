using PortfolioProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProject.Controllers
{
    public class ProfileController : Controller
    {
        DbMyPortfolioEntities context = new DbMyPortfolioEntities();

        public ActionResult Index()
        {
            var values = context.Profile.FirstOrDefault();

            return View(values);
        }

        [HttpPost]
        public ActionResult Index(Profile profile)
        {
            var value = context.Profile.Find(profile.ProfileID);

            value.BirthDate = profile.BirthDate;
            value.Email = profile.Email;
            value.Phone = profile.Phone;
            value.Github = profile.Github;
            value.Address = profile.Address;
            value.Title = profile.Title;
            value.ImageUrl = profile.ImageUrl;
            value.Description = profile.Description;

            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}