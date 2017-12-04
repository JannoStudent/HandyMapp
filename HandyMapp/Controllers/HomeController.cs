using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using GoogleMapsAPI.NET.API.Client;
using GoogleMapsAPI.NET.API.Directions.Components;
using GoogleMapsAPI.NET.API.Directions.Enums;
using Microsoft.AspNetCore.Mvc;
using Handy_Mapp.Models;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.Extensions.DependencyInjection;
using GoogleMapsAPI.NET.API.Common.Components.Locations.Common;
using GoogleMapsAPI.NET.API.Directions;
using GoogleMapsAPI.NET.API.Directions.Results;
using HandyMapp.Data;
using HandyMapp.Models;
using Handy_Mapp.Models.Navigation;

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
