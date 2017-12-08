using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HandyMapp.Controllers
{
    public class BuildingsController : Controller
    {
        public IActionResult Index()
        {
            return Redirect("/Home/Buildings/PlaceInput");
        }

        public IActionResult PlaceInput()
        {
            return View();
        }

        public IActionResult SelectPlace(GoogleMapsAPI.NET.API.Geocoding.Results.GeocodeResult restult)
        {
            GoogleMapsAPI.NET.API.Places.Results.PlaceDetailsResult test;
            
            return View();
        }

        public IActionResult ReviewPlace(string placeId)
        {
            return View();
        }
    }
}