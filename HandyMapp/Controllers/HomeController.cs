using GoogleMapsAPI.NET.API.Client;
using GoogleMapsAPI.NET.API.Directions.Enums;
using GoogleMapsAPI.NET.API.Directions.Results;
using HandyMapp.Data;
using HandyMapp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using HandyMapp.Models.Navigation;

namespace HandyMapp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Preferences()
        {
            return View();
        }

        public IActionResult SelectWalkingAid()
        {
            return View();
        }

        public IActionResult InputRoute()
        {
            return View();
        }

        public IActionResult RouteOptions()
        {
            return View();
        }

        public IActionResult RouteOnMap()
        {
            return View();
        }

        public IActionResult PlaceInput()
        {
            return View("~/Views/Home/Buildings/PlaceInput.cshtml");
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult TestAPI()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
    }
}
