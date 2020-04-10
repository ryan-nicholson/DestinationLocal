using DestinationLocal.Models;
using DestinationLocal.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DestinationLocal.WebMVC.Controllers
{
    public class DestinationController : Controller
    {
        // GET: Destination
        public async Task<ActionResult> Index()
        {
            var service = GetDestinationService();
            return View(await service.GetAllDestinationsAsync());
        }
        

        //GET: Destination Create
        public ActionResult Create()
        {
            return View();
        }

        //POST: Destination Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(DestinationCreate model)
        {
            if (ModelState.IsValid)
            {
                var service = GetDestinationService();
                if (await service.CreateDestinationAsync(model))
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(model);
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult> Rate(int id)
        {
            var service = GetDestinationService();
            ViewBag.Detail = await service.GetDestinationByIdAsync(id);

            var model = new DestinationRatingCreate { DestinationId = id };
            return View(model);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Rate(DestinationRatingCreate model)
        {
            if (ModelState.IsValid)
            {
                var service = new RatingService(User.Identity.GetUserId());
                if (await service.CreateDestinationRatingAsync(model))
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(model);
        }

        private DestinationService GetDestinationService()
        {
            var userId = User.Identity.GetUserId();
            var service = new DestinationService(userId);
            return service;
        }
    }
}