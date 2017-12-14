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

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }
        public IActionResult street_eval()
        {
            return View();
        }
        [HttpGet]
        public IActionResult street_eval2()
        {
            return View();
        }

        [HttpPost]
        public IActionResult street_eval2(string Value1, string Value2)
        {
            street_eval_model model = new street_eval_model();
            model.lat = Value1;
            model.lng = Value2;
            return View("street_eval2", model);
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
