using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using GoogleMapsAPI.NET.API.Places.Components;
using GoogleMapsAPI.NET.API.Places.Responses;
using GoogleMapsAPI.NET.API.Places.Results;
using HandyMapp.Controllers.API;
using HandyMapp.Data;
using HandyMapp.Models.GoogeApi;
using HandyMapp.Models.GoogeApi.Places.Details;
using HandyMapp.Models.Review;
using Microsoft.AspNetCore.Mvc;

namespace HandyMapp.Controllers
{
    [Route("home/[controller]/[action]")]
    public class BuildingsController : Controller
    {
        private  readonly ApplicationDbContext _context;

        public BuildingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        static readonly HttpClient Client = new HttpClient();

        public IActionResult Index()
        {
            return Redirect("/Home/Buildings/WayOfSearching");
        }

        public IActionResult PlacesResult(IList<PlacePrediction> placePredictions)
        {
            PlacesController placesController = new PlacesController(_context);
            return View(placePredictions.Select(m => placesController.Get(m.PlaceId)).Where(m => m != null).ToList());
        }

        public IActionResult SelectArea()
        {
            return View();
        }

        public IActionResult WayOfSearching()
        {
            return View();
        }

        public IActionResult PlaceInput()
        {
            return View();
        }

        public IActionResult PlaceDetails(string PlaceId)
        {
            if (string.IsNullOrEmpty(PlaceId))
            {
                return Redirect("PlaceInput");
            }
            PlacesController placesController = new PlacesController(_context);
            PlaceDetails placeDetails = placesController.Get(PlaceId);
            List<ReviewBuilding> buildings =_context.ReviewBuildings.Where(m => m.PlaceId.Equals(placeDetails.result.place_id)).ToList();
            DisplayReviewBuilding reviewBuilding = new DisplayReviewBuilding(){PlaceDetails = placeDetails, ReviewBuildings = buildings};
            reviewBuilding.AvrageRatting = 4;
            reviewBuilding.ScooterRatting = 4;
            reviewBuilding.WheelchairRatting = 4;
            reviewBuilding.WalkerRatting = 4;
            reviewBuilding.WalkingStickRatting = 4;
            return View(reviewBuilding);
        }

        /*public IActionResult SelectPlace(GoogleMapsAPI.NET.API.Geocoding.Results.GeocodeResult restult)
        {
            GoogleMapsAPI.NET.API.Places.Results.PlaceDetailsResult test;
            
            return View();
        }

        public IActionResult ReviewPlace(string placeId)
        {
            return View();
        }*/
    }
}