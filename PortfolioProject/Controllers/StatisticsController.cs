using PortfolioProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProject.Controllers
{
    public class StatisticsController : Controller
    {
        DbMyPortfolioEntities context = new DbMyPortfolioEntities();
        public ActionResult Index()
        {
            ViewBag.totalMessageCount = context.Contact.Count();
            ViewBag.messageIsReadTrueCount = context.Contact.Where(x => x.IsRead == true).Count();
            ViewBag.messageIsReadFalseCount = context.Contact.Where(y => y.IsRead == false).Count();
            ViewBag.skillCount = context.Skill.Count();
            ViewBag.skillRateSum = context.Skill.Sum(x => x.Rate);
            ViewBag.skillRateAvg = context.Skill.Average(x => x.Rate);

            var maxRate = context.Skill.Max(x => x.Rate);
            ViewBag.maxRateSkillName = context.Skill.Where(x => x.Rate == maxRate).Select(y => y.SkillName).FirstOrDefault();
            
            ViewBag.getMessageCountBySubjectReferances = context.Contact.Where(x => x.Subject == "Referans").Count();
            //ViewBag.senderOfReferenceMessage = context.Contact.Where(x => x.Subject == "Referans").Select(y => y.NameSurname).FirstOrDefault();

            ViewBag.getMessageCountByEmailContainHAndIsReadTrue = context.Contact.Where(x => x.IsRead == true && x.Email.Contains("h")).Count();

            ViewBag.getSkillNameByRate90 = context.Skill.Where(x => x.Rate == 90).Select(y => y.SkillName).FirstOrDefault();

            return View();
        }
    }
}