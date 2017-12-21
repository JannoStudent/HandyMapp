﻿using System;
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