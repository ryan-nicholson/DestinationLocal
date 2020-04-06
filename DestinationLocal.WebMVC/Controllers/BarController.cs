using DestinationLocal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DestinationLocal.WebMVC.Controllers
{
    [Authorize]
    public class BarController : Controller
    {
        // GET: Hotel
        public ActionResult Index()
        {
            var model = new BarListItem[0];
            return View(model);
        }
        //Get
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BarCreate model)
        {
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }
    }
}