﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_application.Controllers
{
    public class ErrorsController : Controller
    {
        public ActionResult NotFound()
        {
            Response.StatusCode = 404;
            return View();
        }


        public ActionResult InternalServerError()
        {
            Response.StatusCode = 500;
            return View();
        }
    }
}