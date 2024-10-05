using PortfolioProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProject.Controllers
{
    public class MessageController : Controller
    {
        DbMyPortfolioEntities context = new DbMyPortfolioEntities();

        public ActionResult Inbox()
        {
            var values = context.Contact.ToList();
            return View(values);
        }

        public ActionResult ChangeMessageStatusToTrue(int id)
        {
            var value = context.Contact.Find(id);
            value.IsRead = true;
            context.SaveChanges();
            return RedirectToAction("Inbox");
        }

        public ActionResult ChangeMessageStatusToFalse(int id)
        {
            var value = context.Contact.Find(id);
            value.IsRead = false;
            context.SaveChanges();
            return RedirectToAction("Inbox");
        }

        public ActionResult DeleteMessage(int id)
        {
            var value = context.Contact.Find(id);
            context.Contact.Remove(value);
            context.SaveChanges();

            return RedirectToAction("Inbox");
        }

        public ActionResult MessageDetail(int id)
        {
            var value = context.Contact.Find(id);

            if (value.IsRead == false)
            {
                value.IsRead = true;
            }

            context.SaveChanges();

            return View(value);
        }
    }
}