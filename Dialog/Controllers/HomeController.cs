using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Dialog.Models;

namespace Dialog.Controllers
{
    public class HomeController : Controller
    {
      [HttpGet("/")]
      public ActionResult Index()
      {
        return View();
      }

      [HttpGet("/thread")]
      public ActionResult Thread()
      {
        return View();
      }
    }
}
