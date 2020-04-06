using DestinationLocal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DestinationLocal.WebMVC.Controllers
{
    [Authorize]
    public class HotelController : Controller
    {
        // GET: Hotel
        public ActionResult Index()
        {
            var model = new HotelListItem[0];
            return View(model);
        }
        //Get
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HotelCreate model)
        {
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }
    }
}