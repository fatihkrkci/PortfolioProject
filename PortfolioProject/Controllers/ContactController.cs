﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PortfolioProject.Controllers
{
    public class ContactController : Controller
    {
        public PartialViewResult PartialContactSidebar()
        {
            return PartialView();
        }
    }
}