﻿using PagedList;
using PagedList.Mvc;
using PortfolioProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProject.Controllers
{
    public class SkillController : Controller
    {
        DbMyPortfolioEntities context = new DbMyPortfolioEntities();

        public ActionResult SkillList(int page = 1)
        {
            var values = context.Skill.ToList().ToPagedList(page, 5);
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateSkill()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateSkill(Skill skill)
        {
            skill.Status = true;
            context.Skill.Add(skill);
            context.SaveChanges();
            return RedirectToAction("SkillList");
        }

        public ActionResult DeleteSkill(int id)
        {
            var value = context.Skill.Find(id);
            context.Skill.Remove(value);
            context.SaveChanges();
            return RedirectToAction("SkillList");
        }

        [HttpGet]
        public ActionResult UpdateSkill(int id)
        {
            var value = context.Skill.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateSkill(Skill skill)
        {
            var existValue = context.Skill.Find(skill.SkillID);
            existValue.SkillName = skill.SkillName;
            existValue.Rate = skill.Rate;
            existValue.Icon = skill.Icon;

            context.SaveChanges();
            
            return RedirectToAction("SkillList");
        }
    }
}