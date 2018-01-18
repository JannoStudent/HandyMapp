﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoogleMapsAPI.NET.API.Places.Components;
using HandyMapp.Controllers.API;
using HandyMapp.Data;
using HandyMapp.Models;
using HandyMapp.Models.GoogeApi;
using HandyMapp.Models.GoogeApi.Places.Details;
using HandyMapp.Models.Navigation;
using HandyMapp.Models.Review;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HandyMapp.Controllers
{
    public class ReviewPlacesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReviewPlacesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return Redirect("SelectBuilding");
        }

        public IActionResult SelectBuilding(string error)
        {
            ViewBag.Error = error;
            return View();
        }

        //step 1
        public IActionResult ReviewStarBuilding(IList<PlaceDetails> placePredictions)
        {
            PlacesController placesController = new PlacesController(_context);
            List<PlaceDetails> placeDetailses = placePredictions.Select(m => placesController.Get(m.result.place_id)).Where(m => m != null).ToList();

            if (placeDetailses.Count <= 0)
            {
                return Redirect("SelectBuilding?error=No Place was fount!");
            }
            ReviewBuilding reviewBuilding = new ReviewBuilding();
            reviewBuilding.PlaceId = placeDetailses[0].result.place_id;

            return View(reviewBuilding);
        }

        //step 2
        public IActionResult ReviewDescriptionBuilding(ReviewBuilding reviewBuilding)
        {
            return View(reviewBuilding);
        }

        //step 3
        public IActionResult ReviewDetailsBuilding(ReviewBuilding reviewBuilding)
        {
            return View(reviewBuilding);
        }

        //step 4
        public IActionResult ThankYouBuilding(ReviewBuilding reviewBuilding)
        {
            reviewBuilding.MobilityType = HttpContext.Session.Get<MobilityType>("MobilityType");
            _context.ReviewBuildings.Add(reviewBuilding);
            _context.SaveChanges();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id, string placeId)
        {
            if (id == null)
            {
                return NotFound();
            }
            var reviewBuilding = await _context.ReviewBuildings.SingleOrDefaultAsync(m => m.Id == id);
            if (reviewBuilding == null)
            {
                return NotFound();
            }
            _context.ReviewBuildings.Remove(reviewBuilding);
            await _context.SaveChangesAsync();
            return RedirectToAction("PlaceInput", "Buildings");
        }

        public IActionResult SearchPlaces(string searchstext)
        {
            PlacesController placesController = new PlacesController(_context);
            return PartialView("~/Views/PartialView/CardListPlaceDetails.cshtml", placesController.AutoComplete(searchstext).Result.Select(x => placesController.Get(x.PlaceId)).ToList());
        }
    }
}