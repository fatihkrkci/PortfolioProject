﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProject.Controllers
{
    public class CategoryController : Controller
    {
        public ActionResult CategoryList()
        {
            return View();
        }

        public ActionResult CreateCategory()
        {
            return View();
        }
    }
}