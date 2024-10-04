using PortfolioProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProject.Controllers
{
    public class ContactController : Controller
    {
        DbMyPortfolioEntities context = new DbMyPortfolioEntities();

        public PartialViewResult PartialContactSidebar()
        {
            return PartialView();
        }

        public PartialViewResult PartialContactDetail()
        {
            ViewBag.Address = context.Profile.Select(x => x.Address).FirstOrDefault();
            ViewBag.Description = context.Profile.Select(x => x.Description).FirstOrDefault();
            ViewBag.Phone = context.Profile.Select(x => x.Phone).FirstOrDefault();
            ViewBag.Email = context.Profile.Select(x => x.Email).FirstOrDefault();

            return PartialView();
        }

        public PartialViewResult PartialContactLocation()
        {
            return PartialView();
        }
    }
}