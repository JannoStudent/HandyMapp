using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoogleMapsAPI.NET.API.Places.Components;
using Microsoft.AspNetCore.Mvc;

namespace HandyMapp.Controllers
{
    [Route("home/[controller]/[action]")]
    public class BuildingsController : Controller
    {
        public IList<PlacePrediction> PlacePredictions;

        public BuildingsController()
        {
            PlacePredictions = new List<PlacePrediction>();
        }

        public IActionResult Index()
        {
            return Redirect("/Home/Buildings/WayOfSearching");
        }
        
        [HttpPost]
        public JsonResult SetPlacePredictions(IList<PlacePrediction> placePredictions)
        {
            return Json(new
            {
                redirectTo = Url.Action("PlacesResult", "Buildings"),
                returnParam = placePredictions
            });
        }

        public IActionResult PlacesResult(IList<PlacePrediction> placePredictions)
        {
            return View(placePredictions);
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